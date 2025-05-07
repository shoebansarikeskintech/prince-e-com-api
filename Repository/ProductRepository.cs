using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using static Model.ModelType;
using ViewModel;
using Common;
using static Repository.OrderRepository;
using Microsoft.AspNetCore.Http;


namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _dapperContext;
        public ProductRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;

        public async Task<ResponseViewModel> getByIdProduct(getAllProductByIdViewModel getAllProductById)
        {
            Guid productId;

            // Try to parse getAllProductById.id as GUID
            bool isGuid = Guid.TryParse(getAllProductById.id, out productId);

            // Agar GUID nahi hai, toh assume karo int-type ID hai (1, 2, 3 etc.)
            if (!isGuid)
            {
                var procedureProductById = Constant.spGetAllProductById;
                var parametersId = new DynamicParameters();
                parametersId.Add("@id", getAllProductById.id.ToString(), DbType.String);

                using (var connection = _dapperContext.createConnection())
                {
                    productId = connection.QueryFirstOrDefault<Guid>(
                        procedureProductById,
                        parametersId,
                        commandType: CommandType.StoredProcedure
                    );
                }
            }

            // Ab productId ready hai (chahe pehle se GUID ho ya query karke mila ho)
       
            var procedureName = Constant.spGetByIdProduct;
            var procedureFAQ = Constant.spGetAllProductFAQbyProductId;
            var SkinInsight = Constant.spGetAllSkinInsightByProductId;
            var Ingredient = Constant.spGetAllProductFAQIngredientbyProductId;
            var FaqWithProduct = Constant.spGetAllProductFAQWithProductbyProductId;
            var AllSimilarProduct = Constant.spGetAllSimilarProductByProductId;

            var parameters = new DynamicParameters();
            parameters.Add("@productId", productId, DbType.Guid);
            //parameters.Add("@productId", productId, DbType.Guid);

            using (var connection = _dapperContext.createConnection())
            {
                // 1) Fetch main product details
                var result = (await connection
                    .QueryAsync<Productdetaisl>(procedureName, parameters, commandType: CommandType.StoredProcedure))
                    .ToList();

                // 2) Fetch FAQs
                var faqList = (await connection
                    .QueryAsync<Faq>(procedureFAQ, parameters, commandType: CommandType.StoredProcedure))
                    .ToList();

                // 3) Fetch Specifications
                var Ingre = (await connection
                    .QueryAsync<FaqIngredient>(Ingredient, parameters, commandType: CommandType.StoredProcedure))
                    .ToList();

                var FaqProduct = (await connection
                  .QueryAsync<FaqWithProduct>(FaqWithProduct, parameters, commandType: CommandType.StoredProcedure))
                  .ToList();

                var SimilarP = (await connection
               .QueryAsync<SimilarProduct>(AllSimilarProduct, parameters, commandType: CommandType.StoredProcedure))
               .ToList();

                // 4) Prepare the three separate sections
                var product = result
                    .Select(p => new
                    {
                        id = p.Id,
                        productId = p.ProductId.ToString(),
                        categoryId = p.CategoryId.ToString(),
                        categoryName = p.CategoryName,
                        subCategoryId = p.SubCategoryId.ToString(),
                        subCategoryName = p.SubCategoryName,
                        subCategoryTypeId = p.SubCategoryTypeId.ToString(),
                        subCategoryTypeName = p.SubCategoryTypeName,
                        sellerId = p.SellerId.ToString(),
                        sellerName = p.SellerName,
                        sizeId = p.SizeId.ToString(),
                        sizeName = p.SizeName,
                        sizeCode = p.SizeCode,
                        productName = p.ProductName,
                        subName = p.SubName,
                        description = p.Description,
                        rating = p.Rating,
                        noOfRating = p.NoOfRating,
                        stock = p.Stock,
                        price = p.Price,
                        discountPrice = p.DiscountPrice,
                        createdDate = p.CreatedDate.ToString("yyyy-MM-ddTHH:mm:ss"),
                        updatedDate = p.UpdatedDate != DateTime.MinValue
                                                    ? p.UpdatedDate.ToString("yyyy-MM-ddTHH:mm:ss")
                                                    : null,
                        status = p.Status,
                        active = p.Active,
                        concernName = p.concernName,
                        ingredientName = p.ingredientName,
                        ConcernId = p.ConcernId,
                        IngredientId = p.IngredientId,
                        imageUrls = result.Select(x => x.ImageUrl).ToList()
                    })
                    .FirstOrDefault();


                // 5) Fetch Specifications
                var skin = (await connection
                    .QueryAsync<AllSkinInsightProduct>(SkinInsight, parameters, commandType: CommandType.StoredProcedure))
                    .ToList();

                var response = new ResponseViewModel
                {
                    statusCode = product != null ? 200 : 404,
                    message = product != null ? "Data Found" : "Data Not Found",
                    data = product != null
                                 ? new
                                 {
                                     productDetail = product,  
                                     FAQ = faqList,                              
                                     FaqIngredient = Ingre,   
                                     FaqWithProduct = FaqProduct,   
                                     SimilarProduct = SimilarP,   
                                     skin = skin
                                 }
                                 : null
                };

                return response;
            }
        }



        public async Task<ResponseViewModel> getAllProduct()
        {
            var procedureName = Constant.spGetAllProduct;

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<AllProduct>(procedureName, null, commandType: CommandType.StoredProcedure);
                    var getAllProduct = new ResponseViewModel
                    {
                        statusCode = result.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
                        message = result.Any() ? "Data Found" : "Data Not Found",
                        data = result
                    };
                    return getAllProduct;
                }
            }
            catch (Exception ex)
            {
                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = $"Error occurred: {ex.Message}",
                    data = null
                };
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

        public async Task<ResponseViewModel> getIsRecommended()
        {
            var procedureName = Constant.spGetisRecommended;
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

        public async Task<ResponseViewModel> getIsNewArrial()
        {
            var procedureName = Constant.spGetIsNewArrial;
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
        public async Task<ResponseViewModel> getAllProductDetails(Int32 id)
        {
            var procedureName = Constant.spGetAllProductDetails;
            using (var connection = _dapperContext.createConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32);
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

        public async Task<ResponseViewModelProduct> addProduct(AddProductViewModel addProduct)
        {
            var response = new ResponseViewModelProduct();
            var procedureName = Constant.spAddProduct;
            var parameters = new DynamicParameters();


            try
            {

                // Guid Parameters
                parameters.Add("@categoryId", addProduct.categoryId == Guid.Empty ? (object)DBNull.Value : addProduct.categoryId, DbType.Guid);
                parameters.Add("@subCategoryId", addProduct.subCategoryId == Guid.Empty ? (object)DBNull.Value : addProduct.subCategoryId, DbType.Guid);
                parameters.Add("@subCategoryTypeId", addProduct.subCategoryTypeId == Guid.Empty ? (object)DBNull.Value : addProduct.subCategoryTypeId, DbType.Guid);
                parameters.Add("@sellerId", addProduct.sellerId == Guid.Empty ? (object)DBNull.Value : addProduct.sellerId, DbType.Guid);
                parameters.Add("@sizeId", addProduct.sizeId == Guid.Empty ? (object)DBNull.Value : addProduct.sizeId, DbType.Guid);
                parameters.Add("@createdBy", addProduct.createdBy == Guid.Empty ? (object)DBNull.Value : addProduct.createdBy, DbType.Guid);
                parameters.Add("@ConcernId", addProduct.ConcernId == Guid.Empty ? (object)DBNull.Value : addProduct.ConcernId, DbType.Guid);
                parameters.Add("@IngredientId", addProduct.IngredientId == Guid.Empty ? (object)DBNull.Value : addProduct.IngredientId, DbType.Guid);
                parameters.Add("@TypeofProductId", addProduct.TypeofProductId == Guid.Empty ? (object)DBNull.Value : addProduct.TypeofProductId, DbType.Guid);
                parameters.Add("@stepsId", addProduct.stepsId == Guid.Empty ? (object)DBNull.Value : addProduct.stepsId, DbType.Guid);

                //  Boolean and String parameters
                parameters.Add("@title", addProduct.title ?? string.Empty, DbType.String);
                parameters.Add("@subTitle", addProduct.subTitle ?? string.Empty, DbType.String);
                parameters.Add("@description", addProduct.description ?? string.Empty, DbType.String);
                parameters.Add("@rating", addProduct.rating, DbType.Int32);
                parameters.Add("@noOfRating", addProduct.noOfRating, DbType.Int32);
                parameters.Add("@stock", addProduct.stock, DbType.Int32);
                parameters.Add("@price", addProduct.price, DbType.Decimal);
                parameters.Add("@discountPrice", addProduct.discountPrice, DbType.Decimal);

                parameters.Add("@isNewArrial", addProduct.isNewArrial ? 1 : 0, DbType.Boolean);
                parameters.Add("@isBestSeller", addProduct.isBestSeller ? 1 : 0, DbType.Boolean);
                parameters.Add("@isRecommended", addProduct.isRecommended ? 1 : 0, DbType.Boolean);

                parameters.Add("@categoryName", addProduct.categoryName ?? string.Empty, DbType.String);
                parameters.Add("@subCategoryName", addProduct.subCategoryName ?? string.Empty, DbType.String);
                parameters.Add("@subCategoryTypeName", addProduct.subCategoryTypeName ?? string.Empty, DbType.String);
                parameters.Add("@stepsName", addProduct.stepsName ?? string.Empty, DbType.String);
                parameters.Add("@typeOfProductName", addProduct.typeOfProductName ?? string.Empty, DbType.String);
                parameters.Add("@sizename", addProduct.sizename ?? string.Empty, DbType.String);
                parameters.Add("@concernname", addProduct.concernname ?? string.Empty, DbType.String);
                parameters.Add("@ingredientName", addProduct.ingredientName ?? string.Empty, DbType.String);
                parameters.Add("@productname", addProduct.productname ?? string.Empty, DbType.String);

                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModelProduct>(
                        procedureName,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    if (result != null && result.statusCode == 1)
                    {
                        result.statusCode = (int)HttpStatusCode.OK;
                        result.message = result.message;
                        result.data = new OrderResponseData
                        {
                            productId = result.productId
                        };
                    }
                    else
                    {
                        result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                //  Error Catch Block
                response.statusCode = (int)HttpStatusCode.ExpectationFailed;
                response.message = ex.Message;
                response.data = null;

                return response;
            }
        }



        public class OrderResponseData
        {
            public Guid productId { get; set; }
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
            parameters.Add("@TypeofProductId", updateProduct.TypeofProductId, DbType.Guid);
            parameters.Add("@StepsId", updateProduct.StepsId, DbType.Guid);
            parameters.Add("@isNewArrial", updateProduct.isNewArrial ? 1 : 0, DbType.Boolean);
            parameters.Add("@isBestSeller", updateProduct.isNewArrial ? 1 : 0, DbType.Boolean);
            parameters.Add("@isRecommended", updateProduct.isNewArrial ? 1 : 0, DbType.Boolean);


            parameters.Add("@categoryName", updateProduct.categoryName ?? string.Empty, DbType.String);
            parameters.Add("@subCategoryName", updateProduct.subCategoryName ?? string.Empty, DbType.String);
            parameters.Add("@subCategoryTypeName", updateProduct.subCategoryTypeName ?? string.Empty, DbType.String);
            parameters.Add("@stepsName", updateProduct.stepsName ?? string.Empty, DbType.String);
            parameters.Add("@typeOfProductName", updateProduct.typeOfProductName ?? string.Empty, DbType.String);
            parameters.Add("@sizename", updateProduct.sizename ?? string.Empty, DbType.String);
            parameters.Add("@concernname", updateProduct.concernname ?? string.Empty, DbType.String);
            parameters.Add("@ingredientName", updateProduct.ingredientName ?? string.Empty, DbType.String);
            parameters.Add("@productname", updateProduct.productname ?? string.Empty, DbType.String);

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
                parameters.Add("@image", imagePath, DbType.String);
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

        public async Task<ResponseViewModel> getAllSteps()
        {
            var procedureName = Constant.spGetAllSteps;
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<AllSteps>(procedureName, null, commandType: CommandType.StoredProcedure);
                var spGetAllSteps = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return spGetAllSteps;
            }
        }


        public async Task<ResponseViewModel> getAllActiveSteps()
        {
            var procedureName = Constant.spGetActiveAllSteps;
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<AllSteps>(procedureName, null, commandType: CommandType.StoredProcedure);
                var spGetAllSteps = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return spGetAllSteps;
            }
        }
        public async Task<ResponseViewModel> addAllSteps(AddStepsViewModel addSteps)
        {
            var procedureName = Constant.spAddSteps;
            var parameters = new DynamicParameters();
            parameters.Add("@name", addSteps.name, DbType.String);
            parameters.Add("@description", addSteps.description, DbType.String);
            parameters.Add("@@createdBy", addSteps.createdBy, DbType.Guid);

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

        public async Task<ResponseViewModel> deleteAllSteps(DeleteStepsViewModel deleteSteps)
        {
            var procedureName = Constant.spDeleteSteps;
            var parameters = new DynamicParameters();
            parameters.Add("@stepsId", deleteSteps.stepsId, DbType.Guid);
            parameters.Add("@updatedBy", deleteSteps.updatedBy, DbType.Guid);

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

        public async Task<ResponseViewModel> updateAllSteps(UpdateStepsViewModel updateSteps)
        {
            var procedureName = Constant.spUpdateSteps;
            var parameters = new DynamicParameters();
            parameters.Add("@stepsId", updateSteps.stepsId, DbType.Guid);
            parameters.Add("@name", updateSteps.name, DbType.String);
            parameters.Add("@description", updateSteps.description, DbType.String);
            parameters.Add("@active", updateSteps.active, DbType.Boolean);
            parameters.Add("@updatedBy", updateSteps.updatedBy, DbType.Guid);


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
        public async Task<ResponseViewModel> getAllTypeofProduct()
        {
            var procedureName = Constant.spGetAllTypeofProduct;
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<AllTypeofProduct>(procedureName, null, commandType: CommandType.StoredProcedure);
                var spGetAllTypeofProduct = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return spGetAllTypeofProduct;
            }
        }


        public async Task<ResponseViewModel> getAllTypeofActiveProduct()
        {
            var procedureName = Constant.spGetAllActiveTypeofProduct;
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<AllTypeofProduct>(procedureName, null, commandType: CommandType.StoredProcedure);
                var spGetAllTypeofProduct = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return spGetAllTypeofProduct;
            }
        }
        public async Task<ResponseViewModel> addTypeOfProduct(AddTypeOfProductViewModel addTypeOfProduct)
        {
            var response = new ResponseViewModel();
            try
            {
                var procedureName = Constant.spAddTypeofProduct;
                var parameters = new DynamicParameters();
                parameters.Add("@name", addTypeOfProduct.name, DbType.String);
                parameters.Add("@description", addTypeOfProduct.description, DbType.String);
                parameters.Add("@createdBy", addTypeOfProduct.createdBy, DbType.Guid);

                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(
                        procedureName,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    if (result != null)
                    {
                        if (result.statusCode == 1)
                        {
                            result.statusCode = (int)HttpStatusCode.OK;
                        }
                        else
                        {
                            result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                        }
                        return result;
                    }
                    else
                    {
                        response.statusCode = (int)HttpStatusCode.NoContent;
                        response.message = "No response from stored procedure.";
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.statusCode = (int)HttpStatusCode.InternalServerError;
                response.message = "An error occurred: " + ex.Message;
                return response;
            }
        }

        public async Task<ResponseViewModel> deleteTypeOfProduct(DeleteSTypeOfProductMdoel deleteSTypeOfProduct)
        {
            var procedureName = Constant.spDeleteTypeofProduct;
            var parameters = new DynamicParameters();
            parameters.Add("@TypeofProductId", deleteSTypeOfProduct.TypeofProductId, DbType.Guid);
            parameters.Add("@updatedBy", deleteSTypeOfProduct.updatedBy, DbType.Guid);

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
        public async Task<ResponseViewModel> updateTypeOfProduct(UpdateTypeOfProductViewModel updateTypeOfProduct)
        {
            var response = new ResponseViewModel();

            try
            {
                var procedureName = Constant.spUpdateTypeofProduct;
                var parameters = new DynamicParameters();
                parameters.Add("@TypeofProductId", updateTypeOfProduct.TypeofProductId, DbType.Guid);
                parameters.Add("@name", updateTypeOfProduct.name, DbType.String);
                parameters.Add("@description", updateTypeOfProduct.description, DbType.String);
                parameters.Add("@active", updateTypeOfProduct.active, DbType.Boolean);
                parameters.Add("@updatedBy", updateTypeOfProduct.updateddBy, DbType.Guid);

                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryFirstOrDefaultAsync<SPResponseModel>(
                        procedureName,
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    if (result != null)
                    {
                        response.statusCode = (result.statusCode == 1)
                            ? (int)HttpStatusCode.OK
                            : (int)HttpStatusCode.ExpectationFailed;
                        response.message = result.message;
                    }
                    else
                    {
                        response.statusCode = (int)HttpStatusCode.NoContent;
                        response.message = "No response from stored procedure.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.statusCode = (int)HttpStatusCode.InternalServerError;
                response.message = "An error occurred: " + ex.Message;
            }

            return response;
        }


        private class SPResponseModel
        {
            public int statusCode { get; set; }
            public string message { get; set; }
        }

        public async Task<ResponseViewModel> searchProductNew(string commonTypeSearch)
        {
            var procedureName = Constant.spSearchByProduct;
            using (var connection = _dapperContext.createConnection())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@commonTypeSearch", commonTypeSearch);
                var result = await connection.QueryAsync<searchProductNew>(procedureName, param, null, commandType: CommandType.StoredProcedure);
                var getAllProduct = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllProduct;
            }
        }
     
    }
}

