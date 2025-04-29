﻿
using ViewModel;

namespace ServiceContract
{
  public interface IProductContract
    {
        public Task<ResponseViewModel> getByIdProduct(Guid productId);
        public Task<ResponseViewModel> getAllProduct();
        public Task<ResponseViewModel> getBestSeller();
        public Task<ResponseViewModel> getIsRecommended();
        public Task<ResponseViewModel> getIsNewArrial();
        public Task<ResponseViewModel> getAllProductForUser();
        public Task<ResponseViewModel> getAllProductDetails(Int32 id);
        public Task<ResponseViewModelProduct> addProduct(AddProductViewModel addProduct);
        public Task<ResponseViewModel> updateProduct(UpdateProductViewModel updateProduct);
        public Task<ResponseViewModel> deleteProduct(DeleteProductViewModel deleteProduct);


        public Task<ResponseViewModel> getByIdProductImage(Guid productImageId);
        public Task<ResponseViewModel> getAllProductImage(Guid productId);
        public Task<ResponseViewModel> getAllProductImageForUser(Guid productId);
        public Task<ResponseViewModel> addProductImage(AddProductImageViewModel addProductImage);
        public Task<ResponseViewModel> updateProductImage(UpdateProductImageViewModel updateProductImage);
        public Task<ResponseViewModel> deleteProductImage(DeleteProductImageViewModel deleteProductImage);

        public Task<ResponseViewModel> getByIdImage(Guid productId);

        public Task<ResponseViewModel> getAllSteps();

        public Task<ResponseViewModel> addAllSteps(AddStepsViewModel addSteps);
        public Task<ResponseViewModel> updateAllSteps(UpdateStepsViewModel updateSteps);
        public Task<ResponseViewModel> deleteAllSteps(DeleteStepsViewModel deleteSteps);


        public Task<ResponseViewModel> getAllTypeofProduct();

        public Task<ResponseViewModel> addTypeOfProduct(AddTypeOfProductViewModel addTypeOfProduct);
        public Task<ResponseViewModel> updateTypeOfProduct(UpdateTypeOfProductViewModel updateTypeOfProduct);
        public Task<ResponseViewModel> deleteTypeOfProduct(DeleteSTypeOfProductMdoel deleteSTypeOfProduct);
    }
}
