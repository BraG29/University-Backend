using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_API_Backend.Migrations
{
    public partial class UpdateBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Usuarios_created_by",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Usuarios_created_by",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Usuarios_created_by",
                table: "Estudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Indices_Usuarios_created_by",
                table: "Indices");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_created_by",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "created_by",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "created_by",
                table: "Indices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "created_by",
                table: "Estudiantes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "created_by",
                table: "Cursos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "created_by",
                table: "Categorias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Usuarios_created_by",
                table: "Categorias",
                column: "created_by",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Usuarios_created_by",
                table: "Cursos",
                column: "created_by",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Usuarios_created_by",
                table: "Estudiantes",
                column: "created_by",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Indices_Usuarios_created_by",
                table: "Indices",
                column: "created_by",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_created_by",
                table: "Usuarios",
                column: "created_by",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Usuarios_created_by",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Usuarios_created_by",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Usuarios_created_by",
                table: "Estudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Indices_Usuarios_created_by",
                table: "Indices");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_created_by",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "created_by",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "created_by",
                table: "Indices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "created_by",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "created_by",
                table: "Cursos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "created_by",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Usuarios_created_by",
                table: "Categorias",
                column: "created_by",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Usuarios_created_by",
                table: "Cursos",
                column: "created_by",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Usuarios_created_by",
                table: "Estudiantes",
                column: "created_by",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Indices_Usuarios_created_by",
                table: "Indices",
                column: "created_by",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_created_by",
                table: "Usuarios",
                column: "created_by",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
