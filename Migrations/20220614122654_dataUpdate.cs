using Microsoft.EntityFrameworkCore.Migrations;

namespace Kol2.Migrations
{
    public partial class dataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[] { 4, 3.24f, null, "Ortalion" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "IdTrack",
                keyValue: 4);
        }
    }
}
