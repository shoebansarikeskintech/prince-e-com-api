using ViewModel;

namespace ServiceContract
{
    public interface IShippingMethodContract
    {
        public Task<ResponseViewModel> getAllShippingMethod();
        public Task<ResponseViewModel> addShippingMethod(AddShippingMethodViewModel addShippingMethod);
        public Task<ResponseViewModel> updateShippingMethod(UpdateShippingMethodViewModel updateShippingMethod);
        public Task<ResponseViewModel> deleteShippingMethod(DeleteShippingMethodViewModel deleteShippingMethod);

    }
}
