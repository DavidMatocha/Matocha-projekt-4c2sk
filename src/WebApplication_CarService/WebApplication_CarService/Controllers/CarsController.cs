using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication_CarService.Data;
using WebApplication_CarService.Models;

namespace WebApplication_CarService.Controllers;

[Authorize]
public class CarsController : Controller
{
    private readonly CarServiceDbContext _db;
    public CarsController(CarServiceDbContext db) => _db = db;

    private int CurrentUserId() => int.Parse(User.FindFirst("id")!.Value);

    public IActionResult Index()
    {
        int uid = CurrentUserId();
        var cars = _db.Cars.Where(c => c.UserId == uid).ToList();
        return View(cars);
    }

    [HttpGet]
    public IActionResult Create() => View(new Car());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Car car)
    {
        if (!ModelState.IsValid) return View(car);

        car.UserId = CurrentUserId();
        _db.Cars.Add(car);
        _db.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        int uid = CurrentUserId();
        var car = _db.Cars.FirstOrDefault(c => c.Id == id && c.UserId == uid);
        if (car == null) return NotFound();
        return View(car);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Car car)
    {
        int uid = CurrentUserId();
        var dbCar = _db.Cars.FirstOrDefault(c => c.Id == id && c.UserId == uid);
        if (dbCar == null) return NotFound();
        if (!ModelState.IsValid) return View(car);

        dbCar.Brand = car.Brand;
        dbCar.Model = car.Model;
        dbCar.LicensePlate = car.LicensePlate;
        dbCar.Year = car.Year;
        dbCar.CurrentMileage = car.CurrentMileage;

        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        int uid = CurrentUserId();
        var car = _db.Cars.FirstOrDefault(c => c.Id == id && c.UserId == uid);
        if (car == null) return NotFound();
        return View(car);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        int uid = CurrentUserId();
        var car = _db.Cars.FirstOrDefault(c => c.Id == id && c.UserId == uid);
        if (car == null) return NotFound();

        _db.Cars.Remove(car);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

}
