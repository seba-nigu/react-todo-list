using System.ComponentModel.DataAnnotations;

namespace TaskManagement.WebApi.Dtos
{
    public class TaskUpdateDto
    {
        [Required]
        public int TaskId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
