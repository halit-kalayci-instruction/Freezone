using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RoleSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupTreeContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NavigateUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowOrder = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTreeContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TitleDefinitons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleDefinitons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupTreeContentOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupTreeContentId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTreeContentOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupTreeContentOperationClaims_GroupTreeContents_GroupTreeContentId",
                        column: x => x.GroupTreeContentId,
                        principalTable: "GroupTreeContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupTreeContentOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TitleOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleDefinitionId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false),
                    TitleDefinitonId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TitleOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TitleOperationClaims_TitleDefinitons_TitleDefinitonId",
                        column: x => x.TitleDefinitonId,
                        principalTable: "TitleDefinitons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTitleDefinitons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    HrTitleDefinitonId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTitleDefinitons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTitleDefinitons_TitleDefinitons_HrTitleDefinitonId",
                        column: x => x.HrTitleDefinitonId,
                        principalTable: "TitleDefinitons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTitleDefinitons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupTreeContentOperationClaims_GroupTreeContentId",
                table: "GroupTreeContentOperationClaims",
                column: "GroupTreeContentId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTreeContentOperationClaims_OperationClaimId",
                table: "GroupTreeContentOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleOperationClaims_OperationClaimId",
                table: "TitleOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleOperationClaims_TitleDefinitonId",
                table: "TitleOperationClaims",
                column: "TitleDefinitonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTitleDefinitons_HrTitleDefinitonId",
                table: "UserTitleDefinitons",
                column: "HrTitleDefinitonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTitleDefinitons_UserId",
                table: "UserTitleDefinitons",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupTreeContentOperationClaims");

            migrationBuilder.DropTable(
                name: "TitleOperationClaims");

            migrationBuilder.DropTable(
                name: "UserTitleDefinitons");

            migrationBuilder.DropTable(
                name: "GroupTreeContents");

            migrationBuilder.DropTable(
                name: "TitleDefinitons");
        }
    }
}
