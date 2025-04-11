using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
    public class ColorService : IColorContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public ColorService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getByIdColor(Guid colorId)
        {
            var getByIdColor = await _repositoryManager.colorRepository.getByIdColor(colorId);
            return getByIdColor;
        }

        public async Task<ResponseViewModel> getAllColor()
        {
            var getAllColor = await _repositoryManager.colorRepository.getAllColor();
            return getAllColor;
        }

        public async Task<ResponseViewModel> getAllColorForUser()
        {
            var getAllColor = await _repositoryManager.colorRepository.getAllColorForUser();
            return getAllColor;
        }

        public async Task<ResponseViewModel> addColor(AddColorViewModel addColor)
        {
            var add = await _repositoryManager.colorRepository.addColor(addColor);
            return add;
        }

        public async Task<ResponseViewModel> updateColor(UpdateColorViewModel updateColor)
        {
            var update = await _repositoryManager.colorRepository.updateColor(updateColor);
            return update;
        }

        public async Task<ResponseViewModel> deleteColor(DeleteColorViewModel deleteColor)
        {
            var delete = await _repositoryManager.colorRepository.deleteColor(deleteColor);
            return delete;
        }
    }
}
