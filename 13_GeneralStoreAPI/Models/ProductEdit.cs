using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStoreAPI.Models
{
    public class ProductEdit
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
    //once this is in place we can go ahead and go over to the controller.
}