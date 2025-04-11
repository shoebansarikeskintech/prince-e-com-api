
using ViewModel;

namespace RepositoryContract
{
   public interface ISizeRepository
    {
        public Task<ResponseViewModel> getByIdSize(Guid sizeId);
        public Task<ResponseViewModel> getAllSize();
        public Task<ResponseViewModel> getAllSizeForUser();
        public Task<ResponseViewModel> addSize(AddSizeViewModel addSize);
        public Task<ResponseViewModel> updateSize(UpdateSizeViewModel updateSize);
        public Task<ResponseViewModel> deleteSize(DeleteSizeViewModel deleteSize);
    }
}
