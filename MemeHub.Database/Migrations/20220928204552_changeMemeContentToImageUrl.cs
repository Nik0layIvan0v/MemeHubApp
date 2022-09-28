using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemeHub.Database.Migrations
{
    public partial class changeMemeContentToImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Memes");

            migrationBuilder.AlterColumn<int>(
                name: "LabelId",
                table: "Memes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "Memes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Memes");

            migrationBuilder.AlterColumn<int>(
                name: "LabelId",
                table: "Memes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "Memes",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
