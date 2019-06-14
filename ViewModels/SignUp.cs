using System.ComponentModel.DataAnnotations;

namespace Web_API.ViewModels
{
  public class SignUp
  {
    [Required]
    [MinLength(6)]
    public string UserName { get; set; }
    [Required]
    [MinLength(6)]
    public string UserPassword { get; set; }
    [Required]
    [Range(8, 255)]
    public string Email { get; set; }
  }
}