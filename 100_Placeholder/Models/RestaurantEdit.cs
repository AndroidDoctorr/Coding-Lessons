
namespace RestaurantRater.Models;

public class RestaurantEdit
{
    //this class is purely used for gathering information for things that will potentially change
    //Aka Name and Location
    public string Name { get; set; } 

    public string Location { get; set; }
    //we will leave off the Id as it is something that should not be set or changed
    //as it is setup with Identity to auto increment
}
