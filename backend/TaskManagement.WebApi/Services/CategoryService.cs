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
            var category = _context.Set<CategoryModel>().FirstOrDefault(x => x.Id == id);
            _context.Set<CategoryModel>().Remove(category);
            _context.SaveChanges();

            var user = _context.Set<UserModel>().FirstOrDefault(x => x.Id == category.UserId);
            user.Categories.Remove(category);

            foreach (var taskId in category.TaskIds)
            {
                var _task = user.Tasks.FirstOrDefault(x => x.Id == taskId);
                _task.CategoryIds.Remove(category.Id);
            }
        }

        public CategoryModel GetCategory(int id)
        {
            return _context.Set<CategoryModel>().FirstOrDefault(x => x.Id == id);
        }

        public List<CategoryModel> GetCategories()
        {
            return _context.Set<CategoryModel>().ToList();
        }

        public int InsertCategory(CategoryInsertDto input)
        {
            var category = new CategoryModel
            {
                Name = input.Name,
                Description = input.Description,
                UserId = input.UserId,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            _context.Set<CategoryModel>().Add(category);
            _context.SaveChanges();

            var user = _context.Set<UserModel>().FirstOrDefault(x => x.Id == input.UserId);
            user.Categories.Add(category);

            return category.Id;
        }

        public void UpdateCategory(CategoryModel category)
        {
            var _category = _context.Set<CategoryModel>().FirstOrDefault(x => x.Id == category.Id);
            _category.Name = category.Name;
            _category.Description = category.Description;
            _category.DateModified = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
