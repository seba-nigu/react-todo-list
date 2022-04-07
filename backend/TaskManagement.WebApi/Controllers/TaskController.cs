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
            var result = _taskService.GetTask(taskId);
            return (result is null) ? new EmptyResult() : result;
        }

        [HttpPost]
        public ActionResult<int> Post(TaskInsertDto input)
        {
            var result = _taskService.InsertTask(input);
            return (result == 0) ? new EmptyResult() : result;
        }

        [HttpPut]
        public ActionResult<int> Put(TaskUpdateDto input)
        {
            var result = _taskService.UpdateTask(input);
            return (result == 0) ? new EmptyResult() : result;
        }

        [HttpDelete]
        [Route("{taskId}")]
        public ActionResult<int> Delete(int taskId)
        {
            var result = _taskService.DeleteTask(taskId);
            return (result == 0) ? new EmptyResult() : result;
        }
    }
}
