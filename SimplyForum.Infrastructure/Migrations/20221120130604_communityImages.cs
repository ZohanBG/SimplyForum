using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplyForum.Infrastructure.Migrations
{
    public partial class communityImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "BannerImage",
                table: "Communities",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "CommunityImage",
                table: "Communities",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BannerImage",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "CommunityImage",
                table: "Communities");
        }
    }
}
