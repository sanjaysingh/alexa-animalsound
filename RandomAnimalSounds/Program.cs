
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace RandomAnimalSounds
{
    public static class Program
    {
        [FunctionName("RandomAnimalSound")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("Entered Run function");
            string requestBody = new StreamReader(req.Body).ReadToEnd();

            log.Info($"Request body: {requestBody}");

            dynamic data = JsonConvert.DeserializeObject(requestBody);

            switch (data.request.type.ToString())
            {
                case "IntentRequest":
                case "LaunchRequest":
                    var animalSound = AnimalsSoundsSsmlRandomizer.Next();
                    return animalSound
                            .Then(BreakSsml.OneSecond)
                            .Then(animalSound)
                            .ToSpeechResponse()
                            .OkCamelCaseJsonResult();
                default:
                    return "Welcome to Random Animal sounds. Try asking 'Play random animal sound'"
                            .ToSpeechResponse()
                            .OkCamelCaseJsonResult();
            }
        }
    }
}
