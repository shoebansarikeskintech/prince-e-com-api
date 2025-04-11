using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace RepositoryContract
{
   public interface IAddressRepository
    {
        public Task<ResponseViewModel> getDefaultAddress(Guid userId);
        public Task<ResponseViewModel> getAddressList(Guid userId);
        public Task<ResponseViewModel> addAddress(AddAddressViewModel addAddress);
        public Task<ResponseViewModel> updateAddress(UpdateAddressViewModel updateAddress);
        public Task<ResponseViewModel> deleteAddress(DeleteAddressViewModel deleteAddress);
    }
}
