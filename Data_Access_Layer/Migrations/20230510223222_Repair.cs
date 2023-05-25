using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    /// <inheritdoc />
    public partial class Repair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Repair",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    kenmerk = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wachtMakers = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    merk = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    aard = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    customerId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    calibernummer = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    kastnummer = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    serienummer = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    mechanism = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    typeBand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repair", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Repair");
        }
    }
}
