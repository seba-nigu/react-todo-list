namespace TaskManagement.WebApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public virtual ICollection<TaskModel> Tasks { get; set; } = new List<TaskModel>();
        public virtual ICollection<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
    }
}
