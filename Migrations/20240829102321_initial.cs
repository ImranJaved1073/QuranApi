using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuranApi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ayah",
                columns: table => new
                {
                    AyaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuraID = table.Column<int>(type: "int", nullable: true),
                    AyaNo = table.Column<int>(type: "int", nullable: true),
                    ArabicText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatehMuhammadJalandhrield = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MehmoodulHassan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrMohsinKhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MuftiTaqiUsmani = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RakuID = table.Column<int>(type: "int", nullable: true),
                    PRakuID = table.Column<int>(type: "int", nullable: true),
                    ParaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayah", x => x.AyaID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ayah");
        }
    }
}
