using Microsoft.EntityFrameworkCore.Migrations;

namespace Kol2.Migrations
{
    public partial class databseNewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Musician",
                columns: new[] { "IdMusician", "FirstName", "LastName", "Nickname" },
                values: new object[] { 4, "Dawid", "Podsiadło", null });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[] { 5, 3.24f, null, "Małomiasteczkowy" });

            migrationBuilder.InsertData(
                table: "Musician_Track",
                columns: new[] { "IdMusician", "IdTrack" },
                values: new object[] { 4, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musician_Track",
                keyColumns: new[] { "IdMusician", "IdTrack" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "Musician",
                keyColumn: "IdMusician",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "IdTrack",
                keyValue: 5);
        }
    }
}
