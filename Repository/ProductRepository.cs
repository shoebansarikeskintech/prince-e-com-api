using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using static Model.ModelType;
using ViewModel;
using Common;


namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _dapperContext;
        public ProductRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;      
        public async Task<ResponseViewModel> getByIdProduct(Guid productId)
        {
            var procedureName = Constant.spGetByIdProduct;
            var parameters = new DynamicParameters();
            parameters.Add("@productId", productId, DbType.Guid);

            using (var connection = _dapperContext.createConnection())
            {
                var result = (await connection.QueryAsync<Productdetaisl>(procedureName, parameters, commandType: CommandType.StoredProcedure)).ToList();

                var product = result.FirstOrDefault(); 
                var imageUrls = result.Select(x => x.ImageUrl).ToList(); 

                var getbyIdProduct = new ResponseViewModel
                {
                    statusCode = product != null ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
                    message = product != null ? "Data Found" : "Data Not Found",
                    data = product != null ? new
                    {
                        productDetails = new
                        {
                            id = product.Id,
                            productId = product.ProductId.ToString(),
                            categoryId = product.CategoryId.ToString(),
                            categoryName = product.CategoryName,
                            subCategoryId = product.SubCategoryId.ToString(),
                            subCategoryName = product.SubCategoryName,
                            subCategoryTypeId = product.SubCategoryTypeId.ToString(),
                            subCategoryTypeName = product.SubCategoryTypeName,
                            sellerId = product.SellerId.ToString(),
                            sellerName = product.SellerName,
                            brandId = product.BrandId.ToString(),
                            brandName = product.BrandName,
                            colorId = product.ColorId.ToString(),
                            colorName = product.ColorName,
                            colorCode = product.ColorCode,
                            sizeId = product.SizeId.ToString(),
                            sizeName = product.SizeName,
                            sizeCode = product.SizeCode,
                            productName = product.ProductName,
                            subName = product.SubName,
                            description = product.Description,
                            rating = product.Rating,
                            noOfRating = product.NoOfRating,
                            stock = product.Stock,
                            price = product.Price,
                            discountPrice = product.DiscountPrice,
                            createdDate = product.CreatedDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                            updatedDate = product.UpdatedDate != DateTime.MinValue ? product.UpdatedDate.ToString("yyyy-MM-ddTHH:mm:ss") : null,
                            status = product.Status,
                            active = product.Active,
                            concernName = product.concernName,
                            ingredientName = product.ingredientName,
                            ConcernId = product.ConcernId,
                            IngredientId = product.IngredientId,
                            imageUrls = imageUrls
                        },
                       
                    } : null
                };

                return getbyIdProduct;
            }
        }

     
        public async Task<ResponseViewModel> getAllProduct()
        {
            var procedureName = Constant.spGetAllProduct;
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Product>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllProduct = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllProduct;
            }
        }

        public async Task<ResponseViewModel> getBestSeller()
        {
            var procedureName = Constant.spGetBestSeller;
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Product>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllProduct = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllProduct;
            }
        }
        public async Task<ResponseViewModel> getAllProductForUser()
        {
            var procedureName = Constant.spGetAllProductForUser;
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Product>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllProductForUser = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllProductForUser;
            }
        }
        public async Task<ResponseViewModel> getAllProductDetails(Guid productId)
        {
            var procedureName = Constant.spGetAllProductDetails;
            using (var connection = _dapperContext.createConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@productId", productId, DbType.Guid);
                var result = await connection.QueryAsync<ProductDetails>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getAllProductForUser = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllProductForUser;
            }
        }
        public async Task<ResponseViewModel> addProduct(AddProductViewModel addProduct)
        {
            var procedureName = Constant.spAddProduct;
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", addProduct.categoryId, DbType.Guid);
            parameters.Add("@subCategoryId", addProduct.subCategoryId, DbType.Guid);
            parameters.Add("@subCategoryTypeId", addProduct.subCategoryTypeId, DbType.Guid);
            parameters.Add("@sellerId", addProduct.sellerId, DbType.Guid);
            parameters.Add("@brandId", addProduct.brandId, DbType.Guid);
            parameters.Add("@colorId", addProduct.colorId, DbType.Guid);
            parameters.Add("@sizeId", addProduct.sizeId, DbType.Guid);
            parameters.Add("@title", addProduct.title, DbType.String);
            parameters.Add("@subTitle", addProduct.subTitle, DbType.String);
            parameters.Add("@rating", addProduct.rating, DbType.Int32);
            parameters.Add("@noOfRating", addProduct.noOfRating, DbType.Int32);
            parameters.Add("@stock", addProduct.stock, DbType.Int32);
            parameters.Add("@price", addProduct.price, DbType.Decimal);
            parameters.Add("@discountPrice", addProduct.discountPrice, DbType.Decimal);
            parameters.Add("@description", addProduct.description, DbType.String);
            parameters.Add("@createdBy", addProduct.createdBy, DbType.Guid);
            parameters.Add("@ConcernId", addProduct.ConcernId, DbType.Guid);
            parameters.Add("@IngredientId", addProduct.IngredientId, DbType.Guid);

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (result.statusCode == 1)
                {
                    result.statusCode = (int)HttpStatusCode.OK;
                    result.message = result.message;
                }
                else if (result.statusCode == 0)
                {
                    result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                    result.message = result.message;
                }
                else
                {
                    result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                    result.message = result.message;
                }
                return result;
            }
        }
        public async Task<ResponseViewModel> updateProduct(UpdateProductViewModel updateProduct)
        {

            var procedureName = Constant.spUpdateProduct;
            var parameters = new DynamicParameters();
            parameters.Add("@productId", updateProduct.productId, DbType.Guid);
            parameters.Add("@categoryId", updateProduct.categoryId, DbType.Guid);
            parameters.Add("@subCategoryId", updateProduct.subCategoryId, DbType.Guid);
            parameters.Add("@subCategoryTypeId", updateProduct.subCategoryTypeId, DbType.Guid);
            parameters.Add("@sellerId", updateProduct.sellerId, DbType.Guid);
            parameters.Add("@brandId", updateProduct.brandId, DbType.Guid);
            parameters.Add("@colorId", updateProduct.colorId, DbType.Guid);
            parameters.Add("@sizeId", updateProduct.sizeId, DbType.Guid);
            parameters.Add("@title", updateProduct.title, DbType.String);
            parameters.Add("@subTitle", updateProduct.subTitle, DbType.String);
            parameters.Add("@rating", updateProduct.rating, DbType.Int32);
            parameters.Add("@noOfRating", updateProduct.noOfRating, DbType.Int32);
            parameters.Add("@stock", updateProduct.stock, DbType.Int32);
            parameters.Add("@price", updateProduct.price, DbType.Decimal);
            parameters.Add("@discountPrice", updateProduct.discountPrice, DbType.Decimal);
            parameters.Add("@description", updateProduct.description, DbType.String);
            parameters.Add("@active", updateProduct.active ? 1 : 0, DbType.Boolean);
            parameters.Add("@updatedBy", updateProduct.updatedBy, DbType.Guid);
            parameters.Add("@ConcernId", updateProduct.ConcernId, DbType.Guid);
            parameters.Add("@IngredientId", updateProduct.IngredientId, DbType.Guid);

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (result.statusCode == 1)
                {
                    result.statusCode = (int)HttpStatusCode.OK;
                    result.message = result.message;
                }
                else if (result.statusCode == 0)
                {
                    result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                    result.message = result.message;
                }
                else
                {
                    result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                    result.message = result.message;
                }
                return result;
            }
        }
        public async Task<ResponseViewModel> deleteProduct(DeleteProductViewModel deleteProduct)
        {
            var procedureName = Constant.spDeleteProduct;
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", deleteProduct.categoryId, DbType.Guid);
            parameters.Add("@subCategoryId", deleteProduct.subCategoryId, DbType.Guid);
            parameters.Add("@subCategoryTypeId", deleteProduct.subCategoryTypeId, DbType.Guid);
            parameters.Add("@productId", deleteProduct.productId, DbType.Guid);
            parameters.Add("@updatedBy", deleteProduct.updatedBy, DbType.Guid);

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (result.statusCode == 1)
                {
                    result.statusCode = (int)HttpStatusCode.OK;
                    result.message = result.message;
                }
                else if (result.statusCode == 0)
                {
                    result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                    result.message = result.message;
                }
                else
                {
                    result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                    result.message = result.message;
                }
                return result;
            }
        }
        public async Task<ResponseViewModel> getByIdProductImage(Guid productImageId)
        {
            var procedureName = Constant.spGetByIdProductImage;
            var parameters = new DynamicParameters();
            parameters.Add("@productImageId", productImageId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<ProductImage>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyIdProductImage = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getbyIdProductImage;
            }
        }
        public async Task<ResponseViewModel> getAllProductImage(Guid productId)
        {
            var procedureName = Constant.spGetAllProductImage;
            var parameters = new DynamicParameters();
            parameters.Add("@productId", productId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<ProductImage>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getAllProductImage = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllProductImage;
            }
        }
        public async Task<ResponseViewModel> getAllProductImageForUser(Guid productId)
        {
            var procedureName = Constant.spGetAllProductImageForUser;
            var parameters = new DynamicParameters();
            parameters.Add("@productId", productId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<ProductImage>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getAllProductImageForUser = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllProductImageForUser;
            }
        }
        public async Task<ResponseViewModel> addProductImage(AddProductImageViewModel addProductImage)
        {
            string imagePath = null;
            var result = new ResponseViewModel
            {
                statusCode = (int)HttpStatusCode.ExpectationFailed,
                message = "No images were processed."
            };

            foreach (var imageFile in addProductImage.image)
            {

                if (imageFile != null)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    string uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImage");
                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }
                    string filePath = Path.Combine(uploadDir, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }
                    imagePath = uniqueFileName;
                }


                var procedureName = Constant.spAddProductImage;
                var parameters = new DynamicParameters();
                parameters.Add("@productId", addProductImage.productId, DbType.Guid);
                parameters.Add("@title", addProductImage.title, DbType.String);
                parameters.Add("@image",imagePath, DbType.String);
                parameters.Add("@createdBy", addProductImage.createdBy, DbType.Guid);

                using (var connection = _dapperContext.createConnection())
                {
                    var result1 = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                    result = result1;
                }
            }
            if (result.statusCode == 1)
            {
                result.statusCode = (int)HttpStatusCode.OK;
                result.message = result.message;
            }
            else if (result.statusCode == 0)
            {
                result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                result.message = result.message;
            }
            else
            {
                result.message = result.message;
                result.statusCode = (int)HttpStatusCode.ExpectationFailed;
            }
            return result;
        }
        public async Task<ResponseViewModel> updateProductImage(UpdateProductImageViewModel updateProductImage)
        {

            string imagePath = "NaN";
            var result = new ResponseViewModel
            {
                statusCode = (int)HttpStatusCode.ExpectationFailed,
                message = "No images were processed."
            };

            foreach (var imageFile in updateProductImage.image)
            {

                if (imageFile != null)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    string uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImage");
                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }
                    string filePath = Path.Combine(uploadDir, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }
                    imagePath = uniqueFileName;
                }

                var procedureName = Constant.spUpdateProductImage;
                var parameters = new DynamicParameters();
                parameters.Add("@productImageId", updateProductImage.productImageId, DbType.Guid);
                parameters.Add("@productId", updateProductImage.productId, DbType.Guid);
                parameters.Add("@title", updateProductImage.title, DbType.String);
                parameters.Add("@image", imagePath, DbType.String);
                parameters.Add("@updatedBy", updateProductImage.updatedBy, DbType.Guid);

                using (var connection = _dapperContext.createConnection())
                {
                    var result1 = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                    result = result1;
                }
            }
            if (result.statusCode == 1)
            {
                result.statusCode = (int)HttpStatusCode.OK;
                result.message = result.message;
            }
            else if (result.statusCode == 0)
            {
                result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                result.message = result.message;
            }
            else
            {
                result.message = result.message;
                result.statusCode = (int)HttpStatusCode.ExpectationFailed;
            }
            return result;
        }
        public async Task<ResponseViewModel> deleteProductImage(DeleteProductImageViewModel deleteProductImage)
        {
            var procedureName = Constant.spDeleteProductImage;
            var parameters = new DynamicParameters();
            parameters.Add("@productImageId", deleteProductImage.productImageId, DbType.Guid);
            parameters.Add("@productId", deleteProductImage.productId, DbType.Guid);
            parameters.Add("@updatedBy", deleteProductImage.updatedBy, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (result.statusCode == 1)
                {
                    result.statusCode = (int)HttpStatusCode.OK;
                    result.message = result.message;
                }
                else if (result.statusCode == 0)
                {
                    result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                    result.message = result.message;
                }
                else
                {
                    result.message = result.message;
                    result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                }
                return result;
            }
        }

        public async Task<ResponseViewModel> getByIdImage(Guid productId)
        {
            var procedureName = Constant.spGetAllImageById;
            using (var connection = _dapperContext.createConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@productId", productId, DbType.Guid);
                var result = await connection.QueryAsync<ProductbyIdImage>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getAllProductForUser = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllProductForUser;
            }
        }
    }
}

