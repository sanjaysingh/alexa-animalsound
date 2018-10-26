namespace RandomAnimalSounds
{
    public class OutputSpeechContainer
    {
        public OutputSpeechContainer(SpeechResponse speechResponse)
        {
            this.OutputSpeech = speechResponse;
        }

        public SpeechResponse OutputSpeech { get; }
    }
}
