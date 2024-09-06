using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProClinics.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95433ac4-2fe9-468f-b80d-b05ec374d1d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "95433ac4-2fe9-468f-b80d-b05ec3724d1d", 0, "e03e969a-6a72-4f33-9a92-862aea585e14", "Receptionist", "proconsulta@hotmail.com.br", true, false, null, "Pro Clinics", "PROCONSULTA@HOTMAIL.COM.BR", "PROCONSULTA@HOTMAIL.COM.BR", "AQAAAAIAAYagAAAAEKPvdWe8YIe+c2rzeTiwGoLlXI7u6oILs/XHCaWOCgmelixsPn07WV/Dat1yRgl+ng==", null, false, "1c795642-1b57-4934-a1dd-c5b2303f4335", false, "proconsulta@hotmail.com.br" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95433ac4-2fe9-468f-b80d-b05ec3724d1d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "95433ac4-2fe9-468f-b80d-b05ec374d1d", 0, "61b35c87-440a-494e-a89a-473d1e40a018", "Receptionist", "proclinics@hotmail.com.br", true, false, null, "Pro Clinics", "PROCONSULTA@HOTMAIL.COM.BR", "PROCONSULTA@HOTMAIL.COM.BR", "AQAAAAIAAYagAAAAEEjoKjmpbjS1CVxQiF+gtoVE+TJn7p7GjCC8a91GdtuiPKPt5iN9bzv3cpYoVNYOog==", null, false, "d951527c-bc6a-4753-b209-80359c09bef6", false, "proconsulta@hotmail.com.br" });
        }
    }
}
