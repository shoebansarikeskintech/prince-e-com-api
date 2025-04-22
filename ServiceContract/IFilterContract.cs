using ViewModel;

namespace ServiceContract
{
   public interface IFilterContract
    {
        public Task<ResponseViewModel> getAllSortBy();
        public Task<ResponseViewModel> getAllFilter();
        public Task<ResponseViewModel> getPrdoctSearchByFilter(FilterViewModel model);
    }
}
