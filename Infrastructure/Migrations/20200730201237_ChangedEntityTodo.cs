using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ChangedEntityTodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Todos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Todos",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Todos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Todos");
        }
    }
}
