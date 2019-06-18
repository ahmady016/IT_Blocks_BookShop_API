using System;
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
    public string Password { get; set; }
    [Required]
    [MinLength(6)]
    public string Email { get; set; }
    [Required]
    [MinLength(6)]
    public string Address { get; set; }
    [Required]
    [MinLength(11)]
    [MaxLength(11)]
    public string Mobile { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    [Required]
    public bool Gender { get; set; }
  }
}
