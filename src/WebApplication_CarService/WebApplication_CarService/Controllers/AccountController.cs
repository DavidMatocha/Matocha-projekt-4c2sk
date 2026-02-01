using Microsoft.AspNetCore.Mvc;
using WebApplication_CarService.ViewModels.Account;

namespace WebApplication_CarService.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            TempData["Info"] = "Formulář je připravený. Registraci napojíme společně na databázi.";
            return RedirectToAction(nameof(Register));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            TempData["Info"] = "Formulář je připravený. Přihlášení napojíme společně na databázi.";
            return RedirectToAction(nameof(Login));
        }
    }
}

