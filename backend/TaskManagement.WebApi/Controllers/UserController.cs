using Microsoft.AspNetCore.Mvc;
using TaskManagement.WebApi.Dtos;
using TaskManagement.WebApi.Models;
using TaskManagement.WebApi.Services;

namespace TaskManagement.WebApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserModel>> Get()
        {
            return _userService.GetUsers();
        }

        [HttpGet]
        [Route("{userId}")]
        public ActionResult<UserModel> Get(int userId)
        {
            var result = _userService.GetUser(userId);
            return (result is null) ? new EmptyResult() : result;
        }

        [HttpGet]
        [Route("{username}/{password}")]
        public ActionResult<int> Get(string username, string password)
        {
            var result = _userService.GetUserId(username, password);
            return (result == 0) ? new EmptyResult() : result;
        }

        [HttpPost]
        public ActionResult<int> Post(UserInsertDto input)
        {
            return _userService.InsertUser(input);
        }

        [HttpPut]
        public ActionResult<int> Put(UserUpdateDto input)
        {
            var result = _userService.UpdateUser(input);
            if (result == 0)
            {
                return new ForbidResult();
            }
            if (result < 0)
            {
                return new EmptyResult();
            }
            return result;
        }

        [HttpDelete]
        [Route("{userId}")]
        public ActionResult<int> Delete(int userId)
        {
            var result = _userService.DeleteUser(userId);
            if (result < 0)
            {
                return new EmptyResult();
            }
            return result;
        }
    }
}
