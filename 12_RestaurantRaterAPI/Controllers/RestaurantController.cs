
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantRaterAPI.Models;

namespace RestaurantRaterAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class RestaurantController : ControllerBase
{

    private RestaurantDbContext _context;
    public RestaurantController(RestaurantDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> PostRestaurant([FromForm] RestaurantEdit model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _context.Restaurants.Add(new Restaurant()
        {
            Name = model.Name,
            Location = model.Location
        });
        await _context.SaveChangesAsync();
        return Ok($"{model.Name} added");
    }


    //Get All Restaurants
    [HttpGet]
    public async Task<IActionResult> GetRestaurants()
    {
        var restaurants = await _context.Restaurants.Include(r => r.Ratings).ToListAsync();
        var restaurantListItems = restaurants.Select(restaurant =>
        {
            RestaurantListItem listItem = new RestaurantListItem();

            listItem.Id = restaurant.Id;
            listItem.Location = restaurant.Location;
            listItem.Name = restaurant.Name;

            if (restaurant.Ratings.Count == 0)
            {
                listItem.AverageScore = 0;
            }
            else
            {
                listItem.AverageScore = restaurant.Ratings.Select(s => s.Score).Average();
            }
            return listItem;
        });

        return Ok(restaurantListItems);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetRestaurantsById(int id)
    {
        //var restaurant = await _context.Restaurants.FindAsync(id);
        //Alternate version with include
        //This will require refernece loop handling in the program.cs
        var restaurant = await _context.Restaurants.Include(r => r.Ratings).FirstOrDefaultAsync(r => r.Id == id);
        
        if (restaurant == null)
        {
            return NotFound();
        }

        return Ok(restaurant);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, [FromForm] RestaurantEdit model)
    {
        var oldRestaurant = await _context.Restaurants.FindAsync(id);

        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        if (!string.IsNullOrEmpty(model.Name))
        {
            oldRestaurant.Name = model.Name;
        }
        if (!string.IsNullOrEmpty(model.Location))
        {
            oldRestaurant.Location = model.Location;
        }

        await _context.SaveChangesAsync();

        return Ok();
    }


    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);
        if (restaurant == null)
        {
            return NotFound(); // 404
        }

        _context.Restaurants.Remove(restaurant);

        await _context.SaveChangesAsync();

        return Ok(); // 200            
    }
}
