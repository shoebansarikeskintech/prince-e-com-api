using RepositoryContract;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using static ViewModel.ConcernViewModel;

namespace Service
{
    public class ConcernService: IConcernContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public ConcernService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getAllConcernMethod()
        {
            var getConcernMethod = await _repositoryManager.concernReposotory.getAllConcernMethod();
            return getConcernMethod;
        }

        public async Task<ResponseViewModel> addConcernMethod(AddConcernViewModel addConcernMethod)
        {
            var add = await _repositoryManager.concernReposotory.addConcernMethod(addConcernMethod);
            return add;
        }

        public async Task<ResponseViewModel> updateConcernMethod(UpdateConcernViewModel updateConcernMethod)
        {
            var update = await _repositoryManager.concernReposotory.updateConcernMethod(updateConcernMethod);
            return update;
        }

        public async Task<ResponseViewModel> deleteConcernMethod(DeleteConcernViewModel deleteConcernMethod)
        {
            var delete = await _repositoryManager.concernReposotory.deleteConcernMethod(deleteConcernMethod);
            return delete;
        }
    }
}
