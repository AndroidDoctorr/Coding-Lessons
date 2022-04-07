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
            Score = model.Score
        });

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRatings()
    {
        var ratings = await _context.Ratings.Include(r => r.Restaurant).ToListAsync();

        var ratingListItems = ratings.Select(r => new RatingListItem()
        {
            RatingId = r.Id,
            RestaurantRating = r.Score,
            RestaurantName = r.Restaurant.Name
        }
        );

        return Ok(ratingListItems);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetRatingsForRestaurant(int id)
    {
        var ratings = await _context.Ratings.Where(r => r.RestaurantId == id).ToListAsync();
        return Ok(ratings);
    }
}
