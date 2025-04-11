
using ViewModel;

namespace RepositoryContract
{
    public interface IColorRepository
    {
        public Task<ResponseViewModel> getByIdColor(Guid colorId);
        public Task<ResponseViewModel> getAllColor();
        public Task<ResponseViewModel> getAllColorForUser();
        public Task<ResponseViewModel> addColor(AddColorViewModel addColor);
        public Task<ResponseViewModel> updateColor(UpdateColorViewModel updateColor);
        public Task<ResponseViewModel> deleteColor(DeleteColorViewModel deleteColor);
    }
}
