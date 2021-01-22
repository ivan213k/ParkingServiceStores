using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingServiceStores.Data.Migrations
{
    public partial class AddedCreatedOnPropertyForAllEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Prices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Prices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Journal",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Journal",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Debts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Debts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Journal");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Journal");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Debts");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Cars");
        }
    }
}
