using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoLPA.Database.Migrations.Riot
{
    public partial class InitialCreateRiot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Summoners",
                columns: table => new
                {
                    Puuid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevisionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summoners", x => x.Puuid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Summoners");
        }
    }
}
