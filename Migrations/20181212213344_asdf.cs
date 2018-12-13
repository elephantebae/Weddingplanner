using Microsoft.EntityFrameworkCore.Migrations;

namespace weddingplanner.Migrations
{
    public partial class asdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rsvp_Users_UserId",
                table: "Rsvp");

            migrationBuilder.DropForeignKey(
                name: "FK_Rsvp_weddings_WeddingId",
                table: "Rsvp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rsvp",
                table: "Rsvp");

            migrationBuilder.RenameTable(
                name: "Rsvp",
                newName: "Rsvping");

            migrationBuilder.RenameIndex(
                name: "IX_Rsvp_WeddingId",
                table: "Rsvping",
                newName: "IX_Rsvping_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_Rsvp_UserId",
                table: "Rsvping",
                newName: "IX_Rsvping_UserId");

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "weddings",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rsvping",
                table: "Rsvping",
                column: "RsvpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rsvping_Users_UserId",
                table: "Rsvping",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rsvping_weddings_WeddingId",
                table: "Rsvping",
                column: "WeddingId",
                principalTable: "weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rsvping_Users_UserId",
                table: "Rsvping");

            migrationBuilder.DropForeignKey(
                name: "FK_Rsvping_weddings_WeddingId",
                table: "Rsvping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rsvping",
                table: "Rsvping");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "weddings");

            migrationBuilder.RenameTable(
                name: "Rsvping",
                newName: "Rsvp");

            migrationBuilder.RenameIndex(
                name: "IX_Rsvping_WeddingId",
                table: "Rsvp",
                newName: "IX_Rsvp_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_Rsvping_UserId",
                table: "Rsvp",
                newName: "IX_Rsvp_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rsvp",
                table: "Rsvp",
                column: "RsvpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rsvp_Users_UserId",
                table: "Rsvp",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rsvp_weddings_WeddingId",
                table: "Rsvp",
                column: "WeddingId",
                principalTable: "weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
