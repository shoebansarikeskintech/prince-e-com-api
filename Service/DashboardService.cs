
using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
    public class DashboardService : IDashboardContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public DashboardService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<ResponseViewModel> getAllBannerForUser()
        {
            var getAllSubCategory = await _repositoryManager.dashboardRepository.getAllBannerForUser();
            return getAllSubCategory;
        }

        public async Task<ResponseViewModel> getAllCategories()
        {
            var getAllSubCategory = await _repositoryManager.dashboardRepository.getAllCategories();
            return getAllSubCategory;
        }

        public async Task<ResponseViewModel> getShopByCategory()
        {
            var getAllSubCategory = await _repositoryManager.dashboardRepository.getShopByCategory();
            return getAllSubCategory;
        }
    }
}
