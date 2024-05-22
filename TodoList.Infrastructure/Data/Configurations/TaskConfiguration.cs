using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = TodoList.Core.Tasks.Aggregates.Task;

namespace TodoList.Infrastructure.Data.Configurations
{
    internal class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("TB_TAREFAS", options => 
            {
                options.HasComment("Tabela de tarefas");
            }).HasKey(x => x.Id);

            builder.Property(entity => entity.Id)
                   .HasComment("Campo com os valores de chave primária.")
                   .HasColumnName("ID")
                   .HasColumnType("INT")
                   .ValueGeneratedOnAdd();

            builder.Property(entity => entity.Title)
                   .HasComment("Campo com os valores do título da tarefa.")
                   .HasColumnName("TITULO")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(300)
                   .IsRequired();

            builder.Property(entity => entity.Description)
                   .HasComment("Campo com os valores da descrição da tarefa.")
                   .HasColumnName("DESCRICAO")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(3000)
                   .IsRequired();

            builder.Property(entity => entity.Status)
                   .HasComment("Campo com os valores do status da tarefa.")
                   .HasColumnName("STATUS")
                   .HasColumnType("INT")
                   .IsRequired();

            builder.Property(entity => entity.CreateAt)
                   .HasComment("Campo com os valores da data de criação da tarefa.")
                   .HasColumnName("CRIADO_EM")
                   .HasColumnType("DATETIME")
                   .HasDefaultValue(DateTime.Now)
                   .IsRequired();
        }
    }
}
