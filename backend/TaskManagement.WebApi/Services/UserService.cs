using Microsoft.EntityFrameworkCore;
using TaskManagement.WebApi.Dtos;
using TaskManagement.WebApi.Models;
using TaskManagement.WebApi.PasswordHashing;
using TaskManagement.WebApi.Persistance;

namespace TaskManagement.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbContext _context;

        public UserService(IApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteUser(int id)
        {
            var user = _context.Set<UserModel>().Include("Categories").Include("Tasks").FirstOrDefault(x => x.Id == id);

            foreach (var category in user.Categories)
            {
                _context.Set<CategoryModel>().Remove(category);
            }
            foreach (var task in user.Tasks)
            {
                _context.Set<TaskModel>().Remove(task);
            }

            _context.Set<UserModel>().Remove(user);
            _context.SaveChanges();
        }

        public UserModel GetUser(int id)
        {
            return _context.Set<UserModel>().Include("Categories").Include("Tasks").FirstOrDefault(x => x.Id == id);
        }

        public List<UserModel> GetUsers()
        {
            return _context.Set<UserModel>().Include("Categories").Include("Tasks").ToList();
        }

        public int InsertUser(UserInsertDto input)
        {
            var user = new UserModel
            {
                Name = input.Name,
                Password = Hasher.GetHashedPassword(input.Password),
                Categories = new List<CategoryModel>(),
                Tasks = new List<TaskModel>(),
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            _context.Set<UserModel>().Add(user);

            _context.SaveChanges();
            return user.Id;
        }

        public void UpdateUser(UserUpdateDto input)
        {
            var user = _context.Set<UserModel>().FirstOrDefault(x => x.Id == input.UserId);


            // !!!HERE!!!
            if (!Hasher.CheckPassword(user.Password, input.OldPassword))
            {
                throw new Exception();
            }

            user.Name = input.Name;
            user.Password = Hasher.GetHashedPassword(input.NewPassword);
            user.DateModified = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
