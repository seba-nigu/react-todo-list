using TaskManagement.WebApi.Dtos;
using TaskManagement.WebApi.Models;

namespace TaskManagement.WebApi.Services
{
    public interface ITaskService
    {
        List<TaskModel> GetTasks();
        TaskModel GetTask(int id);
        int InsertTask(TaskInsertDto input);
        void UpdateTask(TaskUpdateDto input);
        void DeleteTask(int id);
    }
}
