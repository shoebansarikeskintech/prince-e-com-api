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

        public async Task<ResponseViewModel> getPrdoctSearchByFilter(FilterViewModel model)
        {
            var getPrdoctSearchByFilter = await _repositoryManager.filterRepository.getPrdoctSearchByFilter(model);
            return getPrdoctSearchByFilter;
        }

     
    }    
}
