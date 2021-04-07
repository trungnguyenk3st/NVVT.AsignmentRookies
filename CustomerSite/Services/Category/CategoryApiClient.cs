using AsignmentEcomerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CustomerSite.Services.Category
{
    public class CategoryApiClient : ICategoryApiClient
    {
          
        private readonly HttpClient _client;

        public CategoryApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IList<CategoryVm>> GetCategory()
        {
            var response = await _client.GetAsync("api/category");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IList<CategoryVm>>();
        }
    }

}

