using TaskManagement.WebApi.Models;

namespace TaskManagement.WebApi.Persistance
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var users = new List<UserModel>()
            {
                new UserModel()
                {
                    Name = "Seba",
                    Tasks = new List<TaskModel>(),
                    Categories = new List<CategoryModel>(),
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                },
                new UserModel()
                {
                    Name = "Radu",
                    Tasks = new List<TaskModel>(),
                    Categories = new List<CategoryModel>(),
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                }
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}
