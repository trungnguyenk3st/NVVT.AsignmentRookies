using AsignmentEcomerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.Services
{
    public interface IProductApiClient
    {
        Task<IList<ProductVm>> GetProducts();

        Task<ProductVm> GetProduct(int id);

        Task<IList<ProductVm>> GetProductByCategory(int id);
      
        Task<IList<ProductVm>> GetProductByArray(List<int> temp);
    }
}
