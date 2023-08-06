using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactList.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Hashpasswordsforseededdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$st9HA1vEJWUbO5dKIcVZnO5c.6K2kDJJk04Czx7Br7RrottVW3z7u");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$3DPm5qcUBmjKY083tGBWzur3WSCMEThkohpmDz4h35FTT1cSX0cMq");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$5NRWhHQw5gWHSoh42AuGcexBHzfCTUJZAdsH83BgEHXlxbmaO/7Ui");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$cpDZ2XKcZRbKmKj9bfNAzuE0cYmiR73xleYF2iFzXdyvyesHhNu8e");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "Ex@mpleP@$$sowrd");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "Ex@mpleP@$$sowrd1");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "Ex@mpleP@$$sowrd2");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "Ex@mpleP@$$sowrd3");
        }
    }
}
