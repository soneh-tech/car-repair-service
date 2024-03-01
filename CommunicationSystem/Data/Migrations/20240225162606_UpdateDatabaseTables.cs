using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunicationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarEngineer");

            migrationBuilder.DropTable(
                name: "EngineerServiceType");

            migrationBuilder.DropColumn(
                name: "LicensePlate",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarID",
                table: "Engineers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialityServiceTypeID",
                table: "Engineers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Engineers_CarID",
                table: "Engineers",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_Engineers_SpecialityServiceTypeID",
                table: "Engineers",
                column: "SpecialityServiceTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Engineers_Cars_CarID",
                table: "Engineers",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "CarID");

            migrationBuilder.AddForeignKey(
                name: "FK_Engineers_ServiceTypes_SpecialityServiceTypeID",
                table: "Engineers",
                column: "SpecialityServiceTypeID",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engineers_Cars_CarID",
                table: "Engineers");

            migrationBuilder.DropForeignKey(
                name: "FK_Engineers_ServiceTypes_SpecialityServiceTypeID",
                table: "Engineers");

            migrationBuilder.DropIndex(
                name: "IX_Engineers_CarID",
                table: "Engineers");

            migrationBuilder.DropIndex(
                name: "IX_Engineers_SpecialityServiceTypeID",
                table: "Engineers");

            migrationBuilder.DropColumn(
                name: "CarID",
                table: "Engineers");

            migrationBuilder.DropColumn(
                name: "SpecialityServiceTypeID",
                table: "Engineers");

            migrationBuilder.AddColumn<string>(
                name: "LicensePlate",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateTable(
                name: "EngineerServiceType",
                columns: table => new
                {
                    EngineersEngineerID = table.Column<int>(type: "int", nullable: false),
                    SpecialityServiceTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineerServiceType", x => new { x.EngineersEngineerID, x.SpecialityServiceTypeID });
                    table.ForeignKey(
                        name: "FK_EngineerServiceType_Engineers_EngineersEngineerID",
                        column: x => x.EngineersEngineerID,
                        principalTable: "Engineers",
                        principalColumn: "EngineerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineerServiceType_ServiceTypes_SpecialityServiceTypeID",
                        column: x => x.SpecialityServiceTypeID,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarEngineer_SpecialistsEngineerID",
                table: "CarEngineer",
                column: "SpecialistsEngineerID");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerServiceType_SpecialityServiceTypeID",
                table: "EngineerServiceType",
                column: "SpecialityServiceTypeID");
        }
    }
}
