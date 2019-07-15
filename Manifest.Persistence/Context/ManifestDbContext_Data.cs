namespace Manifest.Persistence.Context
{
    using Manifest.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public partial class ManifestDbContext
    {
        private static void ConfigureJumpData(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Jump>()
                .HasData(new Jump[]
                {
                    new Jump(
                        id: "14,500",
                        price: 26.00m),
                    new Jump(
                        id: "PRPAY",
                        price: 0.00m),
                    new Jump(
                        id: "COUPON",
                        price: 0.00m),
                    new Jump(
                        id: "GRWTS",
                        price: 51.00m),
                    new Jump(
                        id: "COACHJ",
                        price: 26.00m),
                    new Jump(
                        id: "COACHI",
                        price: 0.00m),
                    new Jump(
                        id: "OBS",
                        price: 30.00m),
                    new Jump(
                        id: "AWTS13",
                        price: 200.00m),
                    new Jump(
                        id: "AWTS47",
                        price: 175.00m),
                    new Jump(
                        id: "ADJ 47",
                        price: 170.00m),
                    new Jump(
                        id: "ACW 13",
                        price: 196.00m),
                    new Jump(
                        id: "ACW 47",
                        price: 170.00m),
                    new Jump(
                        id: "GRCW",
                        price: 48.00m),
                });

            modelBuilder
                .Entity<TandemJump>()
                .HasData(new Jump[]
                {
                    new TandemJump(
                        id: "TAN",
                        price: 225.00m),
                    new TandemJump(
                        id: "TANVST",
                        price: 325.00m),
                    new TandemJump(
                        id: "TANGFT",
                        price: 0.00m),
                    new TandemJump(
                        id: "TANADV",
                        price: 0.00m),
                });

            modelBuilder
                .Entity<AffJump>()
                .HasData(new Jump[]
                {
                    new AffJump(
                        id: "IAFF2",
                        price: 200.00m),
                    new AffJump(
                        id: "IAFF1",
                        price: 175.00m),
                });
        }
    }
}
