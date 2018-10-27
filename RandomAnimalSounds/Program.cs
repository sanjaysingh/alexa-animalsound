
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
        [FunctionName("animalsound")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("Entered Run function");
            string requestBody = new StreamReader(req.Body).ReadToEnd();

            log.Info($"Request body: {requestBody}");

            dynamic data = JsonConvert.DeserializeObject(requestBody);

            AudioSsml animalSound = null;
            bool shouldEndSession = true;

            switch (data.request.type.ToString())
            {
                case "LaunchRequest":
                    shouldEndSession = false;
                    break;
                case "IntentRequest":
                    if(data.request.intent.name == "Play")
                    {
                        var animalName = data.request.intent.slots.animalname.value;
                        animalSound = AnimalsSoundsSsmlRandomizer.Next(animalName?.ToString());
                    }
                    break;
            }

            animalSound = animalSound ?? AnimalsSoundsSsmlRandomizer.Next();
            return animalSound 
                            .Then(BreakSsml.OneSecond)
                            .Then(animalSound)
                            .ToSpeechResponse()
                            .ToAlexaResponse(shouldEndSession)
                            .OkCamelCaseJsonResult();
        }
    }
}
