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
            var taskModel = new TaskModel
            {
                Name = input.Name,
                Description = input.Description,
                UserId = input.UserId,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            _context.Set<TaskModel>().Add(taskModel);
            _context.SaveChanges();
            return taskModel.Id;
        }

        public void UpdateTask(TaskModel taskModel)
        {
            var task = _context.Set<TaskModel>().FirstOrDefault(x => x.Id == taskModel.Id);
            task.Name = taskModel.Name;
            task.Description = taskModel.Description;
            task.DateModified = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
