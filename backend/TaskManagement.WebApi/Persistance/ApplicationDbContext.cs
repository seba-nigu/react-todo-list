using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using TaskManagement.WebApi.Models;

namespace TaskManagement.WebApi.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        public IQueryable<TEnt> ReadSet<TEnt>() where TEnt : class
        {
            return Set<TEnt>().AsNoTracking();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>()
                .Property(x => x.TaskIds)
                .HasConversion(new ValueConverter<ICollection<int>, string>(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<ICollection<int>>(v)));

            modelBuilder.Entity<TaskModel>()
                .Property(x => x.CategoryIds)
                .HasConversion(new ValueConverter<ICollection<int>, string>(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<ICollection<int>>(v)));

            modelBuilder.Entity<UserModel>().ToTable("User");
            modelBuilder.Entity<CategoryModel>().ToTable("Category");
            modelBuilder.Entity<CategoryModel>().ToTable("Task");
        }
    }
}
