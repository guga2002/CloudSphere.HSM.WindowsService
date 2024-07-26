using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HSM.WinService.Core.Migrations
{
    /// <inheritdoc />
    public partial class Migratee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ActionCodes",
                columns: new[] { "ActionId", "Action_In_English", "Action_in_Georgian", "Code_Of_Action" },
                values: new object[] { 1, "Room one Have Error, Check Air Condition", "პირველ ოთახს აქვს ხარვეზი, შეამოწმე თერმოსტატი!", "101" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActionCodes",
                keyColumn: "ActionId",
                keyValue: 1);
        }
    }
}
