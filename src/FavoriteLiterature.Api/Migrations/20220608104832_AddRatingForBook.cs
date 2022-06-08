using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FavoriteLiterature.Api.Migrations
{
    public partial class AddRatingForBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Rating",
                schema: "favoriteLiterature",
                table: "Books",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                schema: "favoriteLiterature",
                table: "Books");
        }
    }
}
