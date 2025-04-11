﻿
using ViewModel;

namespace ServiceContract
{
  public interface IProductContract
    {
        public Task<ResponseViewModel> getByIdProduct(Guid productId);
        public Task<ResponseViewModel> getAllProduct();
        public Task<ResponseViewModel> getAllProductForUser();
        public Task<ResponseViewModel> getAllProductDetails(Guid productId);
        public Task<ResponseViewModel> addProduct(AddProductViewModel addProduct);
        public Task<ResponseViewModel> updateProduct(UpdateProductViewModel updateProduct);
        public Task<ResponseViewModel> deleteProduct(DeleteProductViewModel deleteProduct);


        public Task<ResponseViewModel> getByIdProductImage(Guid productImageId);
        public Task<ResponseViewModel> getAllProductImage(Guid productId);
        public Task<ResponseViewModel> getAllProductImageForUser(Guid productId);
        public Task<ResponseViewModel> addProductImage(AddProductImageViewModel addProductImage);
        public Task<ResponseViewModel> updateProductImage(UpdateProductImageViewModel updateProductImage);
        public Task<ResponseViewModel> deleteProductImage(DeleteProductImageViewModel deleteProductImage);
    }
}
