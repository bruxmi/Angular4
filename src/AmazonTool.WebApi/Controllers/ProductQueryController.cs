using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonTool.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductQueryController : Controller
    {
        private List<ProductGetVm> productList = new List<ProductGetVm>
            {
                new ProductGetVm
                {
                    imageUrl = "http://openclipart.org/image/300px/svg_to_png/26215/Anonymous_Leaf_Rake.png",
                    description = "Leaf rake with 48-inch wooden handle.",
                    price = 19.54m,
                    productCode = "GDN-0011",
                    Id = 1,
                    productName = "Leaf Rake",
                    releaseDate = new DateTime(),
                    starRating = 3.2m
                },
                new ProductGetVm
                {
                    imageUrl = "http://openclipart.org/image/300px/svg_to_png/58471/garden_cart.png",
                    description = "15 gallon capacity rolling garden cart",
                    price = 32.99m,
                    productCode = "GDN-0023",
                    Id = 2,
                    productName = "Garden Cart",
                    releaseDate = new DateTime(),
                    starRating = 4.2m
                },
                new ProductGetVm
                {
                    imageUrl = "http://openclipart.org/image/300px/svg_to_png/73/rejon_Hammer.png",
                    description = "Curved claw steel hammer",
                    price = 8.56m,
                    productCode = "TBX-0048",
                    Id = 3,
                    productName = "Hammer",
                    releaseDate = new DateTime(),
                    starRating = 2.51m
                }
            };
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
        public IActionResult GetProducts()
        {

            return Ok(productList);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var entity = productList.FirstOrDefault(a => a.Id == id);
            return Ok(entity);
        }
    }
}
