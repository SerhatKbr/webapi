using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository repository;

        public ProductsController(IProductRepository repository)
        {
            this.repository = repository;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> getProducts()
        {
            var products = await repository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            var product = await repository.GetProductByIdAsync(id);
            return product;
        }

        [HttpGet("brands")]
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands(){
            var brands = await repository.GetProductBrands();
            return brands;
        }

        [HttpGet("types")]
        public async Task<IReadOnlyList<ProductType>> GetProductTypes(){
            var types = await repository.GetProductTypes();
            return types;
        }


    }
}