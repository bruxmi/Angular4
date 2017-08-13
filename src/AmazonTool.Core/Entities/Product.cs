using System;

namespace AmazonTool.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public decimal StarRating { get; set; }
        public string ImageUrl { get; set; }
    }
}
