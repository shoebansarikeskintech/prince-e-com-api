﻿using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
    public class CategoryService : ICategoryContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public CategoryService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getByIdCategory(Guid categoryId)
        {
            var getByIdCategory = await _repositoryManager.categoryRepository.getByIdCategory(categoryId);
            return getByIdCategory;
        }

        public async Task<ResponseViewModel> getAllCategory()
        {
            var getAllCategory = await _repositoryManager.categoryRepository.getAllCategory();
            return getAllCategory;
        }
        public async Task<ResponseViewModel> getAllCategoryForUser()
        {
            var getAllCategory = await _repositoryManager.categoryRepository.getAllCategoryForUser();
            return getAllCategory;
        }

        public async Task<ResponseViewModel> addCategory(AddCategoryViewModel addCategory)
        {
            var add = await _repositoryManager.categoryRepository.addCategory(addCategory);
            return add;
        }

        public async Task<ResponseViewModel> updateCategory(UpdateCategoryViewModel updateCategory)
        {
            var update = await _repositoryManager.categoryRepository.updateCategory(updateCategory);
            return update;
        }

        public async Task<ResponseViewModel> deleteCategory(DeleteCategoryViewModel deleteCategory)
        {
            var delete = await _repositoryManager.categoryRepository.deleteCategory(deleteCategory);
            return delete;
        }
    }
}
