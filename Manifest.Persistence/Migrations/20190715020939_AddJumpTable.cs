using Microsoft.EntityFrameworkCore.Migrations;

namespace Manifest.Persistence.Migrations
{
    public partial class AddJumpTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jumps",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    DefaultAltitude = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jumps", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Jumps",
                columns: new[] { "Id", "DefaultAltitude", "Discriminator", "Price" },
                values: new object[,]
                {
                    { "IAFF2", 14500, "AffJump", 200.00m },
                    { "TANVST", 14500, "TandemJump", 325.00m },
                    { "TAN", 14500, "TandemJump", 225.00m },
                    { "GRCW", 14500, "Jump", 48.00m },
                    { "ACW 47", 14500, "Jump", 170.00m },
                    { "ACW 13", 14500, "Jump", 196.00m },
                    { "ADJ 47", 14500, "Jump", 170.00m },
                    { "AWTS47", 14500, "Jump", 175.00m },
                    { "TANGFT", 14500, "TandemJump", 0.00m },
                    { "AWTS13", 14500, "Jump", 200.00m },
                    { "COACHI", 14500, "Jump", 0.00m },
                    { "COACHJ", 14500, "Jump", 26.00m },
                    { "GRWTS", 14500, "Jump", 51.00m },
                    { "COUPON", 14500, "Jump", 0.00m },
                    { "PRPAY", 14500, "Jump", 0.00m },
                    { "14,500", 14500, "Jump", 26.00m },
                    { "IAFF1", 14500, "AffJump", 175.00m },
                    { "OBS", 14500, "Jump", 30.00m },
                    { "TANADV", 14500, "TandemJump", 0.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jumps");
        }
    }
}
