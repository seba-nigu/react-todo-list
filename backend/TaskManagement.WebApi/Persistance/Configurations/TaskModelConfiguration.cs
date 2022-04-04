using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.WebApi.Models;

namespace TaskManagement.WebApi.Persistance.Configurations
{
    public class TaskModelConfiguration : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            builder.HasOne(t => t.User)
                .WithMany(t => t.Task)
                .HasForeignKey(t => t.User.Id)
                .HasConstraintName("FK_Task_User");
        }
    }
}
