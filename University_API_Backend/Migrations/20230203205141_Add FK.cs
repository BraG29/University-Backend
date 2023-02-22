using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_API_Backend.Migrations
{
    public partial class AddFK : Migration
    {
        

        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddForeignKey(
                name: "FK_Indices_Cursos_idCurso",
                table: "Indices",
                column: "idCurso",
                principalTable: "Cursos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
