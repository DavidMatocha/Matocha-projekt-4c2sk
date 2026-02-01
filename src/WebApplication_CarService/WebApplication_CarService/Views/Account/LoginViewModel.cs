using System.ComponentModel.DataAnnotations;

namespace WebApplication_CarService.ViewModels.Account;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email je povinný.")]
    [EmailAddress(ErrorMessage = "Zadej platný email.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Heslo je povinné.")]
    public string Password { get; set; } = string.Empty;

    public bool RememberMe { get; set; }
}
