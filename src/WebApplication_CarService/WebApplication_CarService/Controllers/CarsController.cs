using Microsoft.AspNetCore.Mvc;
using WebApplication_CarService.Data;
using WebApplication_CarService.Models;

namespace WebApplication_CarService.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarServiceDbContext _db;

        public CarsController(CarServiceDbContext db)
        {
            _db = db;
        }

        
        public IActionResult Index()
        {
            var cars = _db.Cars.ToList();
            return View(cars);
        }

        
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _db.Cars.Add(car);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        

        [HttpPost]
        public IActionResult Edit(int id)
        {
            var car = _db.Cars.Find(id);
            if (car == null) return NotFound();
            return View(car);
        }

       
        [HttpPost]
        public IActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                _db.Cars.Update(car);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(car);
        }

      
        public IActionResult Delete(int id)
        {
            var car = _db.Cars.Find(id);
            if (car == null) return NotFound();
            return View(car);
        }

        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var car = _db.Cars.Find(id);
            if (car != null)
            {
                _db.Cars.Remove(car);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }



    }


}
