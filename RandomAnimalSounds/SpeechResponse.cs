namespace RandomAnimalSounds
{
    public abstract class SpeechResponse
    {
        public SpeechResponse(string type)
        {
            this.Type = type;
        }

        public string Type  { get; }
    }
}
