namespace Manifest.Domain.Entities
{
    using EnsureThat;

    public class Jump
    {
        private string _id;
        private decimal _price;
        private int _defaultAltitude;

        public Jump(string id, decimal price, int defaultAltitude = 14500)
        {
            this.Id = id;
            this.Price = price;
            this.DefaultAltitude = defaultAltitude;
        }

        public string Id
        {
            get => this._id;
            private set
            {
                EnsureArg.IsNotNullOrEmpty(
                    value: value,
                    optsFn: options => options.WithMessage("Jump id cannot be empty."));

                this._id = value;
            }
        }

        public decimal Price
        {
            get => this._price;
            private set
            {
                EnsureArg.IsGte(
                    value: value,
                    limit: 0.00m,
                    optsFn: options => options.WithMessage("Jump price cannot be less than zero."));

                this._price = value;
            }
        }

        public int DefaultAltitude
        {
            get => this._defaultAltitude;
            private set
            {
                // lol, probably need a better limit here
                EnsureArg.IsGt(
                    value: value,
                    limit: 0,
                    optsFn: options => options.WithMessage("Jump default altitude cannot be less than or equal 0."));

                this._defaultAltitude = value;
            }
        }
    }
}
