
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
        public static bool AuthDisabled { get; set; }

        [FunctionName("animalsound")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            object requestBody;
            if (!AuthDisabled)
            {
                log.Info("Auth enabled.");
                var authResult = AlexaRequestAuthenticator.Authenitcate(req, log).GetAwaiter().GetResult();
                if (authResult.IsFailure())
                {
                    log.Error("Authentication error. Code = " + authResult.Name);
                    return new BadRequestResult();
                }

                requestBody = authResult.Body;
            }
            else
            {
                log.Info("Auth is disabled");
                requestBody = JsonConvert.DeserializeObject(new StreamReader(req.Body).ReadToEnd());
            }

            AudioSsml animalSound = null;
            bool shouldEndSession = true;
            dynamic data = requestBody;

            switch (data.request.type.ToString())
            {
                case "LaunchRequest":
                    shouldEndSession = false;
                    break;
                case "IntentRequest":
                    if (data.request.intent.name == "Play")
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
