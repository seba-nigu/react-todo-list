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
            return _userService.GetUser(userId);
        }

        [HttpPost]
        public ActionResult<int> Post(UserInsertDto input)
        {
            return _userService.InsertUser(input);
        }

        [HttpPut]
        public void Put(UserUpdateDto input)
        {
            _userService.UpdateUser(input);
        }

        [HttpDelete]
        [Route("{userId}")]
        public void Delete(int userId)
        {
            _userService.DeleteUser(userId);
        }
    }
}
