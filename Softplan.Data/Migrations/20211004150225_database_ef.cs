using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softplan.Data.Migrations
{
    public partial class database_ef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    idcategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(50)", nullable: false),
                    profit_margin = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.idcategory);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    idproduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idcategory = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(50)", nullable: false),
                    cost_price = table.Column<double>(type: "float", nullable: false),
                    sale_price = table.Column<double>(type: "float", nullable: false),
                    createat = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.idproduct);
                    table.ForeignKey(
                        name: "FK_product_category_idcategory",
                        column: x => x.idcategory,
                        principalTable: "category",
                        principalColumn: "idcategory");
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "idcategory", "description", "profit_margin" },
                values: new object[,]
                {
                    { 1, "Brinquedos", 0.25 },
                    { 2, "Bebidas", 0.29999999999999999 },
                    { 3, "Informática", 0.10000000000000001 },
                    { 4, "Softplan", 0.050000000000000003 },
                    { 5, "Toda e qualquer outra categoria informada", 0.14999999999999999 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_idcategory",
                table: "product",
                column: "idcategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
