namespace TaskManagmentAPI.Models
{
    public class User
    {
        
        public int UserId { get; set; } 
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        
        public List<TaskItem> Tasks { get; set; }
    }

}
