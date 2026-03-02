using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication_CarService.Data;
using WebApplication_CarService.Models;

namespace WebApplication_CarService.Controllers;

[Authorize]
public class ServiceRecordsController : Controller
{
    private readonly CarServiceDbContext _db;

    public ServiceRecordsController(CarServiceDbContext db)
    {
        _db = db;
    }

    private int CurrentUserId()
        => int.Parse(User.FindFirst("id")!.Value);

    private Car? OwnedCar(int carId)
    {
        int uid = CurrentUserId();
        return _db.Cars.FirstOrDefault(c => c.Id == carId && c.UserId == uid);
    }

    //ServiceRecords?carId=5
    public IActionResult Index(int carId)
    {
        var car = OwnedCar(carId);
        if (car == null) return NotFound();

        ViewBag.Car = car;

        var records = _db.ServiceRecords
            .Where(r => r.CarId == carId)
            .OrderByDescending(r => r.Date)
            .ToList();

        return View(records);
    }

   
    [HttpGet]
    public IActionResult Create(int carId)
    {
        var car = OwnedCar(carId);
        if (car == null) return NotFound();

        ViewBag.Car = car;
        return View(new ServiceRecord { CarId = carId, Date = DateTime.Today });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ServiceRecord record)
    {
        var car = OwnedCar(record.CarId);
        if (car == null) return NotFound();

        ViewBag.Car = car;

        if (!ModelState.IsValid)
            return View(record);

        _db.ServiceRecords.Add(record);
        _db.SaveChanges();

        return RedirectToAction(nameof(Index), new { carId = record.CarId });
    }

  
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var record = _db.ServiceRecords.FirstOrDefault(r => r.Id == id);
        if (record == null) return NotFound();

        var car = OwnedCar(record.CarId);
        if (car == null) return NotFound();

        ViewBag.Car = car;
        return View(record);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, ServiceRecord record)
    {
        if (id != record.Id) return BadRequest();

        var car = OwnedCar(record.CarId);
        if (car == null) return NotFound();

        ViewBag.Car = car;

        var dbRec = _db.ServiceRecords.FirstOrDefault(r => r.Id == id && r.CarId == record.CarId);
        if (dbRec == null) return NotFound();

        if (!ModelState.IsValid)
            return View(record);

        dbRec.Date = record.Date;
        dbRec.Mileage = record.Mileage;
        dbRec.Title = record.Title;
        dbRec.Description = record.Description;
        dbRec.Cost = record.Cost;

        _db.SaveChanges();
        return RedirectToAction(nameof(Index), new { carId = record.CarId });
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var record = _db.ServiceRecords.FirstOrDefault(r => r.Id == id);
        if (record == null) return NotFound();

        var car = OwnedCar(record.CarId);
        if (car == null) return NotFound();

        ViewBag.Car = car;
        return View(record);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var record = _db.ServiceRecords.FirstOrDefault(r => r.Id == id);
        if (record == null) return NotFound();

        var car = OwnedCar(record.CarId);
        if (car == null) return NotFound();

        int carId = record.CarId;

        _db.ServiceRecords.Remove(record);
        _db.SaveChanges();

        return RedirectToAction(nameof(Index), new { carId });
    }
}
