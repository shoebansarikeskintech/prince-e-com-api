
using ViewModel;

namespace RepositoryContract
{
   public interface IDiscountRepository
    {
        public Task<ResponseViewModel> getByIdDiscount(Guid discountId);
        public Task<ResponseViewModel> getAllDiscount();
        public Task<ResponseViewModel> addDiscount(AddDiscountViewModel addDiscount);
        public Task<ResponseViewModel> updateDiscount(UpdateDiscountViewModel updateDiscount);
        public Task<ResponseViewModel> deleteDiscount(DeleteDiscountViewModel deleteDiscount);

        public Task<ResponseViewModel> getByIdCoupon(Guid couponId);
        public Task<ResponseViewModel> getAllCoupon();
        public Task<ResponseViewModel> addCoupon(AddCouponViewModel addCoupon);
        public Task<ResponseViewModel> updateCoupon(UpdateCouponViewModel updateCoupon);
        public Task<ResponseViewModel> deleteCoupon(DeleteCouponViewModel deleteCoupon);
    }
}
