using Microsoft.EntityFrameworkCore.Migrations;

namespace iRepair_BE_NET.Migrations
{
    public partial class updateadmins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fullname",
                table: "admins",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fullname",
                table: "admins");
        }
    }
}
