using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace RandomAnimalSounds
{
    /// <summary>
    /// Extensions to alexa response. The reason they are seperate from directly into speech response is because of seperation of concern. Speech response itself has
    /// no business with this extensions. It is rather syntactic sugar for how response is to be returned.
    /// </summary>
    public static class AlexaResponseExtensions
    {
        private static readonly JsonSerializerSettings CamelCaseSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

        public static JsonResult OkCamelCaseJsonResult(this AlexaResponse alexaResponse)
        {
            return new JsonResult(alexaResponse, CamelCaseSerializerSettings)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
