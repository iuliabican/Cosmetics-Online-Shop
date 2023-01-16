using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cosmetics_Online_Shop.Data.Migrations
{
    public partial class addCosmeticsTableIntoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cosmetics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CosmeticTypeId = table.Column<int>(type: "int", nullable: false),
                    SpecificClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cosmetics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cosmetics_CosmeticTypes_CosmeticTypeId",
                        column: x => x.CosmeticTypeId,
                        principalTable: "CosmeticTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cosmetics_SpecificClass_SpecificClassId",
                        column: x => x.SpecificClassId,
                        principalTable: "SpecificClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cosmetics_CosmeticTypeId",
                table: "Cosmetics",
                column: "CosmeticTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cosmetics_SpecificClassId",
                table: "Cosmetics",
                column: "SpecificClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cosmetics");
        }
    }
}
