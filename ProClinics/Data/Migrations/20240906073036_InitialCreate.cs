using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProClinics.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95433ac4-2fe9-468f-b80d-b05ec3724d1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b8ecb3a-8a44-4503-80ea-3c866cf441ad", "AQAAAAIAAYagAAAAEElt4G8rBEm/W4LOosr7b95J2uPRJx2v8ahkSWbOeOhYmtzM6Eh98B88KW+CYk3DKg==", "6231dc72-d573-4391-9d9a-30524952bd4b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95433ac4-2fe9-468f-b80d-b05ec3724d1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8834174b-60ca-40bf-a714-f2081636b1dc", "AQAAAAIAAYagAAAAEEDVbtyuFV5W2YEuXhd/mqzdb9AFiDvevR5oURUfkX+ujaLN9AiwIKZXsVLTqHetdA==", "2d2774c8-b8ac-42ee-a262-82d5eb956476" });
        }
    }
}
