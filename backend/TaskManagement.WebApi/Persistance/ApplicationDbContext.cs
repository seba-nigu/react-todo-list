using Microsoft.EntityFrameworkCore;
using TaskManagement.WebApi.Models;

namespace TaskManagement.WebApi.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskCategoryModel> TaskCategories { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        public IQueryable<TEnt> ReadSet<TEnt>() where TEnt : class
        {
            return Set<TEnt>().AsNoTracking();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>().ToTable("Task");
            modelBuilder.Entity<UserModel>().ToTable("User");
            modelBuilder.Entity<TaskCategoryModel>().ToTable("TaskCategory");
            modelBuilder.Entity<CategoryModel>().ToTable("Category");
        }
    }
}
