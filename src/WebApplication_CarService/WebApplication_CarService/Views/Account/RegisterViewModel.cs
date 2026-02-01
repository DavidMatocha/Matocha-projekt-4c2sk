using System.ComponentModel.DataAnnotations;

namespace WebApplication_CarService.ViewModels.Account;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Email je povinný.")]
    [EmailAddress(ErrorMessage = "Zadej platný email.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Heslo je povinné.")]
    [MinLength(8, ErrorMessage = "Heslo musí mít alespoň 8 znaků.")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Potvrzení hesla je povinné.")]
    [Compare(nameof(Password), ErrorMessage = "Hesla se neshodují.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
