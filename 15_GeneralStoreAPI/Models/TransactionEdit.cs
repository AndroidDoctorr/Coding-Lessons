using System.ComponentModel.DataAnnotations;

namespace GeneralStoreAPI.Models
{
    public class TransactionEdit
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}