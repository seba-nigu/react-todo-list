namespace TaskManagement.WebApi.Models
{
    public class TaskCategoryModel
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int CategoryId { get; set; }
        public TaskModel Task { get; set; }
        public CategoryModel Category { get; set; }

    }
}
