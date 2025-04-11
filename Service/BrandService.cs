using RepositoryContract;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service
{
   public class BrandService : IBrandContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public BrandService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getByIdBrand(Guid brandId)
        {
            var getByIdBrand = await _repositoryManager.brandRepository.getByIdBrand(brandId);
            return getByIdBrand;
        }

        public async Task<ResponseViewModel> getAllBrand()
        {
            var getAllBrand = await _repositoryManager.brandRepository.getAllBrand();
            return getAllBrand;
        }

        public async Task<ResponseViewModel> getAllBrandForUser()
        {
            var getAllBrandForUser = await _repositoryManager.brandRepository.getAllBrandForUser();
            return getAllBrandForUser;
        }

        public async Task<ResponseViewModel> addBrand(AddBrandViewModel addBrand)
        {
            var add = await _repositoryManager.brandRepository.addBrand(addBrand);
            return add;
        }

        public async Task<ResponseViewModel> updateBrand(UpdateBrandViewModel updateBrand)
        {
            var update = await _repositoryManager.brandRepository.updateBrand(updateBrand);
            return update;
        }

        public async Task<ResponseViewModel> deleteBrand(DeleteBrandViewModel deleteBrand)
        {
            var delete = await _repositoryManager.brandRepository.deleteBrand(deleteBrand);
            return delete;
        }
    }
}

