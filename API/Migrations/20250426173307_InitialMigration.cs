using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterestLink",
                columns: table => new
                {
                    InterestsId = table.Column<int>(type: "int", nullable: false),
                    LinksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestLink", x => new { x.InterestsId, x.LinksId });
                    table.ForeignKey(
                        name: "FK_InterestLink_Interests_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestLink_Links_LinksId",
                        column: x => x.LinksId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkPerson",
                columns: table => new
                {
                    LinksId = table.Column<int>(type: "int", nullable: false),
                    PersonsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkPerson", x => new { x.LinksId, x.PersonsId });
                    table.ForeignKey(
                        name: "FK_LinkPerson_Links_LinksId",
                        column: x => x.LinksId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkPerson_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Att ta bilder med kamera", "Fotografi" },
                    { 2, "Att laga god mat", "Matlagning" },
                    { 3, "Att skriva kod i olika språk", "Programmering" },
                    { 4, "Upptäcka nya platser", "Resa" },
                    { 5, "Lyssna och skapa musik", "Musik" },
                    { 6, "Hålla kroppen i form", "Träning" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "Url" },
                values: new object[,]
                {
                    { 1, "https://se.pinterest.com/" },
                    { 2, "https://www.w3schools.com/" },
                    { 3, "https://recept.se/" },
                    { 4, "https://www.momondo.se/" },
                    { 5, "https://spotify.com/" },
                    { 6, "https://nordicwellness.se/" },
                    { 7, "https://codecademy.com/" },
                    { 8, "https://music.amazon.com/" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Alice Andersson", "0701234567" },
                    { 2, "Bob Berg", "0727654321" },
                    { 3, "Carla Carlsson", "0739876543" },
                    { 4, "David Dahl", "0761122334" }
                });

            migrationBuilder.InsertData(
                table: "InterestLink",
                columns: new[] { "InterestsId", "LinksId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 3 },
                    { 3, 2 },
                    { 3, 7 },
                    { 4, 4 },
                    { 5, 5 },
                    { 5, 8 },
                    { 6, 6 }
                });

            migrationBuilder.InsertData(
                table: "LinkPerson",
                columns: new[] { "LinksId", "PersonsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 },
                    { 6, 2 },
                    { 7, 3 },
                    { 8, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestLink_LinksId",
                table: "InterestLink",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkPerson_PersonsId",
                table: "LinkPerson",
                column: "PersonsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestLink");

            migrationBuilder.DropTable(
                name: "LinkPerson");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
