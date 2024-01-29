using System.ComponentModel.DataAnnotations;

namespace TaskManagmentAPI.Dtos
{
    public class UpdateListDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
    }
}
