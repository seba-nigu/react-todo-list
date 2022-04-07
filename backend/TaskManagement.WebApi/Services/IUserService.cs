using TaskManagement.WebApi.Dtos;
using TaskManagement.WebApi.Models;

namespace TaskManagement.WebApi.Services
{
    public interface IUserService
    {
        HashSet<UserModel> GetUsers();
        UserModel? GetUser(int id);
        int GetUserId(string username, string password);
        int InsertUser(UserInsertDto input);
        int UpdateUser(UserUpdateDto input);
        int DeleteUser(int id);
    }
}
