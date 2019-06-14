using System.ComponentModel.DataAnnotations;

namespace Web_API.ViewModels
{
    public class ChangedPassword
    {
        [Required]
        [Range(8, 255)]
        public string Email { get; set; }
        [MinLength(6)]
        [Required]
        public string OldPassword { get; set; }
        [MinLength(6)]
        [Required]
        public string NewPassword { get; set; }
    }
}