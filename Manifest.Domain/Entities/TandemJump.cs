namespace Manifest.Domain.Entities
{
    public class TandemJump : Jump
    {
        public TandemJump(string id, decimal price, int defaultAltitude = 14500)
            : base(id: id, price: price, defaultAltitude: defaultAltitude)
        {
        }
    }
}
