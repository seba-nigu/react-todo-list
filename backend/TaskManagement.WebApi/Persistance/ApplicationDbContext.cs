using Microsoft.EntityFrameworkCore;
using TaskManagement.WebApi.Models;

namespace TaskManagement.WebApi.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<TaskCategoryModel> TaskCategories { get; set; }

        public IQueryable<TEnt> ReadSet<TEnt>() where TEnt : class
        {
            return Set<TEnt>().AsNoTracking();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("User");
            modelBuilder.Entity<CategoryModel>().ToTable("Category");
            modelBuilder.Entity<TaskModel>().ToTable("Task");
            modelBuilder.Entity<TaskCategoryModel>().ToTable("TaskCategory");
        }
    }
}
