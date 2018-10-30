//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Azure.WebJobs.Host;
//using System;
//using System.Linq;
//using System.Net.Http;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;

//namespace RandomAnimalSounds
//{
//    public static class AlexaRequestAuthenticator
//    {
//        private static HttpClient client = new HttpClient();

//        public static async Task<AuthenticationResponse> Authenitcate(HttpRequest req, TraceWriter log)
//        {
//            var certChainUrl = req.SignatureCertChainUrl();

//            if (!VerifyCertificateUrl(certChainUrl))
//            {
//                return AuthenticationResponse.InvalidSignatureCertChainUrl;
//            }

//            var pamEncodedCertText = await client.GetStringAsync(certChainUrl);
//            var cert = new X509Certificate2(Encoding.UTF8.GetBytes(pamEncodedCertText));
//            if(cert.NotBefore > DateTime.Today || cert.NotAfter <= DateTime.Today)
//            {
//                return AuthenticationResponse.ExpiredSignatureCert;
//            }
//            if(cert.GetSubjectAlternativeNames())

//        }

//        private static string SignatureCertChainUrl(this HttpRequest req) => req.Headers["SignatureCertChainUrl"].First();
//        private static string Signature(this HttpRequest req) => req.Headers["Signature"].First();

//        private static bool VerifyCertificateUrl(string certChainUrl)
//        {
//            if (string.IsNullOrWhiteSpace(certChainUrl))
//            {
//                return false;
//            }

//            Uri certChainUri;
//            if (!Uri.TryCreate(certChainUrl, UriKind.Absolute, out certChainUri))
//            {
//                return false;
//            }

//            return
//                certChainUri.Host.Equals("s3.amazonaws.com", StringComparison.OrdinalIgnoreCase) &&
//                certChainUri.PathAndQuery.StartsWith("/echo.api/") &&
//                certChainUri.Scheme == Uri.UriSchemeHttps &&
//                certChainUri.Port == 443;
//        }

//    }
//}
