using SchoolSystem.Enums;
using SchoolSystem.Models.Contracts;
using System;

namespace SchoolSystem.Models
{
    public class Mark : IMark
    {
        private const float MIN_MARK_VALUE = 2f;
        private const float MAX_MARK_VALUE = 6f;
        private float markValue;
        private Subjct subject;

        public Mark(Subjct subject, float value)
        {
            this.Subject = subject;
            this.Value = value;
        }

        public Subjct Subject
        {
            get
            {
                return this.subject;
            }

            private set
            {
                this.subject = value;
            }
        }

        public float Value
        {
            get
            {
                return this.markValue;
            }

            private set
            {
                if (value < MIN_MARK_VALUE || MAX_MARK_VALUE < value)
                {
                    throw new ArgumentException(string.Format(
                        "Mark value must be between {0} and {1}",
                        MIN_MARK_VALUE,
                        MAX_MARK_VALUE));
                }

                this.markValue = value;
            }
        }
    }
}
