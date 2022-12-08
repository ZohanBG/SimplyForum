using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplyForum.Infrastructure.Migrations
{
    public partial class UserRoleConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcc4e7c6-341d-485f-9aac-3de4b724b178",
                column: "ConcurrencyStamp",
                value: "36316cd3-d764-4747-b34d-743323e6056e");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "dcc4e7c6-341d-485f-9aac-3de4b724b178", "648a1ea7-a0d3-4aba-8316-cd702f2be4d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "477194ee-abb3-40c2-9e5b-9c7222ed600f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da661d77-b8c1-42aa-a0b2-1224d6df9da3", "AQAAAAEAACcQAAAAEBE68sDUdHhJ3pm4nnOZoW0emxiwWLeLPB558cPxcH7t0+VqhXo0rDgpVbUJH3OxBA==", "1185da0b-caa7-48ee-b725-c42037cf097a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "648a1ea7-a0d3-4aba-8316-cd702f2be4d9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f313ee6-1ece-4b4a-a87b-4118bc4ca439", "AQAAAAEAACcQAAAAELqR5D6d0Sc2AbJZ7PsLQwr4Whadt+2HfNGZ0sMnQ9evV7R06J++iFx1yikPs8dplA==", "71d1e353-39f0-44d3-b83b-7fc420341993" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e84bc3c9-cf00-462a-8505-9ae520533e85",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0a52c31-5bab-48dd-a471-d952badddd6f", "AQAAAAEAACcQAAAAEEX8VqVEZZu9e+qWqeEOY0o/NWPEcl7vguiB1BtZ5o671oRMv/HJmiMYTLI6Qeuo7A==", "0ce45662-f9c6-4453-974d-83182b80a34e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dcc4e7c6-341d-485f-9aac-3de4b724b178", "648a1ea7-a0d3-4aba-8316-cd702f2be4d9" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcc4e7c6-341d-485f-9aac-3de4b724b178",
                column: "ConcurrencyStamp",
                value: "b0761886-18f2-4250-a616-c7188d1545e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "477194ee-abb3-40c2-9e5b-9c7222ed600f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a06e10c-f225-4889-bc06-95fa5a615676", "AQAAAAEAACcQAAAAENoFFqczgKBUfZ2fDud79UEXqugAR5i5VR0n7OPiFzU8VccTv35dkEkZ295nPn1SVw==", "848d8ce8-615b-4a14-a842-fc2f2c21ee93" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "648a1ea7-a0d3-4aba-8316-cd702f2be4d9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fdd235c-6aee-4d83-857f-fa8dabc666b9", "AQAAAAEAACcQAAAAELHFuLOSGlxYqpu+jIWEHW6Ct26aAHI4eOuPBuH6nXPlPjBcat9EdzuHGF7kvjJYXw==", "d7632b2e-4280-4418-ad4d-699a9f6194ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e84bc3c9-cf00-462a-8505-9ae520533e85",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0557f2f5-4b1e-4a30-9080-85ffa6a4af4b", "AQAAAAEAACcQAAAAEDqL+yf8XOEFdw9tihMy63Hb1IRKoaFbI5AJJaT6E8YzQcE4tXwFqS0Xe5j29E8xHg==", "b8243275-4f9e-42ea-a116-de11b1e8ce04" });
        }
    }
}
