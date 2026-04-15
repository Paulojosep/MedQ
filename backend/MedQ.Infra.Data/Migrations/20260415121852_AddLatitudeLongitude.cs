using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedQ.Infra.Data.Migrations
{
    public partial class AddLatitudeLongitude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "latitude",
                table: "tb_estabelecimento",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "longitude",
                table: "tb_estabelecimento",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "latitude",
                table: "tb_estabelecimento");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "tb_estabelecimento");
        }
    }
}
