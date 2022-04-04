using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.WebApi.Models;

namespace TaskManagement.WebApi.Persistance.Configurations
{
    public class TaskCategoryModelConfiguration : IEntityTypeConfiguration<TaskCategoryModel>
    {
        public void Configure(EntityTypeBuilder<TaskCategoryModel> builder)
        {
            builder.HasOne(t => t.Category)
                .WithMany(t => t.TaskCategory)
                .HasForeignKey(t => t.Category.Id)
                .HasConstraintName("FK_TaskCategory_Category");

            builder.HasOne(t => t.Task)
                .WithMany(t => t.TaskCategory)
                .HasForeignKey(t => t.Task.Id)
                .HasConstraintName("FK_TaskCategory_Task");
        }
    }
}
