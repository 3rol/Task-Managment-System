using System.ComponentModel.DataAnnotations;

namespace TaskManagmentAPI.Dtos
{
    public class AddListDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
    }
}
