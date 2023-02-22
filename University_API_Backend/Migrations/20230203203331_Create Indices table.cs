using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_API_Backend.Migrations
{
    public partial class CreateIndicestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "indiceId",
                table: "Cursos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Indices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idCurso = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Indices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indices_Usuarios_created_by",
                        column: x => x.created_by,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Indices_Usuarios_deleted_by",
                        column: x => x.deleted_by,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Indices_Usuarios_updated_by",
                        column: x => x.updated_by,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_indiceId",
                table: "Cursos",
                column: "indiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Indices_created_by",
                table: "Indices",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Indices_deleted_by",
                table: "Indices",
                column: "deleted_by");

            migrationBuilder.CreateIndex(
                name: "IX_Indices_updated_by",
                table: "Indices",
                column: "updated_by");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Indices_indiceId",
                table: "Cursos",
                column: "indiceId",
                principalTable: "Indices",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Indices_indiceId",
                table: "Cursos");

            migrationBuilder.DropTable(
                name: "Indices");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_indiceId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "indiceId",
                table: "Cursos");
        }
    }
}
