using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ServiceContract
{
    public interface IRatingReviewContract
    {
        public Task<ResponseViewModel> getAllRatingReview(Guid productId);
        public Task<ResponseViewModel> addRatingReview(RatingReviewViewModel addRatingReview);
        public Task<ResponseViewModel> updateRatinReview(UpdateReviewRatingViewModel updateRatingReview);
    }
}
