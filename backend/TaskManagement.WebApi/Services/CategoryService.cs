using Microsoft.EntityFrameworkCore;
using TaskManagement.WebApi.Dtos;
using TaskManagement.WebApi.Models;
using TaskManagement.WebApi.Persistance;

namespace TaskManagement.WebApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IApplicationDbContext _context;

        public CategoryService(IApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Set<CategoryModel>().Include("Tasks").FirstOrDefault(x => x.Id == id);

            var user = _context.Set<UserModel>().Include("Categories").FirstOrDefault(x => x.Id == category.UserId);
            user.Categories.Remove(category);

            foreach (var task in category.Tasks)
            {
                _context.Set<TaskModel>().Remove(task);
            }

            _context.Set<CategoryModel>().Remove(category);
            _context.SaveChanges();
        }

        public CategoryModel GetCategory(int id)
        {
            return _context.Set<CategoryModel>().Include("Tasks").FirstOrDefault(x => x.Id == id);
        }

        public List<CategoryModel> GetCategories()
        {
            return _context.Set<CategoryModel>().Include("Tasks").ToList();
        }

        public int InsertCategory(CategoryInsertDto input)
        {
            var category = new CategoryModel
            {
                UserId = input.UserId,
                Tasks = new List<TaskModel>(),
                Name = input.Name,
                Description = (input.Description is null) ? string.Empty : input.Description,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            _context.Set<CategoryModel>().Add(category);

            var user = _context.Set<UserModel>().Include("Categories").FirstOrDefault(x => x.Id == input.UserId);
            user.Categories.Add(category);

            _context.SaveChanges();
            return category.Id;
        }

        public void UpdateCategory(CategoryUpdateDto input)
        {
            var category = _context.Set<CategoryModel>().FirstOrDefault(x => x.Id == input.CategoryId);
            category.Name = input.Name;
            category.Description = (input.Description is null) ? string.Empty : input.Description;
            category.DateModified = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
