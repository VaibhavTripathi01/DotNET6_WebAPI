using EntityF_API.DBO;
using EntityF_API.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityF_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyDbContext _mydbcontext;

        public ProductController(MyDbContext mydbcontext)
        {
            _mydbcontext = mydbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var ourAllProducts = await _mydbcontext.Products.ToListAsync();
            return Ok(ourAllProducts);
        }

        [HttpGet]
        [Route("get-product-by-id")]
        public async Task<IActionResult> GetProductByID(int id)
        {
            var productDetails=await _mydbcontext.Products.FindAsync(id);
            return Ok(productDetails);  
        }

        [HttpPost]
        [Route("add-product")]

        public async Task<IActionResult> PostProductAsync(Products product)
        {
            _mydbcontext.Products.Add(product);
            await _mydbcontext.SaveChangesAsync();
            return Created($"/get-product-by-id?id={product.Id}", product);
        }

        [HttpPut]
        [Route("update-product")]
        public async Task<IActionResult> UpdateProduct(Products product)
        {
            _mydbcontext.Products.Update(product);
            await _mydbcontext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteOurProduct(int id)
        {
            var deletedProduct= await _mydbcontext.Products.FindAsync(id);
            if(deletedProduct==null)
            {
                return NotFound();
            }
            else
            {
                _mydbcontext.Products.Remove(deletedProduct);
                await _mydbcontext.SaveChangesAsync();
                return NoContent();
            }
        }

        

    }
}
