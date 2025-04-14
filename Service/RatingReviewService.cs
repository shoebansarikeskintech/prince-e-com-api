using RepositoryContract;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service
{
    public class RatingReviewService: IRatingReviewContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public RatingReviewService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<ResponseViewModel> getAllRatingReview(Guid productId)
        {
            var getAllOrder = await _repositoryManager.ratingReviewRepository.getAllRatingReview(productId);
            return getAllOrder;
        }
        public async Task<ResponseViewModel> addRatingReview(RatingReviewViewModel addRatingReviewViewMethod)
        {
            var add = await _repositoryManager.ratingReviewRepository.addRatingReview(addRatingReviewViewMethod);
            return add;
        }

        public async Task<ResponseViewModel> updateRatinReview(UpdateReviewRatingViewModel updateRatingReviewMethod)
        {
            var update = await _repositoryManager.ratingReviewRepository.updateRatinReview(updateRatingReviewMethod);
             return update;
        }
    }
}
