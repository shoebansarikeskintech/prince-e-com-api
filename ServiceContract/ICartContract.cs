
using ViewModel;

namespace ServiceContract
{
   public interface ICartContract
    {
        public Task<ResponseViewModel> getCartItemCount(Guid userId);
        public Task<ResponseViewModel> getCartList(Guid userId);
        public Task<ResponseViewModel> addProductInCart(AddProductInCartViewModel addProductInCart);
        public Task<ResponseViewModel> updateQuantityInCart(UpdateQuantityInCartViewModel updateQuantityInCart);
        public Task<ResponseViewModel> productRemoveInCart(RemoveProductInCartViewModel removeProductInCart);
    }
}
