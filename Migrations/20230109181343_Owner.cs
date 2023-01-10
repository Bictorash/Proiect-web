using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inchiriere_Instrumente.Migrations
{
    public partial class Owner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerID",
                table: "Instrument",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instrument_OwnerID",
                table: "Instrument",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instrument_Owner_OwnerID",
                table: "Instrument",
                column: "OwnerID",
                principalTable: "Owner",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instrument_Owner_OwnerID",
                table: "Instrument");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropIndex(
                name: "IX_Instrument_OwnerID",
                table: "Instrument");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Instrument");
        }
    }
}
