
using ViewModel;

namespace ServiceContract
{
   public interface IGiftCardContract
    {
        public Task<ResponseViewModel> getByIdGiftCard(Guid giftCardId);
        public Task<ResponseViewModel> getAllGiftCard();
        public Task<ResponseViewModel> addGiftCard(AddGiftCardViewModel addGiftCard);
        public Task<ResponseViewModel> updateGiftCard(UpdateGiftCardViewModel updateGiftCard);
        public Task<ResponseViewModel> deleteGiftCard(DeleteGiftCardViewModel deleteGiftCard);
    }
}
