
using RepositoryContract;
using ServiceContract;
using System.Reflection;
using ViewModel;

namespace Service
{
   public class BannerService : IBannerContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public BannerService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getByIdBanner(Guid bannerId)
        {
            var getByIdSubCategory = await _repositoryManager.bannerRepository.getByIdBanner(bannerId);
            return getByIdSubCategory;
        }

        public async Task<ResponseViewModel> getAllBanner()
        {
            var getAllSubCategory = await _repositoryManager.bannerRepository.getAllBanner();
            return getAllSubCategory;
        }

        public async Task<ResponseViewModel> addBanner(AddBannerViewModel addBanner)
        {
            var add = await _repositoryManager.bannerRepository.addBanner(addBanner);
            return add;
        }

        public async Task<ResponseViewModel> updateBanner(UpdateBannerViewModel updateBanner)
        {
            var update = await _repositoryManager.bannerRepository.updateBanner(updateBanner);
            return update;
        }

        public async Task<ResponseViewModel> deleteBanner(DeleteBannerViewModel deleteBanner)
        {
            var delete = await _repositoryManager.bannerRepository.deleteBanner(deleteBanner);
            return delete;
        }
    }
}
