using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStoreAPI.Models
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int QuantityInStock { get; set; }
        public double TotalValue
        {
            get
            {
                return Price * QuantityInStock;
            }
        }
        public List<TransactionListItem> Transactions { get; set; }
    }
}