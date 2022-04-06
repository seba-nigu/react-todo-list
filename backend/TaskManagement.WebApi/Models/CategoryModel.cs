using System.ComponentModel.DataAnnotations;

namespace TaskManagement.WebApi.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public ICollection<TaskCategoryModel> TaskCategory { get; set; }
    }
}
