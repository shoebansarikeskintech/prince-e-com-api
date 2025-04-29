using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Common;
using RepositoryContract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Model.ModelType;

namespace Repository
{
    public class RatingReviewRepository : IRatingReviewRepository
    {
        private readonly DapperContext _dapperContext;
        public RatingReviewRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;


        public async Task<ResponseViewModel> getAllRatingReview(Guid productId)
        {
            var procedureName = Constant.spGetRatingReview;
            var parameters = new DynamicParameters();
            parameters.Add("@productId", productId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<RatingRiview>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getAllOrder = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllOrder;
            }
        }
        public async Task<ResponseViewModel> getAllRatingReviewbyId(Guid productId)
        {
            var response = new ResponseViewModel();
            try
            {
                var procedureName = Constant.sp_GetRatingPercentage;
                var parameters = new DynamicParameters();
                parameters.Add("@productId", productId, DbType.Guid);

                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<RatingRiviewStar>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                    response.statusCode = result.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound;
                    response.message = result.Any() ? "Data Found" : "Data Not Found";
                    response.data = result;
                }
            }
            catch (Exception ex)
            {
                // Log exception here if needed (e.g., using Serilog, NLog, etc.)
                response.statusCode = (int)HttpStatusCode.InternalServerError;
                response.message = "Something went wrong: " + ex.Message;
                response.data = null;
            }

            return response;
        }
   
