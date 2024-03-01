using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunicationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyCarModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarEngineer",
                columns: table => new
                {
                    CarsCarID = table.Column<int>(type: "int", nullable: false),
                    SpecialistsEngineerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarEngineer", x => new { x.CarsCarID, x.SpecialistsEngineerID });
                    table.ForeignKey(
                        name: "FK_CarEngineer_Cars_CarsCarID",
                        column: x => x.CarsCarID,
                        principalTable: "Cars",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarEngineer_Engineers_SpecialistsEngineerID",
                        column: x => x.SpecialistsEngineerID,
                        principalTable: "Engineers",
                        principalColumn: "EngineerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarEngineer_SpecialistsEngineerID",
                table: "CarEngineer",
                column: "SpecialistsEngineerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarEngineer");
        }
    }
}
