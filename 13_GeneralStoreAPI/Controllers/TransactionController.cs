using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GeneralStoreAPI.Data;
using GeneralStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GeneralStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private GeneralStoreDBContext _db;
        public TransactionController(GeneralStoreDBContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> PostTransaction([FromForm] TransactionEdit transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (transaction.Quantity <= 0)
            {
                return BadRequest("You have to buy at least one");
            }

            Product product = await _db.Products.FindAsync(transaction.ProductId);

            if (product == null)
            {
                return BadRequest("Invalid Product ID");
            }

            if (product.QuantityInStock == 0)
            {
                return BadRequest("This item is currently out of stock");
            }

            if (product.QuantityInStock < transaction.Quantity)
            {
                return BadRequest("Not enough items in stock");
            }

            product.QuantityInStock -= transaction.Quantity;

            Transaction newTransaction = new Transaction();

            newTransaction.CustomerId = transaction.CustomerId;
            newTransaction.ProductId = transaction.ProductId;
            newTransaction.Quantity = transaction.Quantity;

            _db.Transactions.Add(newTransaction);
            await _db.SaveChangesAsync();
            return Ok();
        }


        // Initial version of the Get all
        // We will want to add includes to pull data along our foreign keys but to do that lets switch to using a list item.
        // This helps to avoid reference looping. 
        // [HttpGet]
        // public async Task<IActionResult> GetAllTransactions()
        // {
        //     List<Transaction> transactions = await _db.Transactions.ToListAsync();
        //     return Ok(transactions);
        // }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            List<TransactionListItem> transactions = await _db.Transactions
                .Select(t => new TransactionListItem()
                {
                    CustomerName = t.Customer.Name,
                    ProductName = t.Product.Name,
                    NumberPurchased = t.Quantity,
                    TotalCost = t.Quantity * t.Product.Price
                }).ToListAsync();
            return Ok(transactions);
        }

        //With this completed where we are pulling from both our Customer and Product foreign keys let's revist Product and create a more detailed view
    }
}