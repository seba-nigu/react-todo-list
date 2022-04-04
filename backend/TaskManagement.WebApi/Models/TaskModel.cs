namespace TaskManagement.WebApi.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public UserModel User { get; set; }
        public ICollection<TaskCategoryModel> TaskCategory { get; set; }
    }
}
