

using ViewModel;

namespace ServiceContract
{
    public interface IDiscountContract
    {
        public Task<ResponseViewModel> getByIdDiscount(Guid discountId);
        public Task<ResponseViewModel> getAllDiscount();
        public Task<ResponseViewModel> addDiscount(AddDiscountViewModel addDiscount);
        public Task<ResponseViewModel> updateDiscount(UpdateDiscountViewModel updateDiscount);
        public Task<ResponseViewModel> deleteDiscount(DeleteDiscountViewModel deleteDiscount);
    }
}
