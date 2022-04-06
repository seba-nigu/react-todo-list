using TaskManagement.WebApi.Dtos;
using TaskManagement.WebApi.Models;

namespace TaskManagement.WebApi.Services
{
    public interface ICategoryService
    {
        List<CategoryModel> GetCategories();
        CategoryModel GetCategory(int id);
        int InsertCategory(CategoryInsertDto input);
        void UpdateCategory(CategoryModel categoryModel);
        void DeleteCategory(int id);
    }
}
