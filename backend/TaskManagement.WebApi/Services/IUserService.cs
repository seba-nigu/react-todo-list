using TaskManagement.WebApi.Dtos;
using TaskManagement.WebApi.Models;

namespace TaskManagement.WebApi.Services
{
    public interface IUserService
    {
        List<UserModel> GetUsers();
        UserModel? GetUser(int id);
        int InsertUser(UserInsertDto input);
        int UpdateUser(UserUpdateDto input);
        int DeleteUser(int id);
    }
}
