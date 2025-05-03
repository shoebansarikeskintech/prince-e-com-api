

using ViewModel;

namespace RepositoryContract
{
    public interface IFilterRepository
    {
        public Task<ResponseViewModel> getAllSortBy();
        public Task<ResponseViewModel> getAllFilter();
        public Task<ResponseViewModel> getProductSearchByFilter(FilterViewModel model);
        public Task<ResponseViewModel> getProductSearchByFilterNew(FilterViewModelNew model);
        public Task<ResponseViewModel> getAllSkinInsightProduct();

        public Task<ResponseViewModel> addSkinInsightProduct(AddSkinInsightProductViewModel addSkinInsightProduct);
        public Task<ResponseViewModel> deleteSkinInsightProduct(DeleteSkinInsightProductViewModel deleteSkinInsightProduct);

        public Task<ResponseViewModel> updateSkinInsightProduct(UpdateSkinInsightProductViewModel updateSkinInsightProduct);

        public Task<ResponseViewModel> getAllSimilarProduct();
        public Task<ResponseViewModel> getAllSimilarProductByProductId(Guid productId);

        public Task<ResponseViewModel> addSimilarProduct(AddSimilarProductViewModel addSimilarProduct);
        public Task<ResponseViewModel> updateSimilarProduct(UpdateSimilarProductViewModel updateSimilarProduct);
        public Task<ResponseViewModel> deleteSimilarProduct(DeleteSimilarProductViewModel deleteSimilarProduct);

        public Task<ResponseViewModel> SearchAllSkinInsightProduct(SearchSkinInsightProductViewModelNew searchSkinInsightProduct);

    }
}
