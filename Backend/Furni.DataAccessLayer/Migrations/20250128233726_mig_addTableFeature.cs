using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Furni.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_addTableFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    FeatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Features = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.FeatureId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");
        }
    }
}
