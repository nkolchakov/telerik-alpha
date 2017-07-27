using OlympicGames.Olympics.Contracts;
using OlympicGames.Olympics.Utils;
using OlympicGames.Utils;
using System;

namespace OlympicGames.Olympics.Models.Abstracts
{
    public abstract class Olympian : IOlympian
    {
        private string firstName;
        private string lastName;
        private string country;

        public Olympian(string firstName, string lastName, string country)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                Validator.ValidateIfNull(value);
                Validator.ValidateMinAndMaxLength(value, Constants.FirstNameMinLength, Constants.FirstNameMaxLength,
                    string.Format(Constants.FirstNameSizeInvalid, Constants.FirstNameMinLength, Constants.FirstNameMaxLength));

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                Validator.ValidateIfNull(value);
                Validator.ValidateMinAndMaxLength(value, Constants.LastNameMinLength, Constants.LastNameMaxLength,
                    string.Format(Constants.LastNameSizeInvalid, Constants.LastNameMinLength, Constants.LastNameMaxLength));

                this.lastName = value;
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                Validator.ValidateIfNull(value);
                Validator.ValidateMinAndMaxLength(value, Constants.CountryNameMinLength, Constants.CountryNameMaxLength,
                    String.Format(Constants.CountrySizeInvalid, Constants.CountryNameMinLength, Constants.CountryNameMaxLength));

                this.country = value;
            }
        }

        protected abstract string Type { get; }

        // 2 wrong test cases if using this.GetType().Name().ToUpper() :(
        public override string ToString()
        {
            return $"{this.Type}: {this.FirstName} {this.LastName} from {this.Country}\n";
        }
    }
}
