using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BestRestaurants.Models
{
  public class Cuisine
  {
    [Required]
    public int CuisineId { get; set; }
    
    [Required]
    public string Type { get; set; }
    
    public List<Restaurant> Restaurants { get; set; }
  }
}