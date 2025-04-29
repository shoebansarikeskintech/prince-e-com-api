using ViewModel;

namespace ServiceContract
{
   public interface IFilterContract
    {
        public Task<ResponseViewModel> getAllSortBy();
        public Task<ResponseViewModel> getAllFilter();
        public Task<ResponseViewModel> getProductSearchByFilter(FilterViewModel model);
        public Task<ResponseViewModel> getProductSearchByFilterNew(FilterViewModelNew model);


        public Task<ResponseViewModel> getAllSkinInsightProduct();
        public Task<ResponseViewModel> addSkinInsightProduct(AddSkinInsightProductViewModel addSkinInsightProduct);
        public Task<ResponseViewModel> deleteSkinInsightProduct(DeleteSkinInsightProductViewModel deleteSkinInsightProduct);

        public Task<ResponseViewModel> updateSkinInsightProduct(UpdateSkinInsightProductViewModel updateSkinInsightProduct);
    }
}
