namespace Manifest.Domain.Entities
{
    public class AffJump : Jump
    {
        public AffJump(string id, decimal price, int defaultAltitude = 14500)
            : base(id: id, price: price, defaultAltitude: defaultAltitude)
        {
        }
    }
}
