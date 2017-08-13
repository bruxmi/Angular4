using AmazonTool.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTool.Core.Interfaces.Services
{
    public interface IProductQueryService
    {
        Task<Product> GetProductByIdAsync(int productId);

        Task<List<Product>> GetProductsAsync();
    }
}
