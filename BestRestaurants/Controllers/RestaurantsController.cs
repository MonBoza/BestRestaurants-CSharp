using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;

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

}