using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStoreAPI.Data;
using GeneralStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        //This should largely resemble what we did with Restaurant rater
        //take your time and talk through what we are doing but this should be more or less review

        private GeneralStoreDBContext _db;
        public ProductController(GeneralStoreDBContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] ProductEdit newProduct)
        {
            Product product = new Product()
            {
                Name = newProduct.Name,
                Price = newProduct.Price,
                QuantityInStock = newProduct.Quantity,
            };

            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _db.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //update is where it can get interesting make a basic version first
        //While you are working through it however you may bring up a point of the most frequent update would likely be restocking
        //so lets make a separate method specifically for that

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] ProductEdit newProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400
            }

            Product oldProduct = await _db.Products.FindAsync(id);

            if (oldProduct == null)
            {
                return NotFound(); // 404
            }

            oldProduct.Name = newProduct.Name;
            oldProduct.Price = newProduct.Price;
            // oldProduct.QuantityInStock = newProduct.QuantityInStock;

            await _db.SaveChangesAsync();

            return Ok(); // 200
        }

        //You can do this as a challenge for the students or as a group or forgo it altogether
        //it is just an extra example of added functionality
        //also good chance to show off what happens if we have two of the same request with the same uri
        //[HttpPut("{id}")]
        [HttpPut("{id}/restock")]
        //we can also make a separate Restock Item here as all the information we need is how much was restocked
        public async Task<IActionResult> RestockProduct(int id, [FromForm] Restock restock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400
            }

            Product oldProduct = await _db.Products.FindAsync(id);

            if (oldProduct == null)
            {
                return NotFound(); // 404
            }

            oldProduct.QuantityInStock += restock.Quantity;

            await _db.SaveChangesAsync();

            return Ok(); // 200
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            Product product = await _db.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return Ok($"{product.Name} Was Deleted");
        }
        //once you have built and tested all of these endpoints go ahead and move on to the customer controller

        //Get Product By ID detailed view. 
        //Add this after Transactions is built out
        //Can refactor get by id or build as new method
        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> GetProductDetailById(int id)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            var productDetail = new ProductDetail()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                QuantityInStock = product.QuantityInStock,
                Transactions = await _db.Transactions.Where(t => t.ProductId == id).Select(tl => new TransactionListItem()
                {
                    CustomerName = tl.Customer.Name,
                    ProductName = tl.Product.Name,
                    NumberPurchased = tl.Quantity,
                    TotalCost = tl.Quantity * tl.Product.Price
                }).ToListAsync()
            };
            return Ok(productDetail);
        }
    }
}