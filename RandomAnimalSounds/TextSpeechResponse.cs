namespace RandomAnimalSounds
{
    public class TextSpeechResponse : SpeechResponse
    {
        public TextSpeechResponse(string text) : base("PlainText")
        {
            this.Text = text;
        }

        public string Text { get; }
    }
}
