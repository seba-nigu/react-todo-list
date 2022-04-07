using TaskManagement.WebApi.Dtos;
using TaskManagement.WebApi.Models;

namespace TaskManagement.WebApi.Services
{
    public interface ITaskService
    {
        HashSet<TaskModel> GetTasks();
        TaskModel? GetTask(int id);
        int InsertTask(TaskInsertDto input);
        int UpdateTask(TaskUpdateDto input);
        int DeleteTask(int id);
    }
}
