using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
   public class SizeService: ISizeContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public SizeService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getByIdSize(Guid sizeId)
        {
            var getByIdSize = await _repositoryManager.sizeRepository.getByIdSize(sizeId);
            return getByIdSize;
        }

        public async Task<ResponseViewModel> getAllSize()
        {
            var getAllSize = await _repositoryManager.sizeRepository.getAllSize();
            return getAllSize;
        }

        public async Task<ResponseViewModel> getAllSizeForUser()
        {
            var getAllSizeForUser = await _repositoryManager.sizeRepository.getAllSizeForUser();
            return getAllSizeForUser;
        }

        public async Task<ResponseViewModel> addSize(AddSizeViewModel addSize)
        {
            var add = await _repositoryManager.sizeRepository.addSize(addSize);
            return add;
        }

        public async Task<ResponseViewModel> updateSize(UpdateSizeViewModel updateSize)
        {
            var update = await _repositoryManager.sizeRepository.updateSize(updateSize);
            return update;
        }

        public async Task<ResponseViewModel> deleteSize(DeleteSizeViewModel deleteSize)
        {
            var delete = await _repositoryManager.sizeRepository.deleteSize(deleteSize);
            return delete;
        }
    }
}
