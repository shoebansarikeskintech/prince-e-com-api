using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using static ViewModel.ConcernViewModel;

namespace ServiceContract
{
    public interface IConcernContract
    {
        public Task<ResponseViewModel> getAllConcernMethod();
        public Task<ResponseViewModel> addConcernMethod(AddConcernViewModel addConcernMethod);
        public Task<ResponseViewModel> updateConcernMethod(UpdateConcernViewModel updateConcernMethod);
        public Task<ResponseViewModel> deleteConcernMethod(DeleteConcernViewModel deleteConcernMethod);
    }
}
