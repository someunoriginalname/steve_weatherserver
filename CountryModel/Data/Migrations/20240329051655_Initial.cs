using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CountryModel.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Iso2 = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    Iso3 = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Country__10D160BFC940CCB6", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(18,4)", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Table__F2D21A965FAEB50E", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_City_Country",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "CountryID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryID",
                table: "City",
                column: "CountryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
