using System.ComponentModel.DataAnnotations;

namespace Web_API.ViewModels
{
    public class ForgottenPassword
    {
        [Required]
        [MinLength(6),MaxLength(10)]
        public string VerificationCode { get; set; }
        [Required]
        [Range(8, 255)]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; }
    }
}