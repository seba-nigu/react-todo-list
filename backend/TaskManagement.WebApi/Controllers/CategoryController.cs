using Microsoft.AspNetCore.Mvc;
using TaskManagement.WebApi.Dtos;
using TaskManagement.WebApi.Models;
using TaskManagement.WebApi.Services;

namespace TaskManagement.WebApi.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryModel>> Get()
        {
            return _categoryService.GetCategories();
        }

        [HttpGet]
        [Route("{categoryId}")]
        public ActionResult<CategoryModel> Get(int categoryId)
        {
            return _categoryService.GetCategory(categoryId);
        }

        [HttpPost]
        public ActionResult<int> Post(CategoryInsertDto input)
        {
            return _categoryService.InsertCategory(input);
        }

        [HttpPut]
        public void Put(CategoryModel categoryModel)
        {
            _categoryService.UpdateCategory(categoryModel);
        }

        [HttpDelete]
        [Route("{categoryId}")]
        public void Delete(int categoryId)
        {
            _categoryService.DeleteCategory(categoryId);
        }
    }
}
