using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_API_Backend.Migrations
{
    public partial class CreateCategoriatable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_by = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_Usuarios_created_by",
                        column: x => x.created_by,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categorias_Usuarios_deleted_by",
                        column: x => x.deleted_by,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categorias_Usuarios_updated_by",
                        column: x => x.updated_by,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoriaCurso",
                columns: table => new
                {
                    categoriasId = table.Column<int>(type: "int", nullable: false),
                    cursosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaCurso", x => new { x.categoriasId, x.cursosId });
                    table.ForeignKey(
                        name: "FK_CategoriaCurso_Categorias_categoriasId",
                        column: x => x.categoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoriaCurso_Cursos_cursosId",
                        column: x => x.cursosId,
                        principalTable: "Cursos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaCurso_cursosId",
                table: "CategoriaCurso",
                column: "cursosId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_created_by",
                table: "Categorias",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_deleted_by",
                table: "Categorias",
                column: "deleted_by");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_updated_by",
                table: "Categorias",
                column: "updated_by");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaCurso");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
