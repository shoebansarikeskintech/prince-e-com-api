
using ViewModel;

namespace ServiceContract
{
    public interface IBrandContract
    {
        public Task<ResponseViewModel> getByIdBrand(Guid brandId);
        public Task<ResponseViewModel> getAllBrand();
        public Task<ResponseViewModel> getAllBrandForUser();
        public Task<ResponseViewModel> addBrand(AddBrandViewModel addBrand);
        public Task<ResponseViewModel> updateBrand(UpdateBrandViewModel updateBrand);
        public Task<ResponseViewModel> deleteBrand(DeleteBrandViewModel deleteBrand);
    }
}
