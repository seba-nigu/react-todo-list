using System.ComponentModel.DataAnnotations;

namespace TaskManagement.WebApi.Dtos
{
    public class CategoryInsertDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
