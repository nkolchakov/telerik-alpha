namespace OlympicGames.Olympics.Utils
{
    public static class Constants
    {
        public const string CreatedSprinterText = "Created Sprinter";
        public const string CreatedBoxerText = "Created Boxer";

        public const string SprinterType = "SPRINTER";
        public const string BoxerType = "BOXER";

        public const string CountrySizeInvalid = "Country must be between {0} and {1} characters long!";
        public const string FirstNameSizeInvalid = "First name must be between {0} and {1} characters long!";
        public const string LastNameSizeInvalid = "Last name must be between {0} and {1} characters long!";
        public const string WinsRangeInvalid = "Wins must be between {0} and {1}!";
        public const string LossesRangeInvalid = "Losses must be between {0} and {1}!";

        public const string InvalidEnumeration = "Invalid enumeration value for {0}";

        public const string DefaultKey = "firstname";
        public const string DefaultOrder = "asc";

        public const int FirstNameMinLength = 2;
        public const int FirstNameMaxLength = 20;

        public const int LastNameMinLength = 2;
        public const int LastNameMaxLength = 20;

        public const int CountryNameMinLength = 3;
        public const int CountryNameMaxLength = 25;

        public const int MinWins = 0;
        public const int MaxWins = 100;

        public const int MinLosses = 0;
        public const int MaxLosses = 100;

        public const int BoxersParamsCount = 6;
        public const int SprinterMinParamsCount = 3;
    }
}
