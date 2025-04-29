using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace RepositoryContract
{
    public interface IRatingReviewRepository
    {
        public Task<ResponseViewModel> getAllRatingReview(Guid productId);
        public Task<ResponseViewModel> getAllRatingReviewbyId(Guid productId);

        public Task<ResponseViewModel> addRatingReview(RatingReviewViewModel addRatingReview);
        public Task<ResponseViewModel> updateRatinReview(UpdateReviewRatingViewModel updateRatingReview);

        public Task<ResponseViewModel> getAllFAQ();

        public Task<ResponseViewModel> getAllFAQByProductId(Guid productId);

        public Task<ResponseViewModel> addFAQ(AddFAQViewModel addFAQ);
        public Task<ResponseViewModel> updateFAQ(UpdateFAQViewModel updateFAQ);

        public Task<ResponseViewModel> deleteFAQ(DeleteFAQViewModel deleteFAQ);

        public Task<ResponseViewModel> getProductSpecification();

        public Task<ResponseViewModel> addProductSpecification(AddProductSpecificationViewModel addProductSpecification);
        public Task<ResponseViewModel> updateProductSpecification(UpdateProductSpecificationViewModel updateProductSpecification);

        public Task<ResponseViewModel> deleteProductSpecification(DeleteProductSpecificationViewModel deleteProductSpecification);
    }
}
