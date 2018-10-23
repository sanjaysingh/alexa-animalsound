using System;
using System.Collections.Generic;
using System.Reflection;

namespace RandomAnimalSounds
{
    public static class AnimalsSoundsSsmlRandomizer
    {
        private static Dictionary<int, AudioSsml> allAnimalSoundSsml = new Dictionary<int, AudioSsml>();
        private static Random random = new Random();

        static AnimalsSoundsSsmlRandomizer()
        {
            int index = 0;
            foreach(var propInfo in typeof(AudioSsml).GetProperties(BindingFlags.Public | BindingFlags.Static))
            {
                allAnimalSoundSsml.Add(index++, (AudioSsml)propInfo.GetValue(null));
            }
        }

        public static AudioSsml Next()
        {
            return allAnimalSoundSsml[random.Next(allAnimalSoundSsml.Count - 1)];
        }
    }
}
