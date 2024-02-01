namespace TaskManagmentAPI.Dtos
{
    public class TaskItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        
        public string Priority { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }

        public int UserId { get; set; }
    }
}
