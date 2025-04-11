using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ServiceContract
{
   public interface ISizeContract
    {
        public Task<ResponseViewModel> getByIdSize(Guid sizeId);
        public Task<ResponseViewModel> getAllSize();
        public Task<ResponseViewModel> getAllSizeForUser();
        public Task<ResponseViewModel> addSize(AddSizeViewModel addSize);
        public Task<ResponseViewModel> updateSize(UpdateSizeViewModel updateSize);
        public Task<ResponseViewModel> deleteSize(DeleteSizeViewModel deleteSize);
    }
}
