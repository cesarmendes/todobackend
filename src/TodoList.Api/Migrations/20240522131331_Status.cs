using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoList.Api.Migrations
{
    /// <inheritdoc />
    public partial class Status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "STATUS",
                table: "TB_TAREFAS",
                newName: "ID_STATUS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CRIADO_EM",
                table: "TB_TAREFAS",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 22, 10, 13, 31, 463, DateTimeKind.Local).AddTicks(5576),
                comment: "Campo com os valores da data de criação da tarefa.",
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 5, 17, 19, 13, 38, 582, DateTimeKind.Local).AddTicks(8867),
                oldComment: "Campo com os valores da data de criação da tarefa.");

            migrationBuilder.CreateTable(
                name: "TB_STATUS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false, comment: "Campo com os valores de chave primária.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITULO = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: false, comment: "Campo com os valores do título da tarefa.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_STATUS", x => x.ID);
                },
                comment: "Tabela com os possíveis status para uma tarefa.");

            migrationBuilder.InsertData(
                table: "TB_STATUS",
                columns: new[] { "ID", "TITULO" },
                values: new object[,]
                {
                    { 1, "Pendente" },
                    { 2, "Em andamento" },
                    { 3, "Em testes" },
                    { 4, "Concluído" },
                    { 5, "Bloqueado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_TAREFAS_ID_STATUS",
                table: "TB_TAREFAS",
                column: "ID_STATUS");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TAREFAS_TB_STATUS_ID_STATUS",
                table: "TB_TAREFAS",
                column: "ID_STATUS",
                principalTable: "TB_STATUS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_TAREFAS_TB_STATUS_ID_STATUS",
                table: "TB_TAREFAS");

            migrationBuilder.DropTable(
                name: "TB_STATUS");

            migrationBuilder.DropIndex(
                name: "IX_TB_TAREFAS_ID_STATUS",
                table: "TB_TAREFAS");

            migrationBuilder.RenameColumn(
                name: "ID_STATUS",
                table: "TB_TAREFAS",
                newName: "STATUS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CRIADO_EM",
                table: "TB_TAREFAS",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 17, 19, 13, 38, 582, DateTimeKind.Local).AddTicks(8867),
                comment: "Campo com os valores da data de criação da tarefa.",
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 5, 22, 10, 13, 31, 463, DateTimeKind.Local).AddTicks(5576),
                oldComment: "Campo com os valores da data de criação da tarefa.");
        }
    }
}
