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

        public int DeleteUser(int id)
        {
            var user = _context.Set<UserModel>().Include("Categories").Include("Tasks").FirstOrDefault(x => x.Id == id);
            if (user is null)
            {
                return -1;
            }

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
            return id;
        }

        public UserModel? GetUser(int id)
        {
            var user = _context.Set<UserModel>().AsNoTracking().Include("Categories").Include("Tasks").FirstOrDefault(x => x.Id == id);
            if (user is null)
            {
                return null;
            }
            user.Password = "";
            return user;
        }

        public int GetUserId(string username, string password)
        {
            var user = _context.Set<UserModel>().AsNoTracking().Include("Categories").Include("Tasks").FirstOrDefault(x => x.Name.Equals(username));
            if (user is null)
            {
                return 0;
            }
            if (Hasher.CheckPassword(user.Password, password))
            {
                return user.Id;
            }
            return 0;
        }

        public HashSet<UserModel> GetUsers()
        {
            var users = _context.Set<UserModel>().AsNoTracking().Include("Categories").Include("Tasks").ToHashSet();
            foreach (var user in users)
            {
                user.Password = "";
            }
            return users;
        }

        public int InsertUser(UserInsertDto input)
        {
            var user = new UserModel
            {
                Name = input.Name,
                Password = Hasher.GetHashedPassword(input.Password),
                Categories = new HashSet<CategoryModel>(),
                Tasks = new HashSet<TaskModel>(),
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            _context.Set<UserModel>().Add(user);

            _context.SaveChanges();
            return user.Id;
        }

        public int UpdateUser(UserUpdateDto input)
        {
            var user = _context.Set<UserModel>().FirstOrDefault(x => x.Id == input.UserId);
            if (user is null)
            {
                return -1;
            }

            if (!Hasher.CheckPassword(user.Password, input.OldPassword))
            {
                return 0;
            }

            user.Name = input.Name;
            user.Password = Hasher.GetHashedPassword(input.NewPassword);
            user.DateModified = DateTime.Now;
            _context.SaveChanges();
            return user.Id;
        }
    }
}
