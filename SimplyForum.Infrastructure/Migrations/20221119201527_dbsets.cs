using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplyForum.Infrastructure.Migrations
{
    public partial class dbsets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Community_AspNetUsers_AuthorId",
                table: "Community");

            migrationBuilder.DropForeignKey(
                name: "FK_Community_Category_CategoryId",
                table: "Community");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Community",
                table: "Community");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Community",
                newName: "Communities");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Community_Name",
                table: "Communities",
                newName: "IX_Communities_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Community_CategoryId",
                table: "Communities",
                newName: "IX_Communities_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Community_AuthorId",
                table: "Communities",
                newName: "IX_Communities_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_Type",
                table: "Categories",
                newName: "IX_Categories_Type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Communities",
                table: "Communities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Communities_AspNetUsers_AuthorId",
                table: "Communities",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Communities_Categories_CategoryId",
                table: "Communities",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communities_AspNetUsers_AuthorId",
                table: "Communities");

            migrationBuilder.DropForeignKey(
                name: "FK_Communities_Categories_CategoryId",
                table: "Communities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Communities",
                table: "Communities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Communities",
                newName: "Community");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Communities_Name",
                table: "Community",
                newName: "IX_Community_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Communities_CategoryId",
                table: "Community",
                newName: "IX_Community_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Communities_AuthorId",
                table: "Community",
                newName: "IX_Community_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_Type",
                table: "Category",
                newName: "IX_Category_Type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Community",
                table: "Community",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Community_AspNetUsers_AuthorId",
                table: "Community",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Community_Category_CategoryId",
                table: "Community",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
