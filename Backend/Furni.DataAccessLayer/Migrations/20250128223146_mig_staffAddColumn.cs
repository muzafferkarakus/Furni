using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Furni.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_staffAddColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Staff",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Staff");
        }
    }
}
