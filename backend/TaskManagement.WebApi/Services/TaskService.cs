using Microsoft.EntityFrameworkCore;
using TaskManagement.WebApi.Dtos;
using TaskManagement.WebApi.Models;
using TaskManagement.WebApi.Persistance;

namespace TaskManagement.WebApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly IApplicationDbContext _context;

        public TaskService(IApplicationDbContext context)
        {
            _context = context;
        }

        public int DeleteTask(int id)
        {
            var task = _context.Set<TaskModel>().FirstOrDefault(x => x.Id == id);
            if (task is null)
            {
                return 0;
            }

            var user = _context.Set<UserModel>().Include("Tasks").Include("Categories").FirstOrDefault(x => x.Id == task.UserId);
            if (user is null)
            {
                return 0;
            }
            user.Tasks.Remove(task);

            var category = user.Categories.FirstOrDefault(x => x.Id == task.CategoryId);
            if (category is null)
            {
                return 0;
            }
            category.Tasks.Remove(task);

            _context.Set<TaskModel>().Remove(task);
            _context.SaveChanges();
            return task.Id;
        }

        public TaskModel? GetTask(int id)
        {
            return _context.Set<TaskModel>().FirstOrDefault(x => x.Id == id);
        }

        public List<TaskModel> GetTasks()
        {
            return _context.Set<TaskModel>().ToList();
        }

        public int InsertTask(TaskInsertDto input)
        {
            var task = new TaskModel
            {
                UserId = input.UserId,
                CategoryId = input.CategoryId,
                Name = input.Name,
                Description = (input.Description is null) ? string.Empty : input.Description,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            var user = _context.Set<UserModel>().Include("Categories").Include("Tasks").FirstOrDefault(x => x.Id == input.UserId);
            if (user is null)
            {
                return 0;
            }
            user.Tasks.Add(task);

            if (input.CategoryId != default)
            {
                var category = _context.Set<CategoryModel>().Include("Tasks").FirstOrDefault(x => x.Id == input.CategoryId);
                if (category is null)
                {
                    return 0;
                }
                category.Tasks.Add(task);
            }

            _context.Set<TaskModel>().Add(task);
            _context.SaveChanges();
            return task.Id;
        }

        public int UpdateTask(TaskUpdateDto input)
        {
            var task = _context.Set<TaskModel>().FirstOrDefault(x => x.Id == input.TaskId);
            if (task is null)
            {
                return 0;
            }
            task.Name = input.Name;
            task.Description = (input.Description is null) ? string.Empty : input.Description;
            task.DateModified = DateTime.Now;
            _context.SaveChanges();
            return task.Id;
        }
    }
}
