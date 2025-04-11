using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
    public class CartService : ICartContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public CartService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getCartItemCount(Guid userId)
        {
            var getCartItemCount = await _repositoryManager.cartRepository.getCartItemCount(userId);
            return getCartItemCount;
        }

        public async Task<ResponseViewModel> getCartList(Guid userId)
        {
            var getCartList = await _repositoryManager.cartRepository.getCartList(userId);
            return getCartList;
        }

        public async Task<ResponseViewModel> addProductInCart(AddProductInCartViewModel addProductInCart)
        {
            var add = await _repositoryManager.cartRepository.addProductInCart(addProductInCart);
            return add;
        }

        public async Task<ResponseViewModel> updateQuantityInCart(UpdateQuantityInCartViewModel updateQuantityInCart)
        {
            var update = await _repositoryManager.cartRepository.updateQuantityInCart(updateQuantityInCart);
            return update;
        }

        public async Task<ResponseViewModel> productRemoveInCart(RemoveProductInCartViewModel removeProductInCart)
        {
            var delete = await _repositoryManager.cartRepository.productRemoveInCart(removeProductInCart);
            return delete;
        }
    }
}