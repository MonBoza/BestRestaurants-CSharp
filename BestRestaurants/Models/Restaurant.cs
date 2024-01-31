using System.ComponentModel.DataAnnotations;

namespace BestRestaurants.Models
{
  public class Restaurant
  {
  public int RestaurantId { get; set;}
  [Required(ErrorMessage = "This field is required.")]
  public string RestaurantName { get; set; }

  [Required(ErrorMessage = "This field is required.")]
  public string Description { get; set; }
  public int CuisineId { get; set; }
  public Cuisine Cuisine { get; set; }
  }
}