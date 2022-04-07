using System.ComponentModel.DataAnnotations;

namespace TaskManagement.WebApi.Dtos
{
    public class TaskInsertDto
    {
        [Required]
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
