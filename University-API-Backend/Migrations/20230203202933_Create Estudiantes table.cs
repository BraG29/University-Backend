using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_API_Backend.Migrations
{
    public partial class CreateEstudiantestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fechaNac = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_Estudiantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Usuarios_created_by",
                        column: x => x.created_by,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Usuarios_deleted_by",
                        column: x => x.deleted_by,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Estudiantes_Usuarios_updated_by",
                        column: x => x.updated_by,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CursoEstudiante",
                columns: table => new
                {
                    cursosId = table.Column<int>(type: "int", nullable: false),
                    estudiantesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoEstudiante", x => new { x.cursosId, x.estudiantesId });
                    table.ForeignKey(
                        name: "FK_CursoEstudiante_Cursos_cursosId",
                        column: x => x.cursosId,
                        principalTable: "Cursos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CursoEstudiante_Estudiantes_estudiantesId",
                        column: x => x.estudiantesId,
                        principalTable: "Estudiantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoEstudiante_estudiantesId",
                table: "CursoEstudiante",
                column: "estudiantesId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_created_by",
                table: "Estudiantes",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_deleted_by",
                table: "Estudiantes",
                column: "deleted_by");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_updated_by",
                table: "Estudiantes",
                column: "updated_by");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoEstudiante");

            migrationBuilder.DropTable(
                name: "Estudiantes");
        }
    }
}
