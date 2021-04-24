using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.Services.Users
{
    public class UserApiClient : IUserApiClient
    {
        private readonly HttpClient _client;
        public UserApiClient(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("host");

        }

        public async Task<IList<UserVm>> GetUsers()
        {
            var response = await _client.GetAsync("api/user");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IList<UserVm>>();
        }
    }
}
