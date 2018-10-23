namespace RandomAnimalSounds
{
    public class Ssml
    {
        private readonly string ssmlText;

        public Ssml (string ssmlText)
        {
            this.ssmlText = ssmlText;
        }

        public Ssml Then(Ssml nextSsml)
        {
            return new Ssml(this.ssmlText + nextSsml.ssmlText);
        }

        public string Speak()
        {
            return $"<speak>{this.ssmlText}</speak>";
        }

        public override string ToString()
        {
            return this.ssmlText;
        }
    }
}
