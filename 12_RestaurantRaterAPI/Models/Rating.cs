using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantRaterAPI.Models;

public class Rating
{
        [Key]
        public int Id { get; set; }

        //in addition to out Data annotations using statement we will also
        //be adding in a using statement for Schema for the Foreign Key annotation
        [Required]
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }

        //Make sure these match up with what your Rating table
        //You may have just a Score Column or if you
        //Refactored it you will have three scores       

        [Required]
        public double FoodScore { get; set; }
        [Required]
        public double CleanlinessScore { get; set; }
        [Required]
        public double AtmosphereScore { get; set; }

        //We will now fo back over to the RestaurantDbContext to add our DbSets

        //Virtual Property we will add later
        public virtual Restaurant Restaurant { get; set; }
}

