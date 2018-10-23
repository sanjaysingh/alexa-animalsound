namespace RandomAnimalSounds
{
    public class BreakSsml : Ssml
    {
        public BreakSsml(int seconds) : base ($"<break time=\"{seconds}s\"/> ")
        {
        }

        public static BreakSsml OneSecond => new BreakSsml(1);
        public static BreakSsml TwoSeconds => new BreakSsml(2);
        public static BreakSsml ThreeSeconds => new BreakSsml(3);
    }
}
