using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseImplement.Migrations
{
    public partial class Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Waiters_WaiterId",
                table: "Bills");

            migrationBuilder.DropTable(
                name: "Waiters");

            migrationBuilder.DropIndex(
                name: "IX_Bills_WaiterId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "WaiterId",
                table: "Bills");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Bills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WaiterFullName",
                table: "Bills",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_TypeId",
                table: "Bills",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Types_TypeId",
                table: "Bills",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Types_TypeId",
                table: "Bills");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Bills_TypeId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "WaiterFullName",
                table: "Bills");

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WaiterId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Waiters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaiterFullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waiters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_WaiterId",
                table: "Bills",
                column: "WaiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Waiters_WaiterId",
                table: "Bills",
                column: "WaiterId",
                principalTable: "Waiters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
