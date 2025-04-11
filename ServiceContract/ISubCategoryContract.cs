﻿
using ViewModel;

namespace ServiceContract
{
   public interface ISubCategoryContract
    {
        public Task<ResponseViewModel> getByIdSubCategory(Guid subCategoryId);
        public Task<ResponseViewModel> getAllSubCategory();
        public Task<ResponseViewModel> getAllSubCategoryForUser();
        public Task<ResponseViewModel> addSubCategory(AddSubCategoryViewModel addSubCategory);
        public Task<ResponseViewModel> updateSubCategory(UpdateSubCategoryViewModel updateSubCategory);
        public Task<ResponseViewModel> deleteSubCategory(DeleteSubCategoryViewModel deleteSubCategory);
    }
}
