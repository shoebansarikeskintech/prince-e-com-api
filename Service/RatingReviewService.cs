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

        public async Task<ResponseViewModel> getAllRatingReviewbyId(Guid productId)
        {
            var getAllRatingReviewbyId = await _repositoryManager.ratingReviewRepository.getAllRatingReviewbyId(productId);
            return getAllRatingReviewbyId;
        }

        public async Task<ResponseViewModel> getAllFAQ()
        {
            var getAllFAQ = await _repositoryManager.ratingReviewRepository.getAllFAQ();
            return getAllFAQ;
        }

        public async Task<ResponseViewModel> getAllFAQByProductId(Guid productId)
        {
            var getAllFAQByProductId = await _repositoryManager.ratingReviewRepository.getAllFAQByProductId(productId);
            return getAllFAQByProductId;
        }
        public async Task<ResponseViewModel> addFAQ(AddFAQViewModel addFAQ)
        {
            var add = await _repositoryManager.ratingReviewRepository.addFAQ(addFAQ);
            return add;
        }

        public async Task<ResponseViewModel> updateFAQ(UpdateFAQViewModel updateFAQ)
        {
            var update = await _repositoryManager.ratingReviewRepository.updateFAQ(updateFAQ);
            return update;
        }

        public async Task<ResponseViewModel> deleteFAQ(DeleteFAQViewModel deleteFAQ)
        {
            var delete = await _repositoryManager.ratingReviewRepository.deleteFAQ(deleteFAQ);
            return delete;
        }

        public async Task<ResponseViewModel> getProductSpecification()
        {
            var getProductSpecification = await _repositoryManager.ratingReviewRepository.getProductSpecification();
            return getProductSpecification;
        }
        public async Task<ResponseViewModel> addProductSpecification(AddProductSpecificationViewModel addProductSpecification)
        {
            var add = await _repositoryManager.ratingReviewRepository.addProductSpecification(addProductSpecification);
            return add;
        }

        public async Task<ResponseViewModel> updateProductSpecification(UpdateProductSpecificationViewModel updateProductSpecification)
        {
            var update = await _repositoryManager.ratingReviewRepository.updateProductSpecification(updateProductSpecification);
            return update;
        }

        public async Task<ResponseViewModel> deleteProductSpecification(DeleteProductSpecificationViewModel deleteProductSpecification)
        {
            var delete = await _repositoryManager.ratingReviewRepository.deleteProductSpecification(deleteProductSpecification);
            return delete;
        }
    }
}
