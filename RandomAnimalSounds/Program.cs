
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

            AudioSsml animalSound = null;

            switch (data.request.type.ToString())
            {
                case "IntentRequest":
                    if(data.request.intent.name == "Play")
                    {
                        var animalName = data.request.intent.slots.animalname.value;
                        animalSound = AnimalsSoundsSsmlRandomizer.Next(animalName?.ToString());
                    }
                    break;
            }

            return (animalSound ?? AnimalsSoundsSsmlRandomizer.Next())
                            .Then(BreakSsml.OneSecond)
                            .Then(animalSound)
                            .ToSpeechResponse()
                            .OkCamelCaseJsonResult();
        }
    }
}
