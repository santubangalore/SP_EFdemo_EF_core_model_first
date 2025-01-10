using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP_EFDemo.Models;
using SP_EFDemo.Repositories;

namespace SP_EFDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
                this._productService = productService;
        }

        [HttpGet("GetProductList")]
        public async Task<ActionResult> GetProductList()
        {
            try
            {
                var result= await this._productService.GetProductListAsync();
                return Ok(result);
            }
            catch 
            {
                throw;
            }
        }

        [HttpGet("GetProductById")]
        public async Task<ActionResult> GetProduct(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }

            try
            {
                var result = await this._productService.GetProductByIdAsync(id);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProduct(Product p)
        {
            if(p == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await this._productService.AddProductAsync(p);
                return Ok(result);
            }
            catch 
            {
                throw;
            }
        }

        [HttpPut("UpdateProduct")]
        public async Task<ActionResult> UpdateProduct(Product p)
        {
            if (p == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await this._productService.UpdateProductAsync(p);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("DeleteProduct")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                var result = await this._productService.DeleteProductAsync(id);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("GetProductSalesList")]
        public async Task<ActionResult> GetProductSalesList()
        {
            try
            {
                var result = await this._productService.GetProductSalesListAsync();
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("GetProductSalesListById")]
        public async Task<ActionResult> GetProductSalesListById(int ProductId)
        {
            try
            {
                var result = await this._productService.GetProductSalesListByIdAsync(ProductId);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
