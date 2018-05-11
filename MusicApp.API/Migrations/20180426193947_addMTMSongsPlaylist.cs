using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MusicApp.API.Migrations
{
    public partial class addMTMSongsPlaylist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "Songs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_SongId",
                table: "Songs",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Songs_SongId",
                table: "Songs",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Songs_SongId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_SongId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "Songs");
        }
    }
}
