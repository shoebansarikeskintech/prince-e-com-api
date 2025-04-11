
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
    }
}
