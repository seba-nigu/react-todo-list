using Microsoft.AspNetCore.Mvc;
using TaskManagement.WebApi.Dtos;
using TaskManagement.WebApi.Models;
using TaskManagement.WebApi.Services;

namespace TaskManagement.WebApi.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskModel>> Get()
        {
            return _taskService.GetTasks();
        }

        [HttpGet]
        [Route("{taskId}")]
        public ActionResult<TaskModel> Get(int taskId)
        {
            return _taskService.GetTask(taskId);
        }

        [HttpPost]
        public ActionResult<int> Post(TaskInsertDto input)
        {
            return _taskService.InsertTask(input);
        }

        [HttpPut]
        public void Put(TaskModel taskModel)
        {
            _taskService.UpdateTask(taskModel);
        }

        [HttpDelete]
        [Route("{taskId}")]
        public void Delete(int taskId)
        {
            _taskService.DeleteTask(taskId);
        }
    }
}
