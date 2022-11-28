using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplyForum.Infrastructure.Migrations
{
    public partial class PostReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostReport_AspNetUsers_AuthorId",
                table: "PostReport");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReport_Posts_PostId",
                table: "PostReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostReport",
                table: "PostReport");

            migrationBuilder.RenameTable(
                name: "PostReport",
                newName: "PostsReports");

            migrationBuilder.RenameIndex(
                name: "IX_PostReport_PostId",
                table: "PostsReports",
                newName: "IX_PostsReports_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_PostReport_AuthorId",
                table: "PostsReports",
                newName: "IX_PostsReports_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostsReports",
                table: "PostsReports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostsReports_AspNetUsers_AuthorId",
                table: "PostsReports",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostsReports_Posts_PostId",
                table: "PostsReports",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostsReports_AspNetUsers_AuthorId",
                table: "PostsReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PostsReports_Posts_PostId",
                table: "PostsReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostsReports",
                table: "PostsReports");

            migrationBuilder.RenameTable(
                name: "PostsReports",
                newName: "PostReport");

            migrationBuilder.RenameIndex(
                name: "IX_PostsReports_PostId",
                table: "PostReport",
                newName: "IX_PostReport_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_PostsReports_AuthorId",
                table: "PostReport",
                newName: "IX_PostReport_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostReport",
                table: "PostReport",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReport_AspNetUsers_AuthorId",
                table: "PostReport",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReport_Posts_PostId",
                table: "PostReport",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }
    }
}
