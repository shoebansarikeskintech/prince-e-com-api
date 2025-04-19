using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
    public class DiscountService : IDiscountContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public DiscountService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getByIdDiscount(Guid discountId)
        {
            var getByIdDiscount = await _repositoryManager.discountRepository.getByIdDiscount(discountId);
            return getByIdDiscount;
        }

        public async Task<ResponseViewModel> getAllDiscount()
        {
            var getAllCategory = await _repositoryManager.discountRepository.getAllDiscount();
            return getAllCategory;
        }

        public async Task<ResponseViewModel> addDiscount(AddDiscountViewModel addDiscount)
        {
            var add = await _repositoryManager.discountRepository.addDiscount(addDiscount);
            return add;
        }

        public async Task<ResponseViewModel> updateDiscount(UpdateDiscountViewModel updateDiscount)
        {
            var update = await _repositoryManager.discountRepository.updateDiscount(updateDiscount);
            return update;
        }

        public async Task<ResponseViewModel> deleteDiscount(DeleteDiscountViewModel deleteDiscount)
        {
            var delete = await _repositoryManager.discountRepository.deleteDiscount(deleteDiscount);
            return delete;
        }

        /// <summary>
        /// Add Coupon 
        /// </summary>
        /// <param name="discountId"></param>
        /// <returns></returns>
        public async Task<ResponseViewModel> getByIdCoupon(Guid couponId)
        {
            var getByIdCoupon = await _repositoryManager.discountRepository.getByIdCoupon(couponId);
            return getByIdCoupon;
        }

        public async Task<ResponseViewModel> getAllCoupon()
        {
            var getAllCoupon = await _repositoryManager.discountRepository.getAllCoupon();
            return getAllCoupon;
        }

        public async Task<ResponseViewModel> addCoupon(AddCouponViewModel addCoupon)
        {
            var add = await _repositoryManager.discountRepository.addCoupon(addCoupon);
            return add;
        }

        public async Task<ResponseViewModel> updateCoupon(UpdateCouponViewModel updateCoupon)
        {
            var update = await _repositoryManager.discountRepository.updateCoupon(updateCoupon);
            return update;
        }

        public async Task<ResponseViewModel> deleteCoupon(DeleteCouponViewModel deleteCoupon)
        {
            var delete = await _repositoryManager.discountRepository.deleteCoupon(deleteCoupon);
            return delete;
        }
    }
}
