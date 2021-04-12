using AsignmentEcomerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.Services.RatingProduct
{
    public interface IRatingService
    {
        Task<IEnumerable<RatingVm>> GetRatings();
        Task<IEnumerable<RatingVm>> GetRatingByProductId(int ProductId);
        Task<IEnumerable<RatingVm>> GetRatingByUserId(string UserId);
        Task<RatingVm> PostRating(string userToken, RatingCreateRequest request);
    }
}
