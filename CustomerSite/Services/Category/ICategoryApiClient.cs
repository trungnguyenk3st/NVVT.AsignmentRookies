using AsignmentEcomerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.Services.Category
{
    public interface ICategoryApiClient
    {
        Task<IList<CategoryVm>> GetCategory();
    }
}
