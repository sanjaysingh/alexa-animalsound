using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RandomAnimalSounds
{
    public static class Extensions
    {
        private static readonly JsonSerializerSettings CamelCaseSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };


        public static SsmlSpeechResponse ToSpeechResponse(this Ssml ssml)
        {
            return new SsmlSpeechResponse(ssml);
        }

        public static AlexaResponse ToAlexaResponse(this SpeechResponse speechResponse, bool shouldEndSession)
        {
            return new AlexaResponse(speechResponse, shouldEndSession);
        }

        
        public static JsonResult OkCamelCaseJsonResult(this AlexaResponse alexaResponse)
        {
            return new JsonResult(alexaResponse, CamelCaseSerializerSettings)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
