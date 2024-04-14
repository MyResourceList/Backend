using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyResourceList.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Resources",
                type: "string",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Resources",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "string");
        }
    }
}