        public async Task<ResponseViewModel> addRatingReview(RatingReviewViewModel RatingReviewModelViewModel)
        {
            var procedureName = Constant.spAddRatingReview;
            var parameters = new DynamicParameters();
            parameters.Add("@productId", RatingReviewModelViewModel.productId, DbType.Guid);
            parameters.Add("@userId", RatingReviewModelViewModel.userId, DbType.Guid);
            parameters.Add("@rating", RatingReviewModelViewModel.rating, DbType.Int64);
            parameters.Add("@title", RatingReviewModelViewModel.title, DbType.String);
            parameters.Add("@description", RatingReviewModelViewModel.description, DbType.String);
            parameters.Add("@like", RatingReviewModelViewModel.like, DbType.Int64);
            parameters.Add("@dislike", RatingReviewModelViewModel.dislike, DbType.Int64);
            parameters.Add("@createdBy", RatingReviewModelViewModel.createdBy, DbType.Guid);

            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                if (result.statusCode == 1)
                {
                    result.statusCode = (int)HttpStatusCode.OK;
                    result.message = result.message;
                    result.data = result;
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

        public async Task<ResponseViewModel> updateRatinReview(UpdateReviewRatingViewModel updateRatingReview)
        {
            var procedureName = Constant.spUpdateRatingReview;
            var parameters = new DynamicParameters();
            parameters.Add("@ratingReviewId", updateRatingReview.ratingReviewId, DbType.Guid);
            parameters.Add("productId", updateRatingReview.productId, DbType.Guid);
            parameters.Add("@userId", updateRatingReview.userId, DbType.Guid);
            parameters.Add("@rating", updateRatingReview.rating, DbType.Int64);
            parameters.Add("@title", updateRatingReview.title, DbType.String);
            parameters.Add("@description", updateRatingReview.description, DbType.String);
            parameters.Add("@like", updateRatingReview.like, DbType.Int64);
            parameters.Add("@dislike", updateRatingReview.like, DbType.Int64);
            parameters.Add("@updatedBy", updateRatingReview.updatedBy, DbType.Guid);
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



        public async Task<ResponseViewModel> getAllFAQ()
        {
            var procedureName = Constant.spGetAllProductFAQ;
            var parameters = new DynamicParameters();
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Faq>(procedureName, commandType: CommandType.StoredProcedure);
                var getAllOrder = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllOrder;
            }
        }

        public async Task<ResponseViewModel> getAllFAQByProductId(Guid productId)
        {
            var procedureName = Constant.spGetProductFAQByProductId;
            var parameters = new DynamicParameters();
            parameters.Add("@productId", productId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<RatingRiviewByProductId>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getAllOrder = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllOrder;
            }
        }

        public async Task<ResponseViewModel> addFAQ(AddFAQViewModel addFAQ)
        {
            var procedureName = Constant.spAddProductFAQ;
            var parameters = new DynamicParameters();
            parameters.Add("@productId", addFAQ.productId, DbType.Guid);
            parameters.Add("@Title", addFAQ.Title, DbType.String);
            parameters.Add("@Description", addFAQ.Description, DbType.String);
            parameters.Add("@createdBy", addFAQ.createdBy, DbType.Guid);

            using (var connection = _dapperContext.createConnection())
            {
                try
                {
                    var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(
                        procedureName, parameters, commandType: CommandType.StoredProcedure);

                    if (result != null)
                    {
                        if (result.statusCode == 1)
                        {
                            result.statusCode = (int)HttpStatusCode.OK;
                            result.message = result.message;
                            // Optionally, set result.data if you want to return more details
                        }
                        else
                        {
                            result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                            result.message = result.message;
                        }

                        return result;
                    }
                    else
                    {
                        return new ResponseViewModel
                        {
                            statusCode = (int)HttpStatusCode.NoContent,
                            message = "No response received from database."
                        };
                    }
                }
                catch (Exception ex)
                {
                    return new ResponseViewModel
                    {
                        statusCode = (int)HttpStatusCode.InternalServerError,
                        message = "An error occurred while adding FAQ: " + ex.Message
                    };
                }
            }
        }


        public async Task<ResponseViewModel> updateFAQ(UpdateFAQViewModel updateFAQ)
        {
            var procedureName = Constant.spUpdateProductFAQ;
            var parameters = new DynamicParameters();
            parameters.Add("@ProductFaqid", updateFAQ.ProductFaqid, DbType.Guid);
            parameters.Add("productId", updateFAQ.productId, DbType.Guid);
            parameters.Add("@Title", updateFAQ.Title, DbType.String);
            parameters.Add("@Description", updateFAQ.Description, DbType.String);         
            parameters.Add("@active", updateFAQ.active, DbType.Boolean);         
            parameters.Add("@updatedBy", updateFAQ.updatedBy, DbType.Guid);
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


        public async Task<ResponseViewModel> deleteFAQ(DeleteFAQViewModel deleteFAQ)
        {
            var procedureName = Constant.spDeleteProductFAQ;
            var parameters = new DynamicParameters();
            parameters.Add("@ProductFaqid", deleteFAQ.ProductFaqid, DbType.Guid);
            parameters.Add("@updatedBy", deleteFAQ.updatedBy, DbType.Guid);
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

        public async Task<ResponseViewModel> getProductSpecification()
        {
            var procedureName = Constant.spGetAllProductSpecification;

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<ProductSpecification>(
                        procedureName,
                        commandType: CommandType.StoredProcedure
                    );

                    var getAllOrder = new ResponseViewModel
                    {
                        statusCode = result.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
                        message = result.Any() ? "Data Found" : "Data Not Found",
                        data = result
                    };

                    return getAllOrder;
                }
            }
            catch (Exception ex)
            {
                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = $"An error occurred: {ex.Message}",
                    data = null
                };
            }
        }


        public async Task<ResponseViewModel> addProductSpecification(AddProductSpecificationViewModel addProductSpecification)
        {
            var procedureName = Constant.spAddProductSpecification;
            var parameters = new DynamicParameters();
            parameters.Add("@productId", addProductSpecification.productId, DbType.Guid);
            parameters.Add("@producttype", addProductSpecification.producttype, DbType.String);
            parameters.Add("@netquantity", addProductSpecification.netquantity, DbType.String);
            parameters.Add("@shelfLife", addProductSpecification.shelfLife, DbType.String);
            parameters.Add("@countryOfOrigin", addProductSpecification.countryOfOrigin, DbType.String);
            parameters.Add("@SKUcode", addProductSpecification.SKUcode, DbType.String);
            parameters.Add("@ManufacturedBy", addProductSpecification.ManufacturedBy, DbType.Guid);
            parameters.Add("@ConsumerCareAddress", addProductSpecification.ConsumerCareAddress, DbType.String);
            parameters.Add("@createdBy", addProductSpecification.createdBy, DbType.Guid);

            using (var connection = _dapperContext.createConnection())
            {
                try
                {
                    var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(
                        procedureName, parameters, commandType: CommandType.StoredProcedure);

                    if (result != null)
                    {
                        if (result.statusCode == 1)
                        {
                            result.statusCode = (int)HttpStatusCode.OK;
                            result.message = result.message;
                            // Optionally, set result.data if you want to return more details
                        }
                        else
                        {
                            result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                            result.message = result.message;
                        }

                        return result;
                    }
                    else
                    {
                        return new ResponseViewModel
                        {
                            statusCode = (int)HttpStatusCode.NoContent,
                            message = "No response received from database."
                        };
                    }
                }
                catch (Exception ex)
                {
                    return new ResponseViewModel
                    {
                        statusCode = (int)HttpStatusCode.InternalServerError,
                        message = "An error occurred while adding FAQ: " + ex.Message
                    };
                }
            }
        }


        public async Task<ResponseViewModel> updateProductSpecification(UpdateProductSpecificationViewModel updateProductSpecification)
        {
            var procedureName = Constant.spUpdateProductSpecification;
            var parameters = new DynamicParameters();
            parameters.Add("@ProductSpecificationid", updateProductSpecification.ProductSpecificationid, DbType.Guid);
            parameters.Add("@productId", updateProductSpecification.productId, DbType.Guid);
            parameters.Add("@producttype", updateProductSpecification.producttype, DbType.String);
            parameters.Add("@netquantity", updateProductSpecification.netquantity, DbType.String);
            parameters.Add("@shelfLife", updateProductSpecification.shelfLife, DbType.String);
            parameters.Add("@countryOfOrigin", updateProductSpecification.countryOfOrigin, DbType.String);
            parameters.Add("@SKUcode", updateProductSpecification.SKUcode, DbType.String);
            parameters.Add("@ManufacturedBy", updateProductSpecification.ManufacturedBy, DbType.Guid);
            parameters.Add("@ConsumerCareAddress", updateProductSpecification.ConsumerCareAddress, DbType.String);
            parameters.Add("@active", updateProductSpecification.active, DbType.Boolean);
            parameters.Add("@updatedBy", updateProductSpecification.updatedBy, DbType.Guid);
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


        public async Task<ResponseViewModel> deleteProductSpecification(DeleteProductSpecificationViewModel deleteProductSpecification)
        {
            var procedureName = Constant.spDeleteProductSpecification;
            var parameters = new DynamicParameters();
            parameters.Add("@ProductSpecificationid", deleteProductSpecification.ProductSpecificationid, DbType.Guid);
            parameters.Add("@updatedBy", deleteProductSpecification.updatedBy, DbType.Guid);
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

    }
}
