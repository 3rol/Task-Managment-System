using System.Text.Json.Serialization;

namespace TaskManagmentAPI.Models
{
    public class TaskItem
    {
        public int TaskItemId { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; } = DateTime.MinValue;
        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; 

       
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; } 
    }

}
