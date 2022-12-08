using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplyForum.Infrastructure.Migrations
{
    public partial class CategoryConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcc4e7c6-341d-485f-9aac-3de4b724b178",
                column: "ConcurrencyStamp",
                value: "e14da5b3-38e2-4fa4-a830-7745665d9c11");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "477194ee-abb3-40c2-9e5b-9c7222ed600f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1126a8be-3614-4a65-bc96-c09778ee55fe", "AQAAAAEAACcQAAAAELN45I9MV2dIfNxEEmpShGl9JuOGGUmjEvW4NNr/Gtl/JjOPJWbhDSv9E2KtDLToMg==", "62816765-3aaa-4beb-be0f-c758f722050f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "648a1ea7-a0d3-4aba-8316-cd702f2be4d9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f69116f-5d12-4283-93e7-a5e23fd5a36e", "AQAAAAEAACcQAAAAEPj5167bRqAMQZ9FhzlBg2SdCDYurv8ToGwpLDad1QfLZrV8tz1VCwUQESu7/D3UgA==", "fa8aec0d-0526-4bec-97a7-e43d2e905c87" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e84bc3c9-cf00-462a-8505-9ae520533e85",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f01b1c0-3665-4c67-ba75-a689c482cfc6", "AQAAAAEAACcQAAAAEG8YpGFZkTHXYlxT9aST8rXUl29d5iJgkQTdNjJOPjy5TvmUbCZP1wn+yVvjW9us2A==", "d09a1693-3fad-4780-881b-bae3a49b946d" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("52bf3597-b6d0-4959-b922-ce3f1d6d2e94"), "Gaming" },
                    { new Guid("b1bf132f-a3f7-4abd-9433-fd82768a2bc7"), "Random" },
                    { new Guid("f4863175-b536-4d9c-8fcd-9230c9a48cf1"), "Music" },
                    { new Guid("f579f2a3-0573-49f0-b0b5-efa8f52bbbf9"), "Funny" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("52bf3597-b6d0-4959-b922-ce3f1d6d2e94"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b1bf132f-a3f7-4abd-9433-fd82768a2bc7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f4863175-b536-4d9c-8fcd-9230c9a48cf1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f579f2a3-0573-49f0-b0b5-efa8f52bbbf9"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcc4e7c6-341d-485f-9aac-3de4b724b178",
                column: "ConcurrencyStamp",
                value: "36316cd3-d764-4747-b34d-743323e6056e");

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
    }
}
