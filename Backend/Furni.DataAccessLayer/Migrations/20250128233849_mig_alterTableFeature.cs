using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Furni.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_alterTableFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Features",
                table: "Features",
                newName: "Feature4");

            migrationBuilder.AddColumn<string>(
                name: "Feature1",
                table: "Features",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Feature2",
                table: "Features",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Feature3",
                table: "Features",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Feature1",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Feature2",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Feature3",
                table: "Features");

            migrationBuilder.RenameColumn(
                name: "Feature4",
                table: "Features",
                newName: "Features");
        }
    }
}
