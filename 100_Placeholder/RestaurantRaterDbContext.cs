using Microsoft.EntityFrameworkCore;
using RestaurantRaterAPI.Models;


public class RestaurantRaterDbContext : DbContext //will need to bring in using for EntityFrameworkCore here
{
    //We will go ahead and add our Constructor here as well
    //This helps with setup and should pass information along to the base constructor
    public RestaurantRaterDbContext(DbContextOptions<RestaurantRaterDbContext> options) : base(options) { }
    //We will now start making our Data classes starting with Restaurant.cs before we come back here to add our dbSets
    //To keep things organized go ahead and put it in a new folder named Models

    //After creating base models for our classes we can add our DbSets
    //These are how we access our tables
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Rating> Ratings { get; set; }
}

//Next we will add our Connection string
//For Restaurant rater we will hard code the connection string in our appsettings.json
//would be worth discussing with students why this might not be ideal for private information
//We will show a different method later to utilize UserSecrets

//After the connection string is setup we will go into the program.cs file to tell our DbContext to use the connection string
