namespace TaskManagement.WebApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<CategoryModel> Categories { get; set; }
        public ICollection<TaskModel> Tasks { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
