namespace RandomAnimalSounds
{
    public static class StringExtensions
    {
        public static TextSpeechResponse ToSpeechResponse(this string text)
        {
            return new TextSpeechResponse(text);
        }
    }
}
