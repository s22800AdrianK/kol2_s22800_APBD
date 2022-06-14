using Microsoft.EntityFrameworkCore.Migrations;

namespace Kol2.Migrations
{
    public partial class dataUpdateMystakes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Musician_Track",
                columns: new[] { "IdMusician", "IdTrack" },
                values: new object[] { 1, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musician_Track",
                keyColumns: new[] { "IdMusician", "IdTrack" },
                keyValues: new object[] { 1, 4 });
        }
    }
}
