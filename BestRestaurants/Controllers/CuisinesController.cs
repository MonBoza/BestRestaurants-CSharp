using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;

namespace BestRestaurants.Controllers;

public class CuisinesController : Controller
{
    private readonly BestRestaurantsContext _db;

    public CuisinesController(BestRestaurantsContext db)
    {
      _db = db;
    }
    
    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisine.ToList();
      ViewBag.PageTitle = "View All Cuisines";
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Cuisine cuisine)
    {
      _db.Cuisine.Add(cuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Cuisine selectedCuisine = _db.Cuisine
                                    .Include(cuisine => cuisine.Restaurants)
                                    .FirstOrDefault(cuisine => cuisine.CuisineId == id);
      ViewBag.PageTitle = $"Details - {selectedCuisine.Type}";
      return View(selectedCuisine);
    }

}
