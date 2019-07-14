namespace Manifest.Domain.Entities
{
    using EnsureThat;

    public class Aircraft
    {
        private string _name;
        private int _capacity;

        public Aircraft(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get => this._name;
            private set
            {
                EnsureArg.IsNotNullOrEmpty(
                    value: value,
                    optsFn: options => options.WithMessage("Aircraft name cannot be empty."));

                this._name = value;
            }
        }

        public int Capacity
        {
            get => this._capacity;
            set
            {
                EnsureArg.IsGte(
                    value: value,
                    limit: 1,
                    optsFn: options => options.WithMessage("Aircraft capacity cannot be less than 1."));

                this._capacity = value;
            }
        }
    }
}
