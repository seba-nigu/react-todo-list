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
                    Name = "Seba"
                },
                new UserModel()
                {
                    Name = "Radu"
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
