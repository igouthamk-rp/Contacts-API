using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_API_1.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "College",
                table: "ContactsDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "BVRIT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "College",
                table: "ContactsDb");
        }
    }
}
