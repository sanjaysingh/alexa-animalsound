namespace RandomAnimalSounds
{
    public class AlexaResponse
    {
        public AlexaResponse(SpeechResponse speechResponse, bool shouldEndSession)
        {
            this.Response = new OutputSpeechContainer(speechResponse);
            this.ShouldEndSession = shouldEndSession;
        }

        public OutputSpeechContainer Response { get; }

        public string Version => "1.0";

        public bool ShouldEndSession { get; private set; }
    }
}
