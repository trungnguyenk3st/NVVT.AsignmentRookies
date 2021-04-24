using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.Services.Users
{
    public interface IUserApiClient
    {
        Task<IList<UserVm>> GetUsers();
    }
}
