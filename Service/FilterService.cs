using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
  public class FilterService : IFilterContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public FilterService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

    
        public async Task<ResponseViewModel> getAllSortBy()
        {
            var getAllSortBy = await _repositoryManager.filterRepository.getAllSortBy();
            return getAllSortBy;
        }

        public async Task<ResponseViewModel> getAllFilter()
        {
            var getAllFilter = await _repositoryManager.filterRepository.getAllFilter();
            return getAllFilter;
        }

        public async Task<ResponseViewModel> getProductSearchByFilter(FilterViewModel model)
        {
            var getProductSearchByFilter = await _repositoryManager.filterRepository.getProductSearchByFilter(model);
            return getProductSearchByFilter;
        }
        public async Task<ResponseViewModel> getProductSearchByFilterNew(FilterViewModelNew model)
        {
            var getProductSearchByFilter = await _repositoryManager.filterRepository.getProductSearchByFilterNew(model);
            return getProductSearchByFilter;
        }
        public async Task<ResponseViewModel> getAllSkinInsightProduct()
        {
            var getAllSkinInsightProduct = await _repositoryManager.filterRepository.getAllSkinInsightProduct();
            return getAllSkinInsightProduct;
        }

        public async Task<ResponseViewModel> addSkinInsightProduct(AddSkinInsightProductViewModel addSkinInsightProduct)
        {
            var add = await _repositoryManager.filterRepository.addSkinInsightProduct(addSkinInsightProduct);
            return add;
        }

        public async Task<ResponseViewModel> updateSkinInsightProduct(UpdateSkinInsightProductViewModel updateSkinInsightProduct)
        {
            var update = await _repositoryManager.filterRepository.updateSkinInsightProduct(updateSkinInsightProduct);
            return update;
        }

        public async Task<ResponseViewModel> deleteSkinInsightProduct(DeleteSkinInsightProductViewModel deleteSkinInsightProduct)
        {
            var delete = await _repositoryManager.filterRepository.deleteSkinInsightProduct(deleteSkinInsightProduct);
            return delete;
        }

        public async Task<ResponseViewModel> getAllSimilarProduct()
        {
            var getAllSimilarProduct = await _repositoryManager.filterRepository.getAllSimilarProduct();
            return getAllSimilarProduct;
        }
        public async Task<ResponseViewModel> getAllSimilarProductByProductId(Guid productId)
        {
            var getAllSimilarProductByProductId = await _repositoryManager.filterRepository.getAllSimilarProductByProductId(productId);
            return getAllSimilarProductByProductId;
        }
        public async Task<ResponseViewModel> addSimilarProduct(AddSimilarProductViewModel addSimilarProduct)
        {
            var add = await _repositoryManager.filterRepository.addSimilarProduct(addSimilarProduct);
            return add;
        }

        public async Task<ResponseViewModel> updateSimilarProduct(UpdateSimilarProductViewModel updateSimilarProduct)
        {
            var update = await _repositoryManager.filterRepository.updateSimilarProduct(updateSimilarProduct);
            return update;
        }

        public async Task<ResponseViewModel> deleteSimilarProduct(DeleteSimilarProductViewModel deleteSimilarProduct)
        {
            var delete = await _repositoryManager.filterRepository.deleteSimilarProduct(deleteSimilarProduct);
            return delete;
        }

        public async Task<ResponseViewModel> SearchAllSkinInsightProduct(SearchSkinInsightProductViewModelNew searchSkinInsightProduct)
        {
            var SearchAllSkinInsightProduct = await _repositoryManager.filterRepository.SearchAllSkinInsightProduct(searchSkinInsightProduct);
            return SearchAllSkinInsightProduct;
        }

    }
}
