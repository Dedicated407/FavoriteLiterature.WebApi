using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FavoriteLiterature.Api.Migrations
{
    public partial class AddIdForBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "favoriteLiterature",
                table: "Statuses",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                schema: "favoriteLiterature",
                table: "Critics",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "current_timestamp");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Updated",
                schema: "favoriteLiterature",
                table: "Critics",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                schema: "favoriteLiterature",
                table: "Authors",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "current_timestamp");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Updated",
                schema: "favoriteLiterature",
                table: "Authors",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                schema: "favoriteLiterature",
                table: "Critics");

            migrationBuilder.DropColumn(
                name: "Updated",
                schema: "favoriteLiterature",
                table: "Critics");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "favoriteLiterature",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Updated",
                schema: "favoriteLiterature",
                table: "Authors");

            migrationBuilder.AlterColumn<byte>(
                name: "Id",
                schema: "favoriteLiterature",
                table: "Statuses",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
