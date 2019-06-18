using System.ComponentModel.DataAnnotations;

namespace Web_API.ViewModels
{
    public class SignIn
    {
        [Required]
        [MinLength(6)]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}