

using ViewModel;

namespace RepositoryContract
{
    public interface IFilterRepository
    {
        public Task<ResponseViewModel> getAllSortBy();
        public Task<ResponseViewModel> getAllFilter();
        public Task<ResponseViewModel> getProductSearchByFilter(FilterViewModel model);

    }
}
