using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Furni.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_contactAddColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Contacts");
        }
    }
}
