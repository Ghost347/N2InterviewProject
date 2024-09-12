using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouletteAPI.Migrations
{
    /// <inheritdoc />
    public partial class Spins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Bets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Win",
                table: "Bets",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Winnings",
                table: "Bets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Spins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumberResult = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spins", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spins");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "Win",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "Winnings",
                table: "Bets");
        }
    }
}
