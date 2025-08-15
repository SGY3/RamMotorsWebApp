using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RamMotorsWebApp.Migrations
{
    /// <inheritdoc />
    public partial class carsChangeAddedNewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Car",
                newName: "Seats");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerCount",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Displacement",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DriveType",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GroundClearance",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Insurance",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ManufactureYear",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mileage",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Power",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationMonth",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RegistrationYear",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Transmission",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Displacement",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "DriveType",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "GroundClearance",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Insurance",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "ManufactureYear",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Power",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "RegistrationMonth",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "RegistrationYear",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Car");

            migrationBuilder.RenameColumn(
                name: "Seats",
                table: "Car",
                newName: "Year");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerCount",
                table: "Car",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
