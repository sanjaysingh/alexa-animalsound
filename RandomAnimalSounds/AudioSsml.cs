namespace RandomAnimalSounds
{
    public class AudioSsml : Ssml
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioSsml"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public AudioSsml(string source) : base($"<audio src=\"{source}\"/>")
        {
        }

        public static AudioSsml BearGrownRoar => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_bear_groan_roar_01");
        public static AudioSsml BearRoarGrumble => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_bear_roar_grumble_01");
        public static AudioSsml BearRoarSmall => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_bear_roar_small_01");
        public static AudioSsml BirdChickadeeChirp => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_bird_chickadee_chirp_1x_01");
        public static AudioSsml BirdChickadeeChirps => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_bird_chickadee_chirps_01");
        public static AudioSsml BirdForest01 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_bird_forest_01");
        public static AudioSsml BirdForest02 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_bird_forest_02");
        public static AudioSsml BirdForestShort => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_bird_forest_short_01");
        public static AudioSsml BirdRobinChirp => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_bird_robin_chirp_1x_01");
        public static AudioSsml CatAngryMeow01 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_cat_angry_meow_1x_01");
        public static AudioSsml CatAngryMeow02 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_cat_angry_meow_1x_02");
        public static AudioSsml CatAngryScreech => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_cat_angry_screech_1x_01");
        public static AudioSsml CatLongMeow => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_cat_long_meow_1x_01");
        public static AudioSsml CatMeow01 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_cat_meow_1x_01");
        public static AudioSsml CatMeow02 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_cat_meow_1x_02");
        public static AudioSsml CatPurr01 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_cat_purr_01");
        public static AudioSsml CatPurr02 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_cat_purr_02");
        public static AudioSsml CatPurr03 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_cat_purr_03");
        public static AudioSsml CatPurrMeow => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_cat_purr_meow_01");
        public static AudioSsml ChickenCluck => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_chicken_cluck_01");
        public static AudioSsml CrowCaw01 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_crow_caw_1x_01");
        public static AudioSsml CrowCaw02 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_crow_caw_1x_02");
        public static AudioSsml DogMediumBark01 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_dog_med_bark_1x_01");
        public static AudioSsml DogMediumBark02 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_dog_med_bark_1x_02");
        public static AudioSsml DogMediumBark03 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_dog_med_bark_1x_03");
        public static AudioSsml DogMedium2Barks01 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_dog_med_bark_2x_01");
        public static AudioSsml DogMedium2Barks02 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_dog_med_bark_2x_02");
        public static AudioSsml DogMedium2Barks03 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_dog_med_bark_2x_03");
        public static AudioSsml DogMediumBarkGrowl => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_dog_med_bark_growl_01");
        public static AudioSsml DogMediumGrowl => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_dog_med_growl_1x_01");
        public static AudioSsml DogMediumWoof => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_dog_med_woof_1x_01");
        public static AudioSsml DogSmallBark => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_dog_small_bark_2x_01");
        public static AudioSsml Elephant01 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_elephant_01");
        public static AudioSsml Elephant02 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_elephant_02");
        public static AudioSsml Elephant03 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_elephant_03");
        public static AudioSsml Elephant04 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_elephant_04");
        public static AudioSsml Elephant05 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_elephant_05");
        public static AudioSsml HorseGallop01 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_horse_gallop_4x_01");
        public static AudioSsml HorseGallop02 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_horse_gallop_4x_02");
        public static AudioSsml HorseGallop03 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_horse_gallop_4x_03");
        public static AudioSsml HorseHuffWhinny => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_horse_huff_whinny_01");
        public static AudioSsml HorseNeigh => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_horse_neigh_01");
        public static AudioSsml HorseNeighLow => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_horse_neigh_low_01");
        public static AudioSsml HorseWhinny01 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_horse_whinny_01");
        public static AudioSsml HorseWhinny02 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_horse_whinny_02");
        public static AudioSsml HorseWhinny03 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_horse_whinny_03");
        public static AudioSsml LionRoar01 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_lion_roar_01");
        public static AudioSsml LionRoar02 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_lion_roar_02");
        public static AudioSsml LionRoar03 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_lion_roar_03");
        public static AudioSsml MonkeyCalls => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_monkey_calls_3x_01");
        public static AudioSsml MonkeyChimp => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_monkey_chimp_01");
        public static AudioSsml MonkeyChatter => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_monkeys_chatter_01");
        public static AudioSsml RatSqueaks => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_rat_squeaks_01");
        public static AudioSsml Rat2Squeaks => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_rat_squeak_2x_01");
        public static AudioSsml RavenCaw => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_raven_caw_1x_01");
        public static AudioSsml Raven2Caws => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_raven_caw_2x_01");
        public static AudioSsml RoosterCrow01 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_rooster_crow_01");
        public static AudioSsml RoosterCrow02 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_rooster_crow_02");
        public static AudioSsml SheepBaa => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_sheep_baa_01");
        public static AudioSsml SheepBleat01 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_sheep_bleat_01");
        public static AudioSsml SheepBleat02 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_sheep_bleat_02");
        public static AudioSsml SheepBleat03 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_sheep_bleat_03");
        public static AudioSsml TurkeyGobbling => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_turkey_gobbling_01");
        public static AudioSsml WolfHowl01 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_wolf_howl_01");
        public static AudioSsml WolfHowl02 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_wolf_howl_02");
        public static AudioSsml WolfHowl03 => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_wolf_howl_03");
        public static AudioSsml WolfYoungHowl => new AudioSsml("soundbank://soundlibrary/animals/amzn_sfx_wolf_young_howl_01");
    }
}
