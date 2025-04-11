using Common;
using Dapper;
using RepositoryContract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using static Model.ModelType;

namespace Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly DapperContext _dapperContext;
        public CartRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;
       
        public async Task<ResponseViewModel> getCartItemCount(Guid userId)
        {
            var procedureName = Constant.spGetCartItemCount;
            var parameters = new DynamicParameters();
            parameters.Add("@userId", userId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<CartItemCount>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getbyIdColor = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getbyIdColor;
            }
        }
        public async Task<ResponseViewModel> getCartList(Guid userId)
        {
            var procedureName = Constant.spGetCartList;
            var parameters = new DynamicParameters();
            parameters.Add("@userId", userId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Cart>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getCartList = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getCartList;
            }
        }
        public async Task<ResponseViewModel> addProductInCart(AddProductInCartViewModel addProductInCart)
        {
            var procedureName = Constant.spAddProductInCart;
            var parameters = new DynamicParameters();
            parameters.Add("@userId", addProductInCart.userId, DbType.Guid);
            parameters.Add("@productId", addProductInCart.productId, DbType.Guid);
            parameters.Add("@quantity", addProductInCart.quantity, DbType.Int32);
            parameters.Add("@createdBy", addProductInCart.createdBy, DbType.Guid);
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
        public async Task<ResponseViewModel> updateQuantityInCart(UpdateQuantityInCartViewModel updateQuantityInCart)
        {
            var procedureName = Constant.spUpdateQuantityInCart;
            var parameters = new DynamicParameters();
            parameters.Add("@userId", updateQuantityInCart.userId, DbType.Guid);
            parameters.Add("@productId", updateQuantityInCart.productId, DbType.Guid);
            parameters.Add("@quantity", updateQuantityInCart.quantity, DbType.Int32);
            parameters.Add("@updatedBy", updateQuantityInCart.updatedBy, DbType.Guid);
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
        public async Task<ResponseViewModel> productRemoveInCart(RemoveProductInCartViewModel removeProductInCart)
        {
            var procedureName = Constant.spRemoveProductInCart;
            var parameters = new DynamicParameters();
            parameters.Add("@userId", removeProductInCart.userId, DbType.Guid);
            parameters.Add("@productId", removeProductInCart.productId, DbType.Guid);
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

