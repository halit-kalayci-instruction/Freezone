using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TitleOperationClaims_TitleDefinitons_TitleDefinitonId",
                table: "TitleOperationClaims");

            migrationBuilder.DropIndex(
                name: "IX_TitleOperationClaims_TitleDefinitonId",
                table: "TitleOperationClaims");

            migrationBuilder.DropColumn(
                name: "TitleDefinitonId",
                table: "TitleOperationClaims");

            migrationBuilder.CreateIndex(
                name: "IX_TitleOperationClaims_TitleDefinitionId",
                table: "TitleOperationClaims",
                column: "TitleDefinitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TitleOperationClaims_TitleDefinitons_TitleDefinitionId",
                table: "TitleOperationClaims",
                column: "TitleDefinitionId",
                principalTable: "TitleDefinitons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TitleOperationClaims_TitleDefinitons_TitleDefinitionId",
                table: "TitleOperationClaims");

            migrationBuilder.DropIndex(
                name: "IX_TitleOperationClaims_TitleDefinitionId",
                table: "TitleOperationClaims");

            migrationBuilder.AddColumn<int>(
                name: "TitleDefinitonId",
                table: "TitleOperationClaims",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TitleOperationClaims_TitleDefinitonId",
                table: "TitleOperationClaims",
                column: "TitleDefinitonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TitleOperationClaims_TitleDefinitons_TitleDefinitonId",
                table: "TitleOperationClaims",
                column: "TitleDefinitonId",
                principalTable: "TitleDefinitons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
