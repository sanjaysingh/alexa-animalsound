using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomAnimalSounds;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Xunit;

namespace RandomAnimalSoundsTests
{
    public class PlayAnimalSoundSpec
    {
        public PlayAnimalSoundSpec()
        {
            Program.AuthDisabled = true;
        }

        [Fact]
        public void LaunchRequest_FiveTimes_ShouldPlayRandomAnimalSounds()
        {
            string launchRequestJson = ReadEmbeddedResource("RandomAnimalSoundsTests.LaunchRequest.json");

            HashSet<string> sounds = new HashSet<string>();
            for (int i = 0; i < 5; i++)
            {
                var response = Program.Run(CreateRequest(launchRequestJson), new TraceWriterStub());
                var ssmlResponse = ((response as JsonResult).Value as AlexaResponse).Response.OutputSpeech as SsmlSpeechResponse;
                var ssmlSource = XElement.Parse(ssmlResponse.Ssml).Element("audio").Attribute("src").Value.ToString();
                sounds.Add(ssmlSource);
            }

            Assert.True(sounds.Count > 1, "Randomization is not working as expected.");
        }

        [Fact]
        public void IntentRequest_CatFiveTimes_ShouldPlayRandomCatSounds()
        {
            string intentRequestJson = ReadEmbeddedResource("RandomAnimalSoundsTests.CatSoundIntentRequest.json");

            HashSet<string> sounds = new HashSet<string>();
            for (int i = 0; i < 5; i++)
            {
                var response = Program.Run(CreateRequest(intentRequestJson), new TraceWriterStub());
                dynamic dynamicResponse = ((response as JsonResult).Value as AlexaResponse).Response;
                var ssmlResponse = ((response as JsonResult).Value as AlexaResponse).Response.OutputSpeech as SsmlSpeechResponse;
                var ssmlSource = XElement.Parse(ssmlResponse.Ssml).Element("audio").Attribute("src").Value.ToString();
                sounds.Add(ssmlSource);
            }

            Assert.True(sounds.All(x => x.ToLower().Contains("cat")), "Some other animal sound is played when cat was requested.");
            Assert.True(sounds.Count > 1, "Same cat sound is being played on each request.");
        }

        private static HttpRequest CreateRequest(string json)
        {
            var httpContext = new DefaultHttpContext();

            httpContext.Request.Body = GenerateStreamFromString(json);
            httpContext.Request.ContentType = "application/json";
            httpContext.Request.Method = "Post";

            return httpContext.Request;
        }

        private static string ReadEmbeddedResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private static Stream GenerateStreamFromString(string s)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(s));
        }
    }
}
