namespace TaskManagement.WebApi.Dtos
{
    public class TaskInsertDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
