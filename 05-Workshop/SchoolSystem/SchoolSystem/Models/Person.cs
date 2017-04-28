using SchoolSystem.Models.Contracts;
using System;

namespace SchoolSystem.Models
{
    public class Person : IPerson
    {
        private const int MIN_FULL_NAME_LENGTH = 2;
        private const int MAX_FULL_NAME_LENGTH = 31;
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The first name must be specified!");
                }

                if (value.Length < 2 || 31 < value.Length)
                {
                    throw new ArgumentException(string.Format(
                        "The first name must be between {0} and {1} characters long!", 
                        MIN_FULL_NAME_LENGTH,
                        MAX_FULL_NAME_LENGTH));
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The last name must be specified!");
                }

                if (value.Length < 2 || 31 < value.Length)
                {
                    throw new ArgumentException(string.Format(
                        "The last name must be between {0} and {1} characters long!",
                        MIN_FULL_NAME_LENGTH,
                        MAX_FULL_NAME_LENGTH));
                }

                this.lastName = value;
            }
        }
    }
}
