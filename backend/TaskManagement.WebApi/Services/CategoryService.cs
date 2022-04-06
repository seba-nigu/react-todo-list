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
            var categoryModel = new CategoryModel
            {
                Name = input.Name,
                Description = input.Description,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            _context.Set<CategoryModel>().Add(categoryModel);
            _context.SaveChanges();
            return categoryModel.Id;
        }

        public void UpdateCategory(CategoryModel categoryModel)
        {
            var category = _context.Set<CategoryModel>().FirstOrDefault(x => x.Id == categoryModel.Id);
            category.Name = categoryModel.Name;
            category.Description = categoryModel.Description;
            category.DateModified = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
