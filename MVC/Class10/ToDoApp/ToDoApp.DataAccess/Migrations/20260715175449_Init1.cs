using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2026, 7, 17, 19, 54, 49, 184, DateTimeKind.Local).AddTicks(1012));

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2026, 7, 16, 19, 54, 49, 184, DateTimeKind.Local).AddTicks(1056));

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2026, 7, 15, 19, 54, 49, 184, DateTimeKind.Local).AddTicks(1059));

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 4,
                column: "DueDate",
                value: new DateTime(2026, 7, 18, 19, 54, 49, 184, DateTimeKind.Local).AddTicks(1061));

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 5,
                column: "DueDate",
                value: new DateTime(2026, 7, 15, 19, 54, 49, 184, DateTimeKind.Local).AddTicks(1063));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2026, 7, 17, 19, 49, 16, 273, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2026, 7, 16, 19, 49, 16, 273, DateTimeKind.Local).AddTicks(9885));

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2026, 7, 15, 19, 49, 16, 273, DateTimeKind.Local).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 4,
                column: "DueDate",
                value: new DateTime(2026, 7, 18, 19, 49, 16, 273, DateTimeKind.Local).AddTicks(9890));

            migrationBuilder.UpdateData(
                table: "ToDo",
                keyColumn: "Id",
                keyValue: 5,
                column: "DueDate",
                value: new DateTime(2026, 7, 15, 19, 49, 16, 273, DateTimeKind.Local).AddTicks(9893));
        }
    }
}
