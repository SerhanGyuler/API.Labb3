using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class PersonInterestDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestLink");

            migrationBuilder.DropTable(
                name: "LinkPerson");

            migrationBuilder.AddColumn<int>(
                name: "InterestId",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PersonInterests",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterests", x => new { x.PersonId, x.InterestId });
                    table.ForeignKey(
                        name: "FK_PersonInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 4, 3 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 5, 4 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 6, 2 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "InterestId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 2, 2 },
                    { 6, 2 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonId_InterestId",
                table: "Links",
                columns: new[] { "PersonId", "InterestId" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_InterestId",
                table: "PersonInterests",
                column: "InterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_PersonInterests_PersonId_InterestId",
                table: "Links",
                columns: new[] { "PersonId", "InterestId" },
                principalTable: "PersonInterests",
                principalColumns: new[] { "PersonId", "InterestId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_PersonInterests_PersonId_InterestId",
                table: "Links");

            migrationBuilder.DropTable(
                name: "PersonInterests");

            migrationBuilder.DropIndex(
                name: "IX_Links_PersonId_InterestId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "InterestId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Links");

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
    }
}
