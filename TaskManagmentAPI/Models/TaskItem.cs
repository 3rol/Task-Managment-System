using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskManagmentAPI.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}