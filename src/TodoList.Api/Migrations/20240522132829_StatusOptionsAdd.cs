using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Api.Migrations
{
    /// <inheritdoc />
    public partial class StatusOptionsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CRIADO_EM",
                table: "TB_TAREFAS",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 22, 10, 28, 29, 99, DateTimeKind.Local).AddTicks(8125),
                comment: "Campo com os valores da data de criação da tarefa.",
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 5, 22, 10, 13, 31, 463, DateTimeKind.Local).AddTicks(5576),
                oldComment: "Campo com os valores da data de criação da tarefa.");

            migrationBuilder.UpdateData(
                table: "TB_STATUS",
                keyColumn: "ID",
                keyValue: 1,
                column: "TITULO",
                value: "A fazer");

            migrationBuilder.UpdateData(
                table: "TB_STATUS",
                keyColumn: "ID",
                keyValue: 3,
                column: "TITULO",
                value: "Revisando");

            migrationBuilder.InsertData(
                table: "TB_STATUS",
                columns: new[] { "ID", "TITULO" },
                values: new object[] { 6, "Cancelado" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_STATUS",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CRIADO_EM",
                table: "TB_TAREFAS",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 22, 10, 13, 31, 463, DateTimeKind.Local).AddTicks(5576),
                comment: "Campo com os valores da data de criação da tarefa.",
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 5, 22, 10, 28, 29, 99, DateTimeKind.Local).AddTicks(8125),
                oldComment: "Campo com os valores da data de criação da tarefa.");

            migrationBuilder.UpdateData(
                table: "TB_STATUS",
                keyColumn: "ID",
                keyValue: 1,
                column: "TITULO",
                value: "Pendente");

            migrationBuilder.UpdateData(
                table: "TB_STATUS",
                keyColumn: "ID",
                keyValue: 3,
                column: "TITULO",
                value: "Em testes");
        }
    }
}
