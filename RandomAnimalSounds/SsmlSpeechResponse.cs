namespace RandomAnimalSounds
{
    public class SsmlSpeechResponse : SpeechResponse
    {
        public SsmlSpeechResponse(Ssml ssml) : base("SSML")
        {
            this.Ssml = ssml.Speak();
        }

        public string Ssml { get; }
    }
}
