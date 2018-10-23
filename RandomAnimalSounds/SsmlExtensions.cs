namespace RandomAnimalSounds
{
    public static class SsmlExtensions
    {
        public static SsmlSpeechResponse ToSpeechResponse(this Ssml ssml)
        {
            return new SsmlSpeechResponse(ssml);
        }
    }
}
