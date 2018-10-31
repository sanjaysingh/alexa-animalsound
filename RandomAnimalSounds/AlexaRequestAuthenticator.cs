using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RandomAnimalSounds
{
    public static class AlexaRequestAuthenticator
    {
        private static HttpClient client = new HttpClient();

        public static async Task<AuthenticationResponse> Authenitcate(HttpRequest req, TraceWriter log)
        {
            var certChainUrl = req.SignatureCertChainUrl();

            if (!VerifyCertificateUrl(certChainUrl))
            {
                return AuthenticationResponse.InvalidSignatureCertChainUrl;
            }

            var pamEncodedCertText = await client.GetStringAsync(certChainUrl);
            var cert = new X509Certificate2(Encoding.UTF8.GetBytes(pamEncodedCertText));
            if (!cert.Verify())
            {
                return AuthenticationResponse.ExpiredOrNotYetValid;
            }

            if (!cert.GetSubjectAlternativeNames().Contains("echo-api.amazon.com"))
            {
                return AuthenticationResponse.ExpectedSanMissing;
            }

            if (!cert.VerifyChain())
            {
                return AuthenticationResponse.InvalidCertChain;
            }

            string requestBody = new StreamReader(req.Body).ReadToEnd();

            log.Info($"Request body: {requestBody}");

            var encodedSignature = req.Signature();
            if (!VerifySignature(cert, req.Signature(), requestBody))
            {
                return AuthenticationResponse.InvalidSignature;
            }

            dynamic requestObject = JsonConvert.DeserializeObject(requestBody);
            string timeStampText = requestObject.request.timestamp.ToString();
            var timeStamp = DateTime.Parse(timeStampText).ToUniversalTime();
            if((DateTime.UtcNow - timeStamp).TotalSeconds > 150)
            {
                return AuthenticationResponse.InvalidSignature;
            }

            return AuthenticationResponse.Success(requestObject);
        }

        private static string SignatureCertChainUrl(this HttpRequest req) => req.Headers["SignatureCertChainUrl"].First();
        private static string Signature(this HttpRequest req) => req.Headers["Signature"].First();

        private static bool VerifyCertificateUrl(string certChainUrl)
        {
            if (string.IsNullOrWhiteSpace(certChainUrl))
            {
                return false;
            }

            Uri certChainUri;
            if (!Uri.TryCreate(certChainUrl, UriKind.Absolute, out certChainUri))
            {
                return false;
            }

            return
                certChainUri.Host.Equals("s3.amazonaws.com", StringComparison.OrdinalIgnoreCase) &&
                certChainUri.PathAndQuery.StartsWith("/echo.api/") &&
                certChainUri.Scheme == Uri.UriSchemeHttps &&
                certChainUri.Port == 443;
        }

        private static bool VerifySignature(X509Certificate2 cert, string base64Signature, string contents)
        {
            var sha1 = SHA1.Create();
            var bodyHash = sha1.ComputeHash(Encoding.UTF8.GetBytes(contents));
            byte[] signature = Convert.FromBase64String(base64Signature);
            using (var rsa = cert.GetRSAPublicKey())
            {
                return rsa.VerifyHash(bodyHash, signature, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
            }
        }

        /// <summary>
        /// Parses the suject alternative names.
        /// </summary>
        /// <param name="cert">The cert.</param>
        /// <returns></returns>
        private static IEnumerable<string> GetSubjectAlternativeNames(this X509Certificate2 cert)
        {

            Regex sanRex = new Regex(@"^DNS Name=(.*)", RegexOptions.Compiled | RegexOptions.CultureInvariant);

            var sanList = from X509Extension ext in cert.Extensions
                          where ext.Oid.FriendlyName.Equals("Subject Alternative Name", StringComparison.Ordinal)
                          let data = new AsnEncodedData(ext.Oid, ext.RawData)
                          let text = data.Format(true)
                          from line in text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                          let match = sanRex.Match(line)
                          where match.Success && match.Groups.Count > 0 && !string.IsNullOrEmpty(match.Groups[1].Value)
                          select match.Groups[1].Value;

            return sanList;
        }

        private static bool VerifyChain(this X509Certificate2 cert)
        {
            using (X509Chain chain = new X509Chain())
            {
                X509ChainPolicy chainPolicy = new X509ChainPolicy()
                {
                    RevocationMode = X509RevocationMode.Online,
                    RevocationFlag = X509RevocationFlag.EntireChain
                };
                chain.ChainPolicy = chainPolicy;
                return chain.Build(cert);
            }
        }
    }
}
