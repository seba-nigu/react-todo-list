using TaskManagement.WebApi.Models;

namespace TaskManagement.WebApi.Persistance
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}
