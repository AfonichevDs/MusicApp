using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MusicApp.API.Migrations
{
    public partial class RequireedFieldsThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Photos_ProfilePhotoId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ProfilePhotoId",
                table: "Users",
                newName: "PhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ProfilePhotoId",
                table: "Users",
                newName: "IX_Users_PhotoId");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Photos_PhotoId",
                table: "Users",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Photos_PhotoId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PhotoId",
                table: "Users",
                newName: "ProfilePhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PhotoId",
                table: "Users",
                newName: "IX_Users_ProfilePhotoId");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Photos_ProfilePhotoId",
                table: "Users",
                column: "ProfilePhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
