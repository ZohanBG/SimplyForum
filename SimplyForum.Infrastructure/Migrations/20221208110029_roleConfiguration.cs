using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplyForum.Infrastructure.Migrations
{
    public partial class roleConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dcc4e7c6-341d-485f-9aac-3de4b724b178", "fa9475d8-a031-4fd2-97e5-88754228e810", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcc4e7c6-341d-485f-9aac-3de4b724b178");
        }
    }
}
