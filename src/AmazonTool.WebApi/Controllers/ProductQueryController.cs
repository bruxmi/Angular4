using AmazonTool.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonTool.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductQueryController : Controller
    {

        public ProductQueryController(IProductQueryService productQueryService)
        {
            this.productQueryService = productQueryService;
        }

        private readonly IProductQueryService productQueryService;

        public class ProductGetVm
        {
            public int Id { get; set; }
            public string productName { get; set; }
            public string productCode { get; set; }
            public DateTime releaseDate { get; set; }
            public decimal price { get; set; }
            public string description { get; set; }
            public decimal starRating { get; set; }
            public string imageUrl { get; set; }
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productList = new List<ProductGetVm>();
            var result = await this.productQueryService.GetProductsAsync();
            foreach (var product in result)
            {
                var current = new ProductGetVm
                {
                    Id = product.Id,
                    productCode = product.ProductCode,
                    productName = product.ProductName,
                    releaseDate = product.ReleaseDate,
                    price = product.Price,
                    description = product.Description,
                    imageUrl = product.ImageUrl,
                    starRating = product.StarRating
                };
                productList.Add(current);
            }
            return Ok(productList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var entity = (await this.productQueryService.GetProductsAsync()).FirstOrDefault(a => a.Id == id);
            return Ok(entity);
        }
    }
}
