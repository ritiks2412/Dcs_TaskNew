using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_form_and_submission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Submissions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_UserId1",
                table: "Submissions",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Users_UserId1",
                table: "Submissions",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Users_UserId1",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_UserId1",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Submissions");
        }
    }
}
