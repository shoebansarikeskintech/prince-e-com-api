
using ViewModel;

namespace RepositoryContract
{
    public interface ICategoryRepository
    {
        public Task<ResponseViewModel> getByIdCategory(Guid categoryId);
        public Task<ResponseViewModel> getAllCategory();
        public Task<ResponseViewModel> getAllCategoryForUser();
        public Task<ResponseViewModel> addCategory(AddCategoryViewModel addCategory);
        public Task<ResponseViewModel> updateCategory(UpdateCategoryViewModel updateCategory);
        public Task<ResponseViewModel> deleteCategory(DeleteCategoryViewModel deleteCategory);
    }
}
