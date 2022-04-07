using Microsoft.EntityFrameworkCore;
using System.Linq;
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
            _context.Set<TaskModel>().Remove(task);

            var user = _context.Set<UserModel>().FirstOrDefault(x => x.Id == task.UserId);
            user.Tasks.Remove(task);

            foreach (var categoryId in task.CategoryIds)
            {
                var category = user.Categories.FirstOrDefault(x => x.Id == categoryId);
                category.TaskIds.Remove(task.Id);
            }

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
                Name = input.Name,
                Description = (input.Description is null) ? string.Empty : input.Description,
                UserId = input.UserId,
                CategoryIds = (input.CategoryIds is null) ? new List<int>() : input.CategoryIds,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            _context.Set<TaskModel>().Add(task);

            var user = _context.Set<UserModel>().Include("Tasks").Include("Categories").FirstOrDefault(x => x.Id == input.UserId);
            user.Tasks.Add(task);

            foreach (var categoryId in input.CategoryIds)
            {
                var category = user.Categories.FirstOrDefault(x => x.Id == categoryId);
                category.TaskIds.Add(task.Id);
            }

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
