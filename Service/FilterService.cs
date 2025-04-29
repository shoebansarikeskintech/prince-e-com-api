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

        public Task<ResponseViewModel> addSkinInsightProduct(AddSkinInsightProductViewModel addSkinInsightProduct)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseViewModel> deleteSkinInsightProduct(DeleteSkinInsightProductViewModel deleteSkinInsightProduct)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseViewModel> updateSkinInsightProduct(UpdateSkinInsightProductViewModel updateSkinInsightProduct)
        {
            throw new NotImplementedException();
        }
    }    
}
