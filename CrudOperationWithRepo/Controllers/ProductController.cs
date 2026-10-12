using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudOperationWithRepo.Services.IServices;
using CrudOperationWithRepo.Models;

namespace CrudOperationWithRepo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //GET: api/Product/GetAll

        //Here we are following the Command and Query Architecture which states that a method should either be a command that performs an action or a query that returns data, but not both. In this case, the GetAllProducts method is a query that returns data, so it should not have any side effects or modify any state. This makes the code easier to reason about and test, as we can be sure that calling this method will not change anything in the system.
        [HttpGet("GetAll")]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        //GET: api/Product/GetById/1
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }
        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {
            if(product == null) 
            {
                return BadRequest("Product is null");
            }
            _productService.Create(product);
            return Ok("Product created successfully");
        }

        //PUT: api/Product/Update/1
        [HttpPut("Update/{id:int}")]
        public IActionResult Update(int id, Product product)
        {
            var p = _productService.GetById(id);
            if (p == null)
            {
                return BadRequest("Invalid Product Data");
            }
            _productService.Update(product);
            return Ok("Product updated successfully");
        }

        //DELETE: api/Product/Delete/1
        [HttpDelete("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return BadRequest("Invalid Product Data");
            }
            _productService.Delete(id);
            return Ok("Product Deleted successfully");
        }
    }
}
