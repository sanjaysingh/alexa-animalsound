namespace RandomAnimalSounds
{
    /// <summary>
    /// Extensions to sppech response. The reason they are seperate from directly into speech response is because of seperation of concern. Speech response itself has
    /// no business with this extensions. It is rather syntactic sugar for how response is to be returned.
    /// </summary>
    public static class SpeechResponseExtensions
    {
        public static AlexaResponse ToAlexaResponse(this SpeechResponse speechResponse)
        {
            return new AlexaResponse(speechResponse);
        }
    }
}
