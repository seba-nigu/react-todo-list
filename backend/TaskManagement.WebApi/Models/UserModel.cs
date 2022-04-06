using System.ComponentModel.DataAnnotations;

namespace TaskManagement.WebApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public ICollection<TaskModel>? Task { get; set; }
        public ICollection<CategoryModel>? Category { get; set; }
    }
}
