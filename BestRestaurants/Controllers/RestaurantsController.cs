using BestRestaurants.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace BestRestaurants.Controllers;

public class RestaurantsController : Controller
{
  private readonly BestRestaurantsContext _db;

  public RestaurantsController(BestRestaurantsContext db)
  {
    _db = db;
  }

  public ActionResult Index()
  {
    List<Restaurant> model = _db.Restaurant.ToList();
    ViewBag.PageTitle = "View All Restaurants";
    return View(model);
  }
  public ActionResult Create()
  {
    ViewBag.CuisineId = new SelectList(_db.Cuisine, "CuisineId", "Type");
    return View();
  }

  [HttpPost]
  public ActionResult Create(Restaurant restaurant)
  {
    if (restaurant.CuisineId ==0)
    {
      return RedirectToAction("Create");
    }
  
    _db.Restaurant.Add(restaurant);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult Details(int id)
  {
    Restaurant selectedRestaurant = _db.Restaurant
                                        .Include(shop => shop.Cuisine)
                                        .FirstOrDefault(shop => shop.RestaurantId == id);
    ViewBag.PageTitle = $"Details - {selectedRestaurant.RestaurantName}";
    return View(selectedRestaurant);
  }
  public ActionResult Edit(int id)
  {
    RestaurantsController thisRestaurant = _db.Restaurant.FirstOrDefault(shop => shop.RestaurantId == id);
  }
}