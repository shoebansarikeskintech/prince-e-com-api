using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using static Model.ModelType;
using ViewModel;
using Common;
using static Repository.OrderRepository;

namespace Repository
{

    public class FilterRepository : IFilterRepository
    {
        private readonly DapperContext _dapperContext;
        public FilterRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;

        public async Task<ResponseViewModel> getAllSortBy()
        {
            var procedureName = Constant.spGetSortBy;

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<SortBy>(procedureName, null, commandType: CommandType.StoredProcedure);
                var getAllSortBy = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllSortBy;
            }
        }

        public async Task<ResponseViewModel> getAllFilter()
        {
            var procedureSortBy = Constant.spGetSortBy;
            var procedureBrand = Constant.spGetAllBrandForUser;
            var procedureColor = Constant.spGetAllColorForUser;
            var procedureSize = Constant.spGetAllSizeForUser;

            using (var connection = _dapperContext.createConnection())
            {
                var sortByResult = await connection.QueryAsync<SortBy>(procedureSortBy, null, commandType: CommandType.StoredProcedure);
                var brandResult = await connection.QueryAsync<Brand>(procedureBrand, null, commandType: CommandType.StoredProcedure);
                var colorResult = await connection.QueryAsync<Color>(procedureColor, null, commandType: CommandType.StoredProcedure);
                var sizeResult = await connection.QueryAsync<SizeRes>(procedureSize, null, commandType: CommandType.StoredProcedure);

                var response = new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.OK,
                    message = "Data Found",
                    data = new
                    {
                        SortBy = sortByResult,
                        Brand = brandResult,
                        Color = colorResult,
                        Size = sizeResult
                    }
                };

                if (sortByResult.Count() == 0 && brandResult.Count() == 0 && colorResult.Count() == 0 && sizeResult.Count() == 0)
                {
                    response.statusCode = (int)HttpStatusCode.NotFound;
                    response.message = "Data Not Found";
                }
                return response;
            }
        }


        public async Task<ResponseViewModel> getProductSearchByFilter(FilterViewModel model)
        {
            var procedureName = Constant.spGetProductSearchByFilter;
            var procedureImage = Constant.spGetProductSearchByFilterImages;

            using (var connection = _dapperContext.createConnection())
            {
                try
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@categoryId", model.categoryId);
                    param.Add("@subCategoryId", model.subCategoryId);
                    param.Add("@subcategoryTypeId", model.subcategoryTypeId);

                    // Step 1: Get all product records
                    var result = (await connection.QueryAsync<PrdoctSearchByFilter>(
                        procedureName, param, commandType: CommandType.StoredProcedure)).ToList();

                    // Step 2: For each product, get image list
                    foreach (var product in result)
                    {
                        DynamicParameters imgParam = new DynamicParameters();
                        imgParam.Add("@productid", product.GproductId);  // <-- Use correct product ID

                        var images = await connection.QueryAsync<string>(
                            procedureImage, imgParam, commandType: CommandType.StoredProcedure);

                        product.images = images.ToList();
                    }

                    return new ResponseViewModel
                    {
                        statusCode = result.Any() ? 200 : 404,
                        message = result.Any() ? "Data Found" : "Data Not Found",
                        data = result
                    };
                }
                catch (Exception ex)
                {
                    return new ResponseViewModel
                    {
                        statusCode = 500,
                        message = "Error: " + ex.Message,
                        data = null
                    };
                }
            }
        }



        


        public async Task<ResponseViewModel> getProductSearchByFilterNew(FilterViewModelNew model)
        {
            var procedureName = Constant.spGetProductSearchByFilterNew;
            var procedureImage = Constant.spGetProductSearchByFilterImages;
            var ProductMRP = Constant.spGetMRPByProductId;


            using (var connection = _dapperContext.createConnection())
            {
                try
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@categoryIds", model.categoryIds ?? "");
                    param.Add("@subCategoryIds", model.subCategoryIds ?? "");
                    param.Add("@subcategoryTypeIds", model.subcategoryTypeIds ?? "");
                    param.Add("@productIds", model.productIds ?? "");
                    param.Add("@sellerIds", model.sellerIds ?? "");
                    param.Add("@stepsIds", model.stepsIds ?? "");
                    param.Add("@typeofProductIds", model.typeofProductIds ?? "");
                    param.Add("@sizeIds", model.sizeIds ?? "");
                    param.Add("@concernIds", model.concernIds ?? "");
                    param.Add("@ingredientIds", model.ingredientIds ?? "");

                    var result = await connection.QueryAsync<PrdoctSearchByFilterNewModel>(
                        procedureName, param, commandType: CommandType.StoredProcedure);

                    var productDetails = new List<ProductImageModel>();

                    
                    foreach (var product in result)
                    {
                        // MRP fetch karna
                        DynamicParameters MRPParam = new DynamicParameters();
                        MRPParam.Add("@productid", product.GproductId);

                        var productMRP = await connection.QueryFirstOrDefaultAsync<string>(
                            ProductMRP, MRPParam, commandType: CommandType.StoredProcedure);

                        // Images fetch karna
                        DynamicParameters imgParam = new DynamicParameters();
                        imgParam.Add("@productid", product.GproductId);

                        var images = await connection.QueryAsync<string>(
                            procedureImage, imgParam, commandType: CommandType.StoredProcedure);

                        // 👇 Yahi par assign karo:
                        product.MRP = productMRP;
                        product.Images = images.ToList();
                    }



                    return new ResponseViewModel
                    {
                        statusCode = result.Any() ? 200 : 404,
                        message = result.Any() ? "Data Found" : "Data Not Found",
                        data = result
                    };
                }
                catch (Exception ex)
                {
                    return new ResponseViewModel
                    {
                        statusCode = 500,
                        message = "Error: " + ex.Message,
                        data = null
                    };
                }
            }
        }

      

        public async Task<ResponseViewModel> getAllSkinInsightProduct()
        {
            var procedureName = Constant.spGetAllSkinInsightProduct;

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<AllSkinInsightProduct>(
                        procedureName,
                        null,
                        commandType: CommandType.StoredProcedure
                    );

                    var getAllSortBy = new ResponseViewModel
                    {
                        statusCode = result.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
                        message = result.Any() ? "Data Found" : "Data Not Found",
                        data = result
                    };

                    return getAllSortBy;
                }
            }
            catch (Exception ex)
            {
                // (Optional) Log the error here if needed
                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = "An error occurred while fetching Skin Insight Products: " + ex.Message,
                    data = null
                };
            }
        }

        public async Task<ResponseViewModel> addSkinInsightProduct(AddSkinInsightProductViewModel addSkinInsightProduct)
        {
            var procedureName = Constant.spAddSkinInsightProduct;
            var parameters = new DynamicParameters();
            parameters.Add("@productId", addSkinInsightProduct.productId, DbType.Guid);
            parameters.Add("@Age", addSkinInsightProduct.Age, DbType.String);
            parameters.Add("@Gender", addSkinInsightProduct.Gender, DbType.String);
            parameters.Add("@Skintype", addSkinInsightProduct.Skintype, DbType.String);
            parameters.Add("@SkinSensitive", addSkinInsightProduct.SkinSensitive, DbType.String);
            parameters.Add("@createdBy", addSkinInsightProduct.createdBy, DbType.Guid);

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(
                    procedureName, parameters, commandType: CommandType.StoredProcedure
                );

                // Default error message in case stored proc returns null
                if (result == null)
                {
                    return new ResponseViewModel
                    {
                        statusCode = (int)HttpStatusCode.ExpectationFailed,
                        message = "Server error. No response from stored procedure.",
                        data = null
                    };
                }

                // Set response code and return inserted data
                result.statusCode = result.statusCode == 1 ? (int)HttpStatusCode.OK : (int)HttpStatusCode.ExpectationFailed;
                result.message = result.message ?? "Insert operation completed.";
                result.data = addSkinInsightProduct; // 👈 inserted data ko response me set karo

                return result;
            }
        }

        public async Task<ResponseViewModel> updateSkinInsightProduct(UpdateSkinInsightProductViewModel updateSkinInsightProduct)
        {
            var procedureName = Constant.spUpdateSkinInsightProduct;
            var parameters = new DynamicParameters();
            parameters.Add("@skininsightproductId", updateSkinInsightProduct.skininsightproductId, DbType.Guid);
            parameters.Add("@Age", updateSkinInsightProduct.Age, DbType.String);
            parameters.Add("@Gender", updateSkinInsightProduct.Gender, DbType.String);
            parameters.Add("@Skintype", updateSkinInsightProduct.Skintype, DbType.String);
            parameters.Add("@SkinSensitive", updateSkinInsightProduct.SkinSensitive, DbType.String);
            parameters.Add("@updatedBy", updateSkinInsightProduct.updatedBy, DbType.Guid);
            parameters.Add("@active", updateSkinInsightProduct.active ? 1 : 0, DbType.Boolean);

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
        public async Task<ResponseViewModel> deleteSkinInsightProduct(DeleteSkinInsightProductViewModel deleteSkinInsightProduct)
        {
            var response = new ResponseViewModel();

            try
            {
                var procedureName = Constant.spDeleteSkinInsightProduct;
                var parameters = new DynamicParameters();
                parameters.Add("@skininsightproductId", deleteSkinInsightProduct.skininsightproductId, DbType.Guid);
                parameters.Add("@updatedBy", deleteSkinInsightProduct.updatedBy, DbType.Guid);

                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(
                        procedureName, parameters, commandType: CommandType.StoredProcedure);

                    if (result != null)
                    {
                        response.statusCode = result.statusCode == 1 ? (int)HttpStatusCode.OK : (int)HttpStatusCode.ExpectationFailed;
                        response.message = result.message;
                    }
                    else
                    {
                        response.statusCode = (int)HttpStatusCode.ExpectationFailed;
                        response.message = "No response from procedure.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.statusCode = (int)HttpStatusCode.InternalServerError;
                response.message = $"Exception: {ex.Message}";
            }

            return response;
        }

        public async Task<ResponseViewModel> getAllSimilarProduct()
        {
            var procedureName = Constant.spGetAllSimilarProduct;

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = (await connection.QueryAsync<SimilarProductNew>(
                        procedureName,
                        null,
                        commandType: CommandType.StoredProcedure
                    )).ToList();

                    // Group by productId and collect subProductIds
                    var groupedResult = result
    .GroupBy(x => x.productId)
    .Select(g => new SimilarProductGrouped
    {
        productId = g.Key,
        subProductIds = g.Select(x => x.subProductId).Distinct().ToList(),
        createdDate = g.First().createdDate,
        SimilarProductId = g.First().SimilarProductId,
        createdBy = g.First().createdBy,
        Status = g.First().Status,
        active = g.First().active
    })
    .ToList();


                    var response = new ResponseViewModel
                    {
                        statusCode = groupedResult.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
                        message = groupedResult.Any() ? "Data Found" : "Data Not Found",
                        data = groupedResult
                    };

                    return response;
                }
            }
            catch (Exception ex)
            {
                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = "An error occurred while fetching Similar Products: " + ex.Message,
                    data = null
                };
            }
        }
        public class SimilarProductGrouped
        {
            public Guid productId { get; set; }
            public string? createdDate { get; set; }
            public Guid SimilarProductId { get; set; }
            public Guid createdBy { get; set; }
            public string? Status { get; set; }
            public bool active { get; set; }
            public List<Guid> subProductIds { get; set; }
        }



        public async Task<ResponseViewModel> getAllSimilarProductByProductId(Guid productId)
        {
            var procedureName = Constant.spGetAllSimilarProductByProductId;
            var procedureImage = Constant.spGetAllSimilarProductByProductIdImage;
            using (var connection = _dapperContext.createConnection())
            {
                try
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@productId", productId);
                    // Step 1: Get all product records
                    var result = (await connection.QueryAsync<SimilarProductDTO>(
                        procedureName, param, commandType: CommandType.StoredProcedure)).ToList();

                    // Step 2: For each product, get image list
                    foreach (var product in result)
                    {
                        DynamicParameters imgParam = new DynamicParameters();
                        imgParam.Add("@productid", product.subProductId);  // <-- Use correct product ID

                        var images = await connection.QueryAsync<string>(
                            procedureImage, imgParam, commandType: CommandType.StoredProcedure);

                        product.images = images.ToList();
                    }

                    return new ResponseViewModel
                    {
                        statusCode = result.Any() ? 200 : 404,
                        message = result.Any() ? "Data Found" : "Data Not Found",
                        data = result
                    };
                }
                catch (Exception ex)
                {
                    return new ResponseViewModel
                    {
                        statusCode = 500,
                        message = "Error: " + ex.Message,
                        data = null
                    };
                }
            }
        }


        //public async Task<ResponseViewModel> getAllSimilarProductByProductId(Guid productId)
        //{
        //    var procedureName = Constant.spGetAllSimilarProductByProductId;
        //    var procedureImage = Constant.spGetAllSimilarProductByProductIdImage;

        //    try
        //    {
        //        using (var connection = _dapperContext.createConnection())
        //        {
        //            DynamicParameters param = new DynamicParameters();
        //            param.Add("@productId", productId);

        //            // Step 1: Get single product record
        //            var productDto = (await connection.QueryFirstOrDefaultAsync<SimilarProductDTO>(procedureName, param, null, commandType: CommandType.StoredProcedure));
                     
        //            // Step 2: Get list of images for that product
        //            var imageList = (await connection.QueryAsync<SimilarProductImage>(procedureImage, param, null, commandType: CommandType.StoredProcedure)).ToList();

        //            // Step 3: Map data
        //            if (productDto != null)
        //            {
        //                var product = new SimilarProduct
        //                {
        //                    id = productDto.id,
        //                    SimilarProductId = productDto.SimilarProductId,
        //                    productId = productDto.productId,
        //                    subProductId = productDto.subProductId,
        //                    createdDate = productDto.createdDate,
        //                    createdBy = productDto.createdBy,
        //                    Status = productDto.Status,
        //                    active = productDto.active,
        //                    productName = productDto.productName,
        //                    description = productDto.description,
        //                    discountPrice = productDto.discountPrice,
        //                    price = productDto.price,
        //                    rating = productDto.rating,
        //                    image = imageList
        //                        .Where(x => !string.IsNullOrEmpty(x.image))
        //                        .Select(x => x.image!)
        //                        .ToList()
        //                };

        //                return new ResponseViewModel
        //                {
        //                    statusCode = (int)HttpStatusCode.OK,
        //                    message = "Data Found",
        //                    data = new List<SimilarProduct> { product }
        //                };
        //            }

        //            return new ResponseViewModel
        //            {
        //                statusCode = (int)HttpStatusCode.NotFound,
        //                message = "Data Not Found",
        //                data = null
        //            };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResponseViewModel
        //        {
        //            statusCode = (int)HttpStatusCode.InternalServerError,
        //            message = "An error occurred while fetching Similar Products: " + ex.Message,
        //            data = null
        //        };
        //    }
        //}



        public async Task<ResponseViewModel> addSimilarProduct(AddSimilarProductViewModel addSimilarProduct)
        {
            var procedureName = Constant.spAddSimilarProduct;
            var response = new ResponseViewModel();

            using (var connection = _dapperContext.createConnection())
            {
                foreach (var subProductId in addSimilarProduct.SubProductIds)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@productId", addSimilarProduct.ProductId, DbType.Guid);
                    parameters.Add("@subProductId", subProductId, DbType.Guid);
                    parameters.Add("@createdBy", addSimilarProduct.CreatedBy, DbType.Guid);

                    var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                    if (result.statusCode != 1)
                    {
                        response.statusCode = (int)HttpStatusCode.ExpectationFailed;
                        response.message = $"Failed to insert sub-product ID: {subProductId}";
                        return response;
                    }
                }

                response.statusCode = (int)HttpStatusCode.OK;
                response.message = "All sub-products added successfully.";
                return response;
            }
        }


        //public async Task<ResponseViewModel> updateSimilarProduct(UpdateSimilarProductViewModel updateSimilarProduct)
        //{
        //    var procedureName = Constant.spUpdateSimilarProduct;
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@productId", updateSimilarProduct.productId, DbType.Guid);
        //    parameters.Add("@subProductId", updateSimilarProduct.subProductId, DbType.Guid);
        //    parameters.Add("@active", updateSimilarProduct.active ? 1 : 0, DbType.Boolean);

        //    using (var connection = _dapperContext.createConnection())
        //    {
        //        var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        //        if (result.statusCode == 1)
        //        {
        //            result.statusCode = (int)HttpStatusCode.OK;
        //            result.message = result.message;
        //        }
        //        else if (result.statusCode == 0)
        //        {
        //            result.statusCode = (int)HttpStatusCode.ExpectationFailed;
        //            result.message = result.message;
        //        }
        //        else
        //        {
        //            result.statusCode = (int)HttpStatusCode.ExpectationFailed;
        //            result.message = result.message;
        //        }
        //        return result;
        //    }
        //}
        //public async Task<ResponseViewModel> updateSimilarProduct(UpdateSimilarProductViewModel updateSimilarProduct)
        //{
        //    var procedureName = Constant.spAddSimilarProduct;
        //    var procedureNameDelete = Constant.spDeleteSPByProducId;
        //    ResponseViewModel finalResult = new ResponseViewModel();

        //    using (var connection = _dapperContext.createConnection())
        //    {
        //        // Step 1: First delete old entries once
        //        var deleteParams = new DynamicParameters();
        //        deleteParams.Add("@productId", updateSimilarProduct.productId, DbType.Guid);

        //        await connection.ExecuteAsync(procedureNameDelete, deleteParams, commandType: CommandType.StoredProcedure);

        //        // Step 2: Insert each subProductId one by one
        //        foreach (var subId in updateSimilarProduct.subProductId)
        //        {
        //            var insertParams = new DynamicParameters();
        //            insertParams.Add("@productId", updateSimilarProduct.productId, DbType.Guid);
        //            insertParams.Add("@subProductId", subId, DbType.Guid);
        //            insertParams.Add("@active", updateSimilarProduct.active ? 1 : 0, DbType.Boolean);

        //            var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(
        //                procedureName, insertParams, commandType: CommandType.StoredProcedure);

        //            if (result.statusCode != 1)
        //            {
        //                // If any insert fails, return the failure response
        //                result.statusCode = (int)HttpStatusCode.ExpectationFailed;
        //                return result;
        //            }

        //            finalResult = result; // Update last success
        //        }

        //        finalResult.statusCode = (int)HttpStatusCode.OK;
        //        return finalResult;
        //    }
        //}

        public async Task<ResponseViewModel> updateSimilarProduct(UpdateSimilarProductViewModel updateSimilarProduct)
        {
            var procedureName = Constant.spAddSimilarProduct;
            var procedureNameDelete = Constant.spDeleteSPByProducId;
            ResponseViewModel finalResult = new ResponseViewModel();

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    // Step 1: First delete old entries once
                    var deleteParams = new DynamicParameters();
                    deleteParams.Add("@productId", updateSimilarProduct.productId, DbType.Guid);

                    await connection.ExecuteAsync(procedureNameDelete, deleteParams, commandType: CommandType.StoredProcedure);

                    // Step 2: Insert each subProductId one by one
                    foreach (var subId in updateSimilarProduct.subProductId)
                    {
                        var insertParams = new DynamicParameters();
                        insertParams.Add("@productId", updateSimilarProduct.productId, DbType.Guid);
                        insertParams.Add("@subProductId", subId, DbType.Guid);
                        insertParams.Add("@createdBy", updateSimilarProduct.createdBy, DbType.Guid);

                        var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(
                            procedureName, insertParams, commandType: CommandType.StoredProcedure);

                        if (result.statusCode != 1)
                        {
                            // If any insert fails, return the failure response
                            result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                            return result;
                        }

                        finalResult = result; // Update last success
                    }

                    finalResult.statusCode = (int)HttpStatusCode.OK;
                    return finalResult;
                }
            }
            catch (Exception ex)
            {
                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = $"Something went wrong: {ex.Message}"
                };
            }
        }


        public async Task<ResponseViewModel> deleteSimilarProduct(DeleteSimilarProductViewModel deleteSimilarProduct)
        {
            var response = new ResponseViewModel();

            try
            {
                var procedureName = Constant.spDeleteSimilarProduct;
                var parameters = new DynamicParameters();
                parameters.Add("@SimilarProductId", deleteSimilarProduct.SimilarProductId, DbType.Guid);
                parameters.Add("@updatedBy", deleteSimilarProduct.updatedBy, DbType.Guid);

                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(
                        procedureName, parameters, commandType: CommandType.StoredProcedure);

                    if (result != null)
                    {
                        response.statusCode = result.statusCode == 1 ? (int)HttpStatusCode.OK : (int)HttpStatusCode.ExpectationFailed;
                        response.message = result.message;
                    }
                    else
                    {
                        response.statusCode = (int)HttpStatusCode.ExpectationFailed;
                        response.message = "No response from procedure.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.statusCode = (int)HttpStatusCode.InternalServerError;
                response.message = $"Exception: {ex.Message}";
            }

            return response;
        }

        public async Task<ResponseViewModel> SearchAllSkinInsightProduct(SearchSkinInsightProductViewModelNew searchSkinInsightProduct)
        {
            var procedureName = Constant.spSearchAllSkinInsightProduct;

            using (var connection = _dapperContext.createConnection())
            {
                try
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@age", searchSkinInsightProduct.age ?? "");
                    param.Add("@gender", searchSkinInsightProduct.gender ?? "");
                    param.Add("@skintype", searchSkinInsightProduct.skintype ?? "");
                    param.Add("@skinSensitive", searchSkinInsightProduct.skinSensitive ?? "");


                    var result = await connection.QueryAsync<SkinInsightProduct>(
                        procedureName, param, commandType: CommandType.StoredProcedure);

                    return new ResponseViewModel
                    {
                        statusCode = result.Any() ? 200 : 404,
                        message = result.Any() ? "Data Found" : "Data Not Found",
                        data = result
                    };
                }
                catch (Exception ex)
                {
                    return new ResponseViewModel
                    {
                        statusCode = 500,
                        message = "Error: " + ex.Message,
                        data = null
                    };
                }
            }
        }

        public async Task<ResponseViewModel> getAllSkinInsightProductProductId(Guid productId)
        {
            var procedureName = Constant.spGetAllSkinInsightProductProductId;

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@productId", productId);
                    var result = await connection.QueryAsync<SkinInsightProductModel>(procedureName, param, null, commandType: CommandType.StoredProcedure);

                    var getAllSortBy = new ResponseViewModel
                    {
                        statusCode = result.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
                        message = result.Any() ? "Data Found" : "Data Not Found",
                        data = result
                    };

                    return getAllSortBy;
                }
            }
            catch (Exception ex)
            {
                // (Optional) Log the error here if needed
                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = "An error occurred while fetching Skin Insight Products: " + ex.Message,
                    data = null
                };
            }
        }
    }
}
