using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
    public class GiftCardService : IGiftCardContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public GiftCardService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getByIdGiftCard(Guid giftCardId)
        {
            var getByIdCategory = await _repositoryManager.giftCardRepository.getByIdGiftCard(giftCardId);
            return getByIdCategory;
        }

        public async Task<ResponseViewModel> getAllGiftCard()
        {
            var getAllCategory = await _repositoryManager.giftCardRepository.getAllGiftCard();
            return getAllCategory;
        }

        public async Task<ResponseViewModel> addGiftCard(AddGiftCardViewModel addGiftCard)
        {
            var add = await _repositoryManager.giftCardRepository.addGiftCard(addGiftCard);
            return add;
        }

        public async Task<ResponseViewModel> updateGiftCard(UpdateGiftCardViewModel updateGiftCard)
        {
            var update = await _repositoryManager.giftCardRepository.updateGiftCard(updateGiftCard);
            return update;
        }

        public async Task<ResponseViewModel> deleteGiftCard(DeleteGiftCardViewModel deleteGiftCard)
        {
            var delete = await _repositoryManager.giftCardRepository.deleteGiftCard(deleteGiftCard);
            return delete;
        }
    }
}
