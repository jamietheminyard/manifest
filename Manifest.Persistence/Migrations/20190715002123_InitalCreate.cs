namespace Manifest.Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    ManifestNumber = table.Column<string>(maxLength: 8, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    IsTandemInstructor = table.Column<bool>(nullable: false),
                    IsAffInstructor = table.Column<bool>(nullable: false),
                    IsCoach = table.Column<bool>(nullable: false),
                    IsVideographer = table.Column<bool>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ManifestNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
