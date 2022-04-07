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

        public void DeleteTask(int id)
        {
            var task = _context.Set<TaskModel>().FirstOrDefault(x => x.Id == id);

            var user = _context.Set<UserModel>().Include("Tasks").Include("Categories").FirstOrDefault(x => x.Id == task.UserId);
            user.Tasks.Remove(task);

            var category = user.Categories.FirstOrDefault(x => x.Id == task.CategoryId);
            category.Tasks.Remove(task);

            _context.Set<TaskModel>().Remove(task);
            _context.SaveChanges();
        }

        public TaskModel GetTask(int id)
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
            user.Tasks.Add(task);

            if (input.CategoryId != default)
            {
                var category = _context.Set<CategoryModel>().Include("Tasks").FirstOrDefault(x => x.Id == input.CategoryId);
                category.Tasks.Add(task);
            }

            _context.Set<TaskModel>().Add(task);
            _context.SaveChanges();
            return task.Id;
        }

        public void UpdateTask(TaskUpdateDto input)
        {
            var task = _context.Set<TaskModel>().FirstOrDefault(x => x.Id == input.TaskId);
            task.Name = input.Name;
            task.Description = (input.Description is null) ? string.Empty : input.Description;
            task.DateModified = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
