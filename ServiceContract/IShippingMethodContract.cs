using ViewModel;

namespace ServiceContract
{
    public interface IShippingMethodContract
    {
        public Task<ResponseViewModel> getAllShippingMethod();
        public Task<ResponseViewModel> addShippingMethod(AddShippingMethodViewModel addShippingMethod);
        public Task<ResponseViewModel> updateShippingMethod(UpdateShippingMethodViewModel updateShippingMethod);
        public Task<ResponseViewModel> deleteShippingMethod(DeleteShippingMethodViewModel deleteShippingMethod);

        public Task<ResponseViewModel> getAllPinCodeShippingMethod();
        public Task<ResponseViewModel> addPinCodeShippingMethod(AddPinCodeShippingViewModel addPinCodeshippingMethod);
        public Task<ResponseViewModel> updatePinCodeShippingMethod(UpdatePinCodeShippingViewModel updateShippingMethod);
        public Task<ResponseViewModel> deletePinCodeShippingMethod(DeletePinCodeShippingViewModel DeletePinCodeshippingMethod);
        public Task<ResponseViewModel> getAllPinCode(int pinCode);
        
  

    }
}
