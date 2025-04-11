
using ViewModel;

namespace RepositoryContract
{
  public  interface IBannerRepository
    {
        public Task<ResponseViewModel> getByIdBanner(Guid bannerId);
        public Task<ResponseViewModel> getAllBanner();
        public Task<ResponseViewModel> addBanner(AddBannerViewModel addBanner);
        public Task<ResponseViewModel> updateBanner(UpdateBannerViewModel updateBanner);
        public Task<ResponseViewModel> deleteBanner(DeleteBannerViewModel deleteBanner);
    }
}
