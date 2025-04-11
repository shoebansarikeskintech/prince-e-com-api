﻿using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
    public class SubCategoryService : ISubCategoryContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public SubCategoryService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getByIdSubCategory(Guid subCategoryId)
        {
            var getByIdSubCategory = await _repositoryManager.subCategoryRepository.getByIdSubCategory(subCategoryId);
            return getByIdSubCategory;
        }

        public async Task<ResponseViewModel> getAllSubCategory()
        {
            var getAllSubCategory = await _repositoryManager.subCategoryRepository.getAllSubCategory();
            return getAllSubCategory;
        }
        public async Task<ResponseViewModel> getAllSubCategoryForUser()
        {
            var getAllSubCategory = await _repositoryManager.subCategoryRepository.getAllSubCategoryForUser();
            return getAllSubCategory;
        }

        public async Task<ResponseViewModel> addSubCategory(AddSubCategoryViewModel addSubCategory)
        {
            var add = await _repositoryManager.subCategoryRepository.addSubCategory(addSubCategory);
            return add;
        }

        public async Task<ResponseViewModel> updateSubCategory(UpdateSubCategoryViewModel updateSubCategory)
        {
            var update = await _repositoryManager.subCategoryRepository.updateSubCategory(updateSubCategory);
            return update;
        }

        public async Task<ResponseViewModel> deleteSubCategory(DeleteSubCategoryViewModel deleteSubCategory)
        {
            var delete = await _repositoryManager.subCategoryRepository.deleteSubCategory(deleteSubCategory);
            return delete;
        }
    }
}
