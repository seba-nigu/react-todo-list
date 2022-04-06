namespace TaskManagement.WebApi.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<int> TaskIds { get; set; } = new List<int>();
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
