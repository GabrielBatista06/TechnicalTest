using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Technical_Test_DHB.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombrePlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cuota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EdadMinima = table.Column<int>(type: "int", nullable: false),
                    EdadMaxima = table.Column<int>(type: "int", nullable: false),
                    TipoSeguro = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seguros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoSeguro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoSeguro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoCuentaFinanciera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroCuentaFinanciera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorCuota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seguros_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "Id", "CodigoPlan", "Cuota", "EdadMaxima", "EdadMinima", "NombrePlan", "TipoSeguro" },
                values: new object[,]
                {
                    { 1, "A05", 675.00m, 59, 18, "Plan 1", "MRE" },
                    { 2, "A04", 472.50m, 59, 18, "Plan 2", "MRE" },
                    { 3, "A1B", 141.00m, 65, 18, "Plan A1", "MAE" },
                    { 4, "A1C", 235.00m, 65, 18, "Plan A2", "MAE" },
                    { 5, "M11", 47.00m, 30, 18, "Plan BA1", "MNF" },
                    { 6, "M10", 53.00m, 30, 18, "Plan BA2", "MNF" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seguros_ClienteId",
                table: "Seguros",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Seguros");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
