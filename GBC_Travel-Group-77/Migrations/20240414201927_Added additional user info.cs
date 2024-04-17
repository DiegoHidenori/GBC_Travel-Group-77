using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GBC_Travel_Group_77.Migrations
{
    /// <inheritdoc />
    public partial class Addedadditionaluserinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessibilityNeeds",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Biography",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                schema: "Identity",
                table: "User",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContact",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RewardsProgram",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SeatPreference",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessibilityNeeds",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Biography",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EmergencyContact",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RewardsProgram",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SeatPreference",
                schema: "Identity",
                table: "User");
        }
    }
}
