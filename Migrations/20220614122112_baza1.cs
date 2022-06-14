using Microsoft.EntityFrameworkCore.Migrations;

namespace Kol2.Migrations
{
    public partial class baza1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_Album_IdMusicAlbum",
                table: "Track");

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Album_IdMusicAlbum",
                table: "Track",
                column: "IdMusicAlbum",
                principalTable: "Album",
                principalColumn: "IdAlbum",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_Album_IdMusicAlbum",
                table: "Track");

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Album_IdMusicAlbum",
                table: "Track",
                column: "IdMusicAlbum",
                principalTable: "Album",
                principalColumn: "IdAlbum",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
