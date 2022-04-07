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
            var result = _categoryService.GetCategory(categoryId);
            return (result is null) ? new EmptyResult() : result;
        }

        [HttpPost]
        public ActionResult<int> Post(CategoryInsertDto input)
        {
            var result = _categoryService.InsertCategory(input);
            return (result == 0) ? new EmptyResult() : result;
        }

        [HttpPut]
        public ActionResult<int> Put(CategoryUpdateDto input)
        {
            var result = _categoryService.UpdateCategory(input);
            return (result == 0) ? new EmptyResult() : result;
        }

        [HttpDelete]
        [Route("{categoryId}")]
        public ActionResult<int> Delete(int categoryId)
        {
            var result = _categoryService.DeleteCategory(categoryId);
            return (result == 0) ? new EmptyResult() : result;
        }
    }
}
