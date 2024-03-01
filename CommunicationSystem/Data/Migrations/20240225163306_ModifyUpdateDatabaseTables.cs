using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunicationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyUpdateDatabaseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engineers_ServiceTypes_SpecialityServiceTypeID",
                table: "Engineers");

            migrationBuilder.RenameColumn(
                name: "SpecialityServiceTypeID",
                table: "Engineers",
                newName: "ServiceTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Engineers_SpecialityServiceTypeID",
                table: "Engineers",
                newName: "IX_Engineers_ServiceTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Engineers_ServiceTypes_ServiceTypeID",
                table: "Engineers",
                column: "ServiceTypeID",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engineers_ServiceTypes_ServiceTypeID",
                table: "Engineers");

            migrationBuilder.RenameColumn(
                name: "ServiceTypeID",
                table: "Engineers",
                newName: "SpecialityServiceTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Engineers_ServiceTypeID",
                table: "Engineers",
                newName: "IX_Engineers_SpecialityServiceTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Engineers_ServiceTypes_SpecialityServiceTypeID",
                table: "Engineers",
                column: "SpecialityServiceTypeID",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeID");
        }
    }
}
