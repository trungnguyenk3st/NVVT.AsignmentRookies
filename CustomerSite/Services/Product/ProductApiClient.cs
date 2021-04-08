using AsignmentEcomerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CustomerSite.Services.Product
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly HttpClient _client;

        public ProductApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IList<ProductVm>> GetProducts()
        {
            var response = await _client.GetAsync("https://localhost:44342/api/products");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductVm>>();
        }

        public async Task<ProductVm> GetProduct(int id)
        {
            var response = await _client.GetAsync("https://localhost:44342/api/products/" + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ProductVm>();
        }

        public async Task<IList<ProductVm>> GetProductByCategory(int id)
        {
            var response = await _client.GetAsync("https://localhost:44342/api/products/category/" + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<ProductVm>>();
        }

       

       
    }
}
