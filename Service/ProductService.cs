using RepositoryContract;
using ServiceContract;
using ViewModel;

namespace Service
{
    public class ProductService : IProductContract
    {
        private readonly IRepositoryManager _repositoryManager;
        public ProductService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ResponseViewModel> getByIdProduct(Guid productId)
        {
            var getByIdProduct = await _repositoryManager.productRepository.getByIdProduct(productId);
            return getByIdProduct;
        }

        public async Task<ResponseViewModel> getAllProduct()
        {
            var getAllProduct = await _repositoryManager.productRepository.getAllProduct();
            return getAllProduct;
        }

        public async Task<ResponseViewModel> getBestSeller()
        {
            var getAllProduct = await _repositoryManager.productRepository.getBestSeller();
            return getAllProduct;
        }

        public async Task<ResponseViewModel> getIsRecommended()
        {
            var getAllProduct = await _repositoryManager.productRepository.getIsRecommended();
            return getAllProduct;
        }

        public async Task<ResponseViewModel> getIsNewArrial()
        {
            var getAllProduct = await _repositoryManager.productRepository.getIsNewArrial();
            return getAllProduct;
        }
        public async Task<ResponseViewModel> getAllProductForUser()
        {
            var getAllProductForUser = await _repositoryManager.productRepository.getAllProductForUser();
            return getAllProductForUser;
        }

        public async Task<ResponseViewModel> getAllProductDetails(Int32 id)
        {
            var getAllProductDetails = await _repositoryManager.productRepository.getAllProductDetails(id);
            return getAllProductDetails;
        }

        public async Task<ResponseViewModelProduct> addProduct(AddProductViewModel addProduct)
        {
            var add = await _repositoryManager.productRepository.addProduct(addProduct);
            return add;
        }

        public async Task<ResponseViewModel> updateProduct(UpdateProductViewModel updateProduct)
        {
            var update = await _repositoryManager.productRepository.updateProduct(updateProduct);
            return update;
        }

        public async Task<ResponseViewModel> deleteProduct(DeleteProductViewModel deleteProduct)
        {
            var delete = await _repositoryManager.productRepository.deleteProduct(deleteProduct);
            return delete;
        }


        public async Task<ResponseViewModel> getByIdProductImage(Guid productImageId)
        {
            var getByIdCategory = await _repositoryManager.productRepository.getByIdProductImage(productImageId);
            return getByIdCategory;
        }

        public async Task<ResponseViewModel> getAllProductImage(Guid productId)
        {
            var getAllCategory = await _repositoryManager.productRepository.getAllProductImage(productId);
            return getAllCategory;
        }

        public async Task<ResponseViewModel> getAllProductImageForUser(Guid productId)
        {
            var getAllCategory = await _repositoryManager.productRepository.getAllProductImageForUser(productId);
            return getAllCategory;
        }

        public async Task<ResponseViewModel> addProductImage(AddProductImageViewModel addProductImage)
        {
            var add = await _repositoryManager.productRepository.addProductImage(addProductImage);
            return add;
        }

        public async Task<ResponseViewModel> updateProductImage(UpdateProductImageViewModel updateProductImage)
        {
            var update = await _repositoryManager.productRepository.updateProductImage(updateProductImage);
            return update;
        }

        public async Task<ResponseViewModel> deleteProductImage(DeleteProductImageViewModel deleteProductImage)
        {
            var delete = await _repositoryManager.productRepository.deleteProductImage(deleteProductImage);
            return delete;
        }

        public async Task<ResponseViewModel> getByIdImage(Guid productId)
        {
            var getByIdImage = await _repositoryManager.productRepository.getByIdImage(productId);
            return getByIdImage;
        }

        public async Task<ResponseViewModel> getAllSteps()
        {
            var getAllSteps = await _repositoryManager.productRepository.getAllSteps();
            return getAllSteps;
        }

        public async Task<ResponseViewModel> getAllActiveSteps()
        {
            var getAllActiveSteps = await _repositoryManager.productRepository.getAllActiveSteps();
            return getAllActiveSteps;
        }
        public async Task<ResponseViewModel> addAllSteps(AddStepsViewModel addSteps)
        {
            var add = await _repositoryManager.productRepository.addAllSteps(addSteps);
            return add;
        }

        public async Task<ResponseViewModel> updateAllSteps(UpdateStepsViewModel updateSteps)
        {
            var update = await _repositoryManager.productRepository.updateAllSteps(updateSteps);
            return update;
        }

        public async Task<ResponseViewModel> deleteAllSteps(DeleteStepsViewModel deleteSteps)
        {
            var delete = await _repositoryManager.productRepository.deleteAllSteps(deleteSteps);
            return delete;
        }
        public async Task<ResponseViewModel> getAllTypeofProduct()
        {
            var getAllTypeofProduct = await _repositoryManager.productRepository.getAllTypeofProduct();
            return getAllTypeofProduct;
        }

        public async Task<ResponseViewModel> getAllTypeofActiveProduct()
        {
            var getAllTypeofActiveProduct = await _repositoryManager.productRepository.getAllTypeofActiveProduct();
            return getAllTypeofActiveProduct;
        }
        public async Task<ResponseViewModel> addTypeOfProduct(AddTypeOfProductViewModel addTypeOfProduct)
        {
            var add = await _repositoryManager.productRepository.addTypeOfProduct(addTypeOfProduct);
            return add;
        }

        public async Task<ResponseViewModel> updateTypeOfProduct(UpdateTypeOfProductViewModel updateTypeOfProduct)
        {
            var update = await _repositoryManager.productRepository.updateTypeOfProduct(updateTypeOfProduct);
            return update;
        }
        public async Task<ResponseViewModel> deleteTypeOfProduct(DeleteSTypeOfProductMdoel deleteSTypeOfProduct)
        {
            var delete = await _repositoryManager.productRepository.deleteTypeOfProduct(deleteSTypeOfProduct);
            return delete;
        }

        public async Task<ResponseViewModel> searchProduct(SearchCommonDataViewModel searchCommonData)
        {
            var search = await _repositoryManager.productRepository.searchProduct(searchCommonData);
            return search;
        }

        public async Task<ResponseViewModel> searchProductNew(string commonTypeSearch)
        {
            var searchProductNew = await _repositoryManager.productRepository.searchProductNew(commonTypeSearch);
            return searchProductNew;
        }

    }
}
