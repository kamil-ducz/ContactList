using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactList.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fixnamesincontactseeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "eg@gmail.com", "Edgar", "Gold" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "rsapphire@gmail.com", "Roger", "Sapphire" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "john.smith@gmail.com", "John", "Smith" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "john.smith@gmail.com", "John", "Smith" });
        }
    }
}
