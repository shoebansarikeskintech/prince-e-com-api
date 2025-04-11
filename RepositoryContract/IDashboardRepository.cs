

using ViewModel;

namespace RepositoryContract
{
   public interface IDashboardRepository
    {
        public Task<ResponseViewModel> getAllBannerForUser();
        public Task<ResponseViewModel> getAllCategories();
        public Task<ResponseViewModel> getShopByCategory(); 
    }
}
