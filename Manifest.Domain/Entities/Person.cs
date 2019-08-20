namespace Manifest.Domain.Entities
{
    using EnsureThat;

    public class Person
    {
        private string _manifestNumber;

        public Person(string manifestNumber)
        {
            this.ManifestNumber = manifestNumber;
        }

        public string ManifestNumber
        {
            get => this._manifestNumber;
            private set
            {
                EnsureArg.IsNotNullOrEmpty(
                    value: value,
                    optsFn: options => options.WithMessage("Manifest number cannot be empty."));

                this._manifestNumber = value;
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsTandemInstructor { get; set; }

        public bool IsAffInstructor { get; set; }

        public bool IsCoach { get; set; }

        public bool IsVideographer { get; set; }
    }
}
