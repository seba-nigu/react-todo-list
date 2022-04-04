using TaskManagement.WebApi.Models;

namespace TaskManagement.WebApi.Persistance
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Tasks.Any())
            {
                return;
            }

            var _tasks = new List<TaskModel>()
            {
                new TaskModel
                {
                    Name = "Coding",
                    User = new()
                    {
                        Name = "John Doe"
                    },
                    Description = "Some Description"
                },

                new TaskModel
                {
                    Name = "Coding Review",
                    User = new()
                    {
                        Name = "Jane Doe"
                    },
                    Description = "Some Description"
                }
            };

            foreach (var task in _tasks)
            {
                context.Tasks.Add(task);
            }

            context.SaveChanges();
        }
    }
}
