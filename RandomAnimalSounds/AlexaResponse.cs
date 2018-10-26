namespace RandomAnimalSounds
{
    public class AlexaResponse
    {
        public AlexaResponse(SpeechResponse speechResponse)
        {
            this.Response = new OutputSpeechContainer(speechResponse);
        }

        public OutputSpeechContainer Response { get; }

        public string Version => "1.0";
    }
}
