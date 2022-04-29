
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
        // var restaurants = await _context.Restaurants.ToListAsync();

        // version with include
        // This will require refernece loop handling in the program.cs
        var restaurants = await _context.Restaurants.Include(r => r.Ratings).ToListAsync();

        return Ok(restaurants);
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


    //Using Display Class
    //Get All Restaurants
    //Display model handles the reference loops that we encountered earlier.
    //If you like you can comment that out and show that this method will still run.
    [HttpGet]
    //If you want to have both you will need to route one of them
    [Route("ListItem")]
    public async Task<IActionResult> GetRestaurantListItems()
    {
        var restaurants = await _context.Restaurants.Include(r => r.Ratings).ToListAsync();
        var restaurantList = restaurants.Select(restaurant =>
        {
            var ratings = restaurant.Ratings;

            //setting default values to 0
            double averageFoodScore = 0;
            double averageCleanlinessScore = 0;
            double averageAtmosphereScore = 0;

            //If restaurant has ratings going ahead and averaging them out
            if (ratings.Count > 0)
            {
                averageFoodScore = ratings.Select(s => s.FoodScore).Average();
                averageCleanlinessScore = ratings.Select(s => s.CleanlinessScore).Average();
                averageAtmosphereScore = ratings.Select(s => s.AtmosphereScore).Average();
            }

            return new RestaurantListItem()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Location = restaurant.Location,
                AverageFoodScore = Math.Round(averageFoodScore, 2),
                AverageCleanlinessScore = Math.Round(averageCleanlinessScore, 2),
                AverageAtmosphereScore = Math.Round(averageAtmosphereScore, 2),
            };
        });

        return Ok(restaurantList);
    }
}
