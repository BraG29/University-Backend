using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_API_Backend.Migrations
{
    public partial class UpdateCreatedbyUpdatedbyDeletedby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Cursos");

            migrationBuilder.AddColumn<int>(
                name: "created_by",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "deleted_by",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "updated_by",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "created_by",
                table: "Cursos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "deleted_by",
                table: "Cursos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "updated_by",
                table: "Cursos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_created_by",
                table: "Usuarios",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_deleted_by",
                table: "Usuarios",
                column: "deleted_by");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_updated_by",
                table: "Usuarios",
                column: "updated_by");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_created_by",
                table: "Cursos",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_deleted_by",
                table: "Cursos",
                column: "deleted_by");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_updated_by",
                table: "Cursos",
                column: "updated_by");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Usuarios_created_by",
                table: "Cursos",
                column: "created_by",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Usuarios_deleted_by",
                table: "Cursos",
                column: "deleted_by",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Usuarios_updated_by",
                table: "Cursos",
                column: "updated_by",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_created_by",
                table: "Usuarios",
                column: "created_by",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_deleted_by",
                table: "Usuarios",
                column: "deleted_by",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_updated_by",
                table: "Usuarios",
                column: "updated_by",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Usuarios_created_by",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Usuarios_deleted_by",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Usuarios_updated_by",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_created_by",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_deleted_by",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_updated_by",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_created_by",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_deleted_by",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_updated_by",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_created_by",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_deleted_by",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_updated_by",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "Cursos");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Cursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Cursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Cursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
