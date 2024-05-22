using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Core.Status.Aggregates;
using Task = TodoList.Core.Tasks.Aggregates.Task;

namespace TodoList.Infrastructure.Data.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("TB_STATUS", options =>
            {
                options.HasComment("Tabela com os possíveis status para uma tarefa.");
            }).HasKey(x => x.Id);

            builder.Property(entity => entity.Id)
                   .HasComment("Campo com os valores de chave primária.")
                   .HasColumnName("ID")
                   .HasColumnType("INT")
                   .ValueGeneratedOnAdd();

            builder.Property(entity => entity.Name)
                   .HasComment("Campo com os valores do título da tarefa.")
                   .HasColumnName("TITULO")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(300)
                   .IsRequired();

            builder.HasMany<Task>()
                   .WithOne()
                   .HasForeignKey(entity => entity.StatusId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
        }
    }
}
