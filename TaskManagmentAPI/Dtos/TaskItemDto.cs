namespace TaskManagmentAPI.Dtos
{
    public class TaskItemDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; } = DateTime.MinValue;
        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public int UserId { get; set; }
    }
}
