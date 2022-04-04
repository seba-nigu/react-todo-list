using TaskManagement.WebApi.Dtos;
using TaskManagement.WebApi.Models;

namespace TaskManagement.WebApi.Services
{
    public interface ITaskService
    {
        List<TaskModel> GetTasks();
        TaskModel GetTask(int id);
        int InsertTask(TaskInsertDto input);
        void UpdateTask(TaskModel taskModel);
        void DeleteTask(int id);
    }
}
