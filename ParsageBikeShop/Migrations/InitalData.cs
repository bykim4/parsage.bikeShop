using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parsage.BikeShop.Migrations
{
    public partial class BikeShopMigration : Migration
    {
        private void SeedLookupData(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Manufacturers",
            columns: new[] { "Name" },
            values: new object[] { "Specialized" });

            migrationBuilder.InsertData(
            table: "Manufacturers",
            columns: new[] { "Name" },
            values: new object[] { "Canyon" });

            migrationBuilder.InsertData(
            table: "Manufacturers",
            columns: new[] { "Name" },
            values: new object[] { "GT" });

            migrationBuilder.InsertData(
            table: "Manufacturers",
            columns: new[] { "Name" },
            values: new object[] { "Trek" });
        }
    }
}
