using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunicationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Owners_OwnerID1",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_OwnerID1",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "OwnerID1",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerID",
                table: "Appointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_OwnerID",
                table: "Appointments",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Owners_OwnerID",
                table: "Appointments",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "OwnerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Owners_OwnerID",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_OwnerID",
                table: "Appointments");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerID",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OwnerID1",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_OwnerID1",
                table: "Appointments",
                column: "OwnerID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Owners_OwnerID1",
                table: "Appointments",
                column: "OwnerID1",
                principalTable: "Owners",
                principalColumn: "OwnerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
