using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HSM.WinService.Core.Migrations
{
    /// <inheritdoc />
    public partial class Migrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionCodes",
                columns: table => new
                {
                    ActionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code_Of_Action = table.Column<string>(type: "TEXT", nullable: false),
                    Action_In_English = table.Column<string>(type: "TEXT", nullable: false),
                    Action_in_Georgian = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionCodes", x => x.ActionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionCodes");
        }
    }
}
