using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCarBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("886f92ab-b258-45b0-9b41-962c6ec8d0aa"), "BMW", 1 },
                    { new Guid("95f8ea5d-22ce-491a-a763-8b5c1c73ac90"), "AUDI", 1 },
                    { new Guid("e2d2f8e7-6c66-4067-8b96-1a6ce92d586a"), "TOYOTA", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brand_Id",
                table: "Brand",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
