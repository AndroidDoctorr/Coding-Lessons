using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStoreAPI.Models
{
    public class TransactionListItem
    {
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int NumberPurchased { get; set; }
        public double TotalCost { get; set; }
    }
}