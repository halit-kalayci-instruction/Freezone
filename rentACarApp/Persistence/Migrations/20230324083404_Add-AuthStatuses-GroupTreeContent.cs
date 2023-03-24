using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthStatusesGroupTreeContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HideOnAuth",
                table: "GroupTreeContents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowOnAuth",
                table: "GroupTreeContents",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HideOnAuth",
                table: "GroupTreeContents");

            migrationBuilder.DropColumn(
                name: "ShowOnAuth",
                table: "GroupTreeContents");
        }
    }
}
