using System.ComponentModel.DataAnnotations;

namespace TaskManagmentAPI.Models
{
    public class List
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<TaskItem> Tasks { get; set; }
    }
}
