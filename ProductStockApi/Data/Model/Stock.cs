using ProductStockApi.ProductsApi;
using System.ComponentModel.DataAnnotations;

namespace ProductStockApi.Data.Model
{
    public class Stock
    {
        public int Id { get; set; }
        [Required]
        public int StockProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public int ProductCount { get; set; }
    }
}
