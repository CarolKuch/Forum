using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangedIdName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Messages",
                newName: "MessageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "MessageID",
                table: "Messages",
                newName: "ID");
        }
    }
}
