using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRaterAPI.Models
{
    public class RatingEdit
    {
        [Required]
        public int RestaurantId { get; set; }
        [Required]
        public double Score { get; set; }
    }
}