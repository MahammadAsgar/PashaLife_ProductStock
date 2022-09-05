using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductStockApi.ProductsApi
{
    public class ProductsList
    {
        string url;
        public ProductsList()
        {
            url = "https://localhost:5004/api/Product/get-all-products";
        }
        public List<Product> GetProducts()
        {
            HttpClient client = new HttpClient();
            //var products = new List<Product>();
            //HttpResponseMessage response = client.GetAsync(url).Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    var result = response.Content.ReadAsStringAsync().Result;
            //    products = JsonConvert.DeserializeObject<List<Product>>(result);
            //}
            //return products;
            var results = client.GetStringAsync(url);
            HttpResponseMessage response = client.GetAsync(url).Result;
            List<Product> products = new List<Product>();
            if (response.IsSuccessStatusCode)
            {
                var a = response.Content.ReadAsStringAsync().Result;
                products  = JsonConvert.DeserializeObject<List<Product>>(a);
            }
            return products;

        }
    }
}
