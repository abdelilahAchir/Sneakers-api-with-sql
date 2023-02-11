using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sneakersapi.net.Migrations
{
    /// <inheritdoc />
    public partial class _5Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "colors",
                table: "Sneakers");

            migrationBuilder.DropColumn(
                name: "images_urls",
                table: "Sneakers");

            migrationBuilder.DropColumn(
                name: "sizes",
                table: "Sneakers");

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    Sneakerid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Color_Sneakers_Sneakerid",
                        column: x => x.Sneakerid,
                        principalTable: "Sneakers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ImageUrl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    Sneakerid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUrl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageUrl_Sneakers_Sneakerid",
                        column: x => x.Sneakerid,
                        principalTable: "Sneakers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    Sneakerid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Size_Sneakers_Sneakerid",
                        column: x => x.Sneakerid,
                        principalTable: "Sneakers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Color_Sneakerid",
                table: "Color",
                column: "Sneakerid");

            migrationBuilder.CreateIndex(
                name: "IX_ImageUrl_Sneakerid",
                table: "ImageUrl",
                column: "Sneakerid");

            migrationBuilder.CreateIndex(
                name: "IX_Size_Sneakerid",
                table: "Size",
                column: "Sneakerid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "ImageUrl");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.AddColumn<string>(
                name: "colors",
                table: "Sneakers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "images_urls",
                table: "Sneakers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sizes",
                table: "Sneakers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
