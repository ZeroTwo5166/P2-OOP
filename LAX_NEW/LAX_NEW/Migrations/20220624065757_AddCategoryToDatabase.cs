using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAX_NEW.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Film_Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instruktør = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Årstal = table.Column<int>(type: "int", nullable: false),
                    Detaljer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
