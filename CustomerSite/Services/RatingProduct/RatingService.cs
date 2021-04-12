using AsignmentEcomerce.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

using System.Threading.Tasks;

namespace CustomerSite.Services.RatingProduct
{
    public class RatingService : IRatingService
    {
        private readonly HttpClient _client;

        public RatingService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<RatingVm>> GetRatings()
        {
            var response = await _client.GetAsync("https://localhost:44342/api/rating");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<RatingVm>>();
        }

        public async Task<IEnumerable<RatingVm>> GetRatingByProductId(int IDProduct)
        {
            var response = await _client.GetAsync("https://localhost:44342/api/rating/product/" + IDProduct);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<RatingVm>>();
        }

        public async Task<IEnumerable<RatingVm>> GetRatingByUserId(string UserId)
        {
            var response = await _client.GetAsync("https://localhost:44342/api/rating/user/" + UserId);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<RatingVm>>();
        }

        public async Task<RatingVm> PostRating(string userToken, RatingCreateRequest request)
        {
          
            // 2 dòng dưới dùng khi muốn chèn access token vào httpclient đề lấy api đã dc bảo mật
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userToken);
            var response = await _client.PostAsync("https://localhost:44342/api/rating/", JsonContent.Create(request));

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<RatingVm>();
        }
    }
}
