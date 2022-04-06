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
            _context.SaveChanges();

            var _user = _context.Set<UserModel>().FirstOrDefault(x => x.Id == task.UserId);
            _user.Tasks.Remove(task);

            foreach (var categoryId in task.CategoryIds)
            {
                var _category = _user.Categories.FirstOrDefault(x => x.Id == categoryId);
                _category.TaskIds.Remove(task.Id);
            }
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
                Description = input.Description,
                UserId = input.UserId,
                CategoryIds = input.CategoryIds,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            _context.Set<TaskModel>().Add(task);
            _context.SaveChanges();

            var _user = _context.Set<UserModel>().FirstOrDefault(x => x.Id == input.UserId);
            _user.Tasks.Add(task);

            foreach (var categoryId in input.CategoryIds)
            {
                var _category = _user.Categories.FirstOrDefault(x => x.Id == categoryId);
                _category.TaskIds.Add(task.Id);
            }

            return task.Id;
        }

        public void UpdateTask(TaskModel task)
        {
            var _task = _context.Set<TaskModel>().FirstOrDefault(x => x.Id == task.Id);
            _task.Name = task.Name;
            _task.Description = task.Description;
            _task.DateModified = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
