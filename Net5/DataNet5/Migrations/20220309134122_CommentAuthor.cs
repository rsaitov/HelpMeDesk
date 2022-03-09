using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CommentAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "TicketComment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketComment_AuthorId",
                table: "TicketComment",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComment_User_AuthorId",
                table: "TicketComment",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketComment_User_AuthorId",
                table: "TicketComment");

            migrationBuilder.DropIndex(
                name: "IX_TicketComment_AuthorId",
                table: "TicketComment");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "TicketComment");
        }
    }
}
