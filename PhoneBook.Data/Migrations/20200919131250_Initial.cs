using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBook.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "PhoneBook",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneBook", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Entry",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    PhoneBookID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entry", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Entry_PhoneBook_PhoneBookID",
                        column: x => x.PhoneBookID,
                        principalTable: "PhoneBook",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entry_PhoneBookID",
                table: "Entry",
                column: "PhoneBookID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entry");

            migrationBuilder.DropTable(
                name: "PhoneBook");
        }
    }
}
