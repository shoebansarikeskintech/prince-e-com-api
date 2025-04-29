
using ViewModel;

namespace ServiceContract
{
   public interface IDashboardContract
    {
        public Task<ResponseViewModel> getAllBannerForUser();
        public Task<ResponseViewModel> getAllCategories();
        public Task<ResponseViewModel> getShopByCategory();

        public Task<ResponseViewModel> getAllCategoriesNew();
    }
}
