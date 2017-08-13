using AmazonTool.Core.Entities;
using AmazonTool.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonTool.Business
{
    public class ProductQueryService : IProductQueryService
    {
        private readonly List<Product> productList;

        public ProductQueryService()
        {
            productList = new List<Product>
            {
                new Product
                {
                    ImageUrl = "http://openclipart.org/image/300px/svg_to_png/26215/Anonymous_Leaf_Rake.png",
                    Description = "Leaf rake with 48-inch wooden handle.",
                    Price = 19.54m,
                    ProductCode = "GDN-0011",
                    Id = 1,
                    ProductName = "Leaf Rake",
                    ReleaseDate = new DateTime(),
                    StarRating = 3.2m
                },
                new Product
                {
                    ImageUrl = "http://openclipart.org/image/300px/svg_to_png/58471/garden_cart.png",
                    Description = "15 gallon capacity rolling garden cart",
                    Price = 32.99m,
                    ProductCode = "GDN-0023",
                    Id = 2,
                    ProductName = "Garden Cart",
                    ReleaseDate = new DateTime(),
                    StarRating = 4.2m
                },
                new Product
                {
                    ImageUrl = "http://openclipart.org/image/300px/svg_to_png/73/rejon_Hammer.png",
                    Description = "Curved claw steel hammer",
                    Price = 8.56m,
                    ProductCode = "TBX-0048",
                    Id = 3,
                    ProductName = "Hammer",
                    ReleaseDate = new DateTime(),
                    StarRating = 2.51m
                }
            };
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await Task.FromResult(productList.FirstOrDefault(a => a.Id == productId));
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await Task.FromResult(productList);
        }
    }
}
