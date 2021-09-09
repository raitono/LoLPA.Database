using Microsoft.EntityFrameworkCore.Migrations;

namespace LoLPA.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcessError",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerException = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessError", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessorQueue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    IsPriority = table.Column<bool>(type: "bit", nullable: false),
                    ProcessErrorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessorQueue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessorQueue_ProcessError_ProcessErrorId",
                        column: x => x.ProcessErrorId,
                        principalTable: "ProcessError",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessorQueue_ProcessErrorId",
                table: "ProcessorQueue",
                column: "ProcessErrorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessorQueue");

            migrationBuilder.DropTable(
                name: "ProcessError");
        }
    }
}
