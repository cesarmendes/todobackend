using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_TAREFAS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false, comment: "Campo com os valores de chave primária.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITULO = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: false, comment: "Campo com os valores do título da tarefa."),
                    DESCRICAO = table.Column<string>(type: "VARCHAR(3000)", maxLength: 3000, nullable: false, comment: "Campo com os valores da descrição da tarefa."),
                    STATUS = table.Column<int>(type: "INT", nullable: false, comment: "Campo com os valores do status da tarefa."),
                    CRIADO_EM = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2024, 5, 17, 19, 13, 38, 582, DateTimeKind.Local).AddTicks(8867), comment: "Campo com os valores da data de criação da tarefa.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TAREFAS", x => x.ID);
                },
                comment: "Tabela de tarefas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TAREFAS");
        }
    }
}
