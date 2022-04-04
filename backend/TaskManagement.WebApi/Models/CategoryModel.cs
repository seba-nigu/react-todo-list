namespace TaskManagement.WebApi.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public ICollection<TaskCategoryModel> TaskCategory { get; set; }
    }
}
