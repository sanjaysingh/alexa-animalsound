namespace RandomAnimalSounds
{
    public class AlexaResponse
    {
        public AlexaResponse(SpeechResponse speechResponse)
        {
            this.Response = new { outputSpeech = speechResponse };
        }

        public object Response { get; }
        public string Version => "1.0";
    }
}
