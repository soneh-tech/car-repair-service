using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunicationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedThreeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Engineer_EngineerID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Owner_OwnerID1",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Engineer_AspNetUsers_AppUserId",
                table: "Engineer");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerServiceType_Engineer_EngineersEngineerID",
                table: "EngineerServiceType");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Engineer_EngineerID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Owner_OwnerID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Owner_AspNetUsers_AppUserId",
                table: "Owner");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHistories_Engineer_EngineerID",
                table: "ServiceHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHistories_Owner_OwnerID",
                table: "ServiceHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owner",
                table: "Owner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Engineer",
                table: "Engineer");

            migrationBuilder.RenameTable(
                name: "Owner",
                newName: "Owners");

            migrationBuilder.RenameTable(
                name: "Engineer",
                newName: "Engineers");

            migrationBuilder.RenameIndex(
                name: "IX_Owner_AppUserId",
                table: "Owners",
                newName: "IX_Owners_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Engineer_AppUserId",
                table: "Engineers",
                newName: "IX_Engineers_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owners",
                table: "Owners",
                column: "OwnerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Engineers",
                table: "Engineers",
                column: "EngineerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Engineers_EngineerID",
                table: "Appointments",
                column: "EngineerID",
                principalTable: "Engineers",
                principalColumn: "EngineerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Owners_OwnerID1",
                table: "Appointments",
                column: "OwnerID1",
                principalTable: "Owners",
                principalColumn: "OwnerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Engineers_AspNetUsers_AppUserId",
                table: "Engineers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerServiceType_Engineers_EngineersEngineerID",
                table: "EngineerServiceType",
                column: "EngineersEngineerID",
                principalTable: "Engineers",
                principalColumn: "EngineerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Engineers_EngineerID",
                table: "Messages",
                column: "EngineerID",
                principalTable: "Engineers",
                principalColumn: "EngineerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Owners_OwnerID",
                table: "Messages",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "OwnerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_AspNetUsers_AppUserId",
                table: "Owners",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHistories_Engineers_EngineerID",
                table: "ServiceHistories",
                column: "EngineerID",
                principalTable: "Engineers",
                principalColumn: "EngineerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHistories_Owners_OwnerID",
                table: "ServiceHistories",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "OwnerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Engineers_EngineerID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Owners_OwnerID1",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Engineers_AspNetUsers_AppUserId",
                table: "Engineers");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerServiceType_Engineers_EngineersEngineerID",
                table: "EngineerServiceType");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Engineers_EngineerID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Owners_OwnerID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_AspNetUsers_AppUserId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHistories_Engineers_EngineerID",
                table: "ServiceHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHistories_Owners_OwnerID",
                table: "ServiceHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owners",
                table: "Owners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Engineers",
                table: "Engineers");

            migrationBuilder.RenameTable(
                name: "Owners",
                newName: "Owner");

            migrationBuilder.RenameTable(
                name: "Engineers",
                newName: "Engineer");

            migrationBuilder.RenameIndex(
                name: "IX_Owners_AppUserId",
                table: "Owner",
                newName: "IX_Owner_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Engineers_AppUserId",
                table: "Engineer",
                newName: "IX_Engineer_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owner",
                table: "Owner",
                column: "OwnerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Engineer",
                table: "Engineer",
                column: "EngineerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Engineer_EngineerID",
                table: "Appointments",
                column: "EngineerID",
                principalTable: "Engineer",
                principalColumn: "EngineerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Owner_OwnerID1",
                table: "Appointments",
                column: "OwnerID1",
                principalTable: "Owner",
                principalColumn: "OwnerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Engineer_AspNetUsers_AppUserId",
                table: "Engineer",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerServiceType_Engineer_EngineersEngineerID",
                table: "EngineerServiceType",
                column: "EngineersEngineerID",
                principalTable: "Engineer",
                principalColumn: "EngineerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Engineer_EngineerID",
                table: "Messages",
                column: "EngineerID",
                principalTable: "Engineer",
                principalColumn: "EngineerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Owner_OwnerID",
                table: "Messages",
                column: "OwnerID",
                principalTable: "Owner",
                principalColumn: "OwnerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Owner_AspNetUsers_AppUserId",
                table: "Owner",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHistories_Engineer_EngineerID",
                table: "ServiceHistories",
                column: "EngineerID",
                principalTable: "Engineer",
                principalColumn: "EngineerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHistories_Owner_OwnerID",
                table: "ServiceHistories",
                column: "OwnerID",
                principalTable: "Owner",
                principalColumn: "OwnerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
