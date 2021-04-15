using Microsoft.EntityFrameworkCore.Migrations;

namespace YourAnimeList.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnimeGenere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnimeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnimeReleaseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnimeStudio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnimeEpisodes = table.Column<int>(type: "int", nullable: false),
                    AnimeRating = table.Column<float>(type: "real", nullable: false),
                    AnimeURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animes");
        }
    }
}
