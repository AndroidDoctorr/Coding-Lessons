using System.ComponentModel.DataAnnotations;

namespace RestaurantRaterAPI.Models;

//We will now create a model for each of our tables
//To a basic extent we can see our classes as coresponding to the tables they represent
//with each of their properties represnting a row of data
public class Restaurant
{
    //We will need to bring in the Data Annotations using statement for these annotations. 
    [Key]
    public int Id { get; set; }

    //On our strings we will be getting a warning
    //This warning doesnt break anything but is worth discussing
    //starting in C# 8 reference types no longer default to null
    //.Net 6 has started giving us warnings on reference types that have not been given a value
    //This can be remedied either by setting up a value toi be passed in in the constructor
    //or by stating that the type is nullable by adding a ? to the end aka string?
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(100)]
    public string Location { get; set; }
    //Now lets go ahead and make a rating class


    //Virtual Property for later                        //newing up in advance to avoid null reference errors
    public virtual List<Rating> Ratings { get; set; } = new List<Rating>();
}
