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

        public async Task<ResponseViewModel> addRatingReview(RatingReviewViewModel RatingReviewModelViewModel)
        {
            var procedureName = Constant.spAddRatingReview;

            //addAppRole.createdBy = Guid.NewGuid();
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

    }
}
