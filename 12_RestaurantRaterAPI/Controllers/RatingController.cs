using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantRaterAPI.Models;

namespace RestaurantRaterAPI.Controllers;

[Route("[controller]")]
public class RatingController : Controller
{
    private RestaurantDbContext _context;
    public RatingController(RestaurantDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> RateRestaurant([FromForm] RatingEdit model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Ratings.Add(new Rating()
        {
            RestaurantId = model.RestaurantId,
            FoodScore = model.FoodScore,
            CleanlinessScore = model.CleanlinessScore,
            AtmosphereScore = model.AtmosphereScore,
        });

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRatings()
    {
        var ratings = await _context.Ratings.ToListAsync();
        return Ok(ratings);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetRatingsForRestaurant(int id)
    {
        //var ratings = await _context.Ratings.Where(r => r.RestaurantId == id).ToListAsync();

        //Version with include
        // This will require refernece loop handling in the program.cs
        var ratings = await _context.Ratings.Where(r => r.RestaurantId == id).ToListAsync();

        return Ok(ratings);
    }


    //Versions with display models:
    //Can just update the GetAllRatingsMethod instead of making a new one
    //Display model handles the reference loops that we encountered earlier.
    //If you like you can comment that out and show that this method will still run.
    [HttpGet]
    //If you want to have both you will need to route one of them
    [Route("ListItem")]
    public async Task<IActionResult> GetAllRatingsListItem()
    {
        var ratings = await _context.Ratings.Include(r => r.Restaurant).ToListAsync();

        var ratingListItems = ratings.Select(r => new RatingListItem()
        {
            RestaurantName = r.Restaurant.Name,
            FoodScore = r.FoodScore,
            CleanlinessScore = r.CleanlinessScore,
            AtmosphereScore = r.AtmosphereScore,
        });

        return Ok(ratingListItems);
    }
}
