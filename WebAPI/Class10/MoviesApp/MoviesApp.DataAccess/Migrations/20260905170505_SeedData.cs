using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoviesApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "CreatedDate", "FirstName", "LastName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, "Morgan", "Freeman", null },
                    { 2, null, "Tim", "Robbins", null },
                    { 3, null, "Leonardo", "DiCaprio", null },
                    { 4, null, "John", "Travolta", null },
                    { 5, null, "Samuel L.", "Jackson", null },
                    { 6, null, "Uma", "Thurman", null }
                });

            migrationBuilder.InsertData(
                table: "Director",
                columns: new[] { "Id", "CreatedDate", "DateOfBirth", "FirstName", "LastName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1970, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christopher", "Nolan", null },
                    { 2, null, new DateTime(1963, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quentin", "Tarantino", null },
                    { 3, null, null, "Frank", "Darabont", null }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, "Drama", null },
                    { 2, null, "Crime", null },
                    { 3, null, "Sci-Fi", null },
                    { 4, null, "Comedy", null },
                    { 5, null, "Action", null }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "CreatedDate", "Description", "DirectorId", "DurationMinutes", "GenreId", "Title", "UpdatedDate", "Year" },
                values: new object[,]
                {
                    { 1, null, "Two imprisoned men bond over a number of years.", 3, 142, 1, "The Shawshank Redemption", null, 1994 },
                    { 2, null, "The lives of two mob hitmen intertwine.", 2, 154, 2, "Pulp Fiction", null, 1994 },
                    { 3, null, "A thief who steals corporate secrets through dream-sharing.", 1, 148, 3, "Inception", null, 2010 },
                    { 4, null, null, 1, 169, 3, "Interstellar", null, 2014 },
                    { 5, null, "A freed slave sets out to rescue his wife.", 2, 165, 2, "Django Unchained", null, 2012 },
                    { 6, null, "Two detectives hunt a serial killer.", null, 127, 2, "Se7en", null, 1995 },
                    { 7, null, "Batman faces the Joker.", 1, 152, 5, "The Dark Knight", null, 2008 },
                    { 8, null, null, null, 99, 4, "The Grand Budapest Hotel", null, 2014 },
                    { 9, null, "The Bride wakes from a coma and seeks revenge.", 2, 111, 5, "Kill Bill: Vol. 1", null, 2003 }
                });

            migrationBuilder.InsertData(
                table: "MovieActor",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 3, 3 },
                    { 3, 5 },
                    { 5, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 6, 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "MovieActor",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Director",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Director",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Director",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
