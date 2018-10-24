using System;
using System.Collections.Generic;
using System.Linq;
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

        public static AudioSsml Next(string animalNameFilter = null)
        {
            if (!string.IsNullOrWhiteSpace(animalNameFilter))
            {
                var filteredAnimals = FindMatchingAnimalIndexes(animalNameFilter).ToArray();
                if (filteredAnimals.Any())
                {
                    return filteredAnimals[random.Next(filteredAnimals.Length - 1)].Value;
                }
            }

            return allAnimalSoundSsml[random.Next(allAnimalSoundSsml.Count - 1)];
        }

        /// <summary>
        /// Finds the matching animal indexes.
        /// </summary>
        /// <param name="animalNameFilter">The animal name filter.</param>
        /// <returns></returns>
        private static IEnumerable<KeyValuePair<int, AudioSsml>> FindMatchingAnimalIndexes(string animalNameFilter)
        {
            return allAnimalSoundSsml.Where(x => x.Value.ToString().ToLower().Contains(animalNameFilter.ToLower()));
        }
    }
}
