using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QualityMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class AddWaterQuality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WaterQuality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Timestamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PH = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Turbidity = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DissolvedOxygen = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterQuality", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaterQuality");
        }
    }
}
