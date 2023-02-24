using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Szarnapomvan.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BadLevel = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    LocationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Budapest" },
                    { 2L, "Baranya megye" },
                    { 3L, "Bács-Kiskun megye" },
                    { 4L, "Békés megye" },
                    { 5L, "Borsod-Abaúj-Zemplén megye" },
                    { 6L, "Csongrád-Csanád megye" },
                    { 7L, "Fejér megye" },
                    { 8L, "Győr-Moson-Sopron megye" },
                    { 9L, "Hajdú-Bihar megye" },
                    { 10L, "Heves megye" },
                    { 11L, "Jász-Nagykun-Szolnok megye" },
                    { 12L, "Komárom-Esztergom megye" },
                    { 13L, "Nógrád megye" },
                    { 14L, "Pest megye" },
                    { 15L, "Somogy megye" },
                    { 16L, "Szabolcs-Szatmár-Bereg megye" },
                    { 17L, "Tolna megye" },
                    { 18L, "Vas megye" },
                    { 19L, "Veszprém megye" },
                    { 20L, "Zala megye" },
                    { 21L, "Egyéb" },
                    { 22L, "Külföld" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_LocationId",
                table: "Posts",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
