﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoList.Infrastructure.Data.Contexts;

#nullable disable

namespace TodoList.Api.Migrations
{
    [DbContext(typeof(TodoListContext))]
    partial class TodoListContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TodoList.Core.Status.Aggregates.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("ID")
                        .HasComment("Campo com os valores de chave primária.");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("TITULO")
                        .HasComment("Campo com os valores do título da tarefa.");

                    b.HasKey("Id");

                    b.ToTable("TB_STATUS", null, t =>
                        {
                            t.HasComment("Tabela com os possíveis status para uma tarefa.");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "A fazer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Em andamento"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Revisando"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Concluído"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Bloqueado"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Cancelado"
                        });
                });

            modelBuilder.Entity("TodoList.Core.Tasks.Aggregates.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("ID")
                        .HasComment("Campo com os valores de chave primária.");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValue(new DateTime(2024, 5, 22, 10, 28, 29, 99, DateTimeKind.Local).AddTicks(8125))
                        .HasColumnName("CRIADO_EM")
                        .HasComment("Campo com os valores da data de criação da tarefa.");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("DESCRICAO")
                        .HasComment("Campo com os valores da descrição da tarefa.");

                    b.Property<int>("StatusId")
                        .HasColumnType("INT")
                        .HasColumnName("ID_STATUS")
                        .HasComment("Campo com os valores do status da tarefa.");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("TITULO")
                        .HasComment("Campo com os valores do título da tarefa.");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("TB_TAREFAS", null, t =>
                        {
                            t.HasComment("Tabela de tarefas");
                        });
                });

            modelBuilder.Entity("TodoList.Core.Tasks.Aggregates.Task", b =>
                {
                    b.HasOne("TodoList.Core.Status.Aggregates.Status", null)
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
