using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Api.Migrations
{
    /// <inheritdoc />
    public partial class DateTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CRIADO_EM",
                table: "TB_TAREFAS",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 25, 14, 35, 3, 393, DateTimeKind.Local).AddTicks(3381),
                comment: "Campo com os valores da data de criação da tarefa.",
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 5, 22, 10, 28, 29, 99, DateTimeKind.Local).AddTicks(8125),
                oldComment: "Campo com os valores da data de criação da tarefa.");

            migrationBuilder.AddColumn<DateTime>(
                name: "ATUALIZADO_EM",
                table: "TB_TAREFAS",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 25, 14, 35, 3, 393, DateTimeKind.Local).AddTicks(3585),
                comment: "Campo com os valores da data de atualização da tarefa.");

            migrationBuilder.AddColumn<DateTime>(
                name: "DATA_ENTREGA",
                table: "TB_TAREFAS",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 25, 14, 35, 3, 393, DateTimeKind.Local).AddTicks(3179),
                comment: "Campo com os valores da data de entrega da tarefa");

            migrationBuilder.AddColumn<DateTime>(
                name: "DATA_INICIO",
                table: "TB_TAREFAS",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 25, 14, 35, 3, 393, DateTimeKind.Local).AddTicks(2838),
                comment: "Campo com os valores da data de início da tarefa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ATUALIZADO_EM",
                table: "TB_TAREFAS");

            migrationBuilder.DropColumn(
                name: "DATA_ENTREGA",
                table: "TB_TAREFAS");

            migrationBuilder.DropColumn(
                name: "DATA_INICIO",
                table: "TB_TAREFAS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CRIADO_EM",
                table: "TB_TAREFAS",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 22, 10, 28, 29, 99, DateTimeKind.Local).AddTicks(8125),
                comment: "Campo com os valores da data de criação da tarefa.",
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 5, 25, 14, 35, 3, 393, DateTimeKind.Local).AddTicks(3381),
                oldComment: "Campo com os valores da data de criação da tarefa.");
        }
    }
}
