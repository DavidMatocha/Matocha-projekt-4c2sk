using Microsoft.AspNetCore.Mvc;
using WebApplication_CarService.Data;
using WebApplication_CarService.Models;

namespace WebApplication_CarService.Controllers
{
    public class AccountController : Controller
    {
        private readonly CarServiceDbContext _db;

        public AccountController(CarServiceDbContext db)
        {
            _db = db;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
              
                TempData["UserEmail"] = user.Email;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Neplatný email nebo heslo";
            return View();
        }
    }
}
