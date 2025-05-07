using Common;
using Dapper;
using RepositoryContract;
using System.Data;
using System.Net;
using ViewModel;
using static Model.ModelType;

namespace Repository
{
   public class OrderRepository : IOrderRepository
    {
        private readonly DapperContext _dapperContext;
        public OrderRepository(DapperContext dapperContext) =>
            _dapperContext = dapperContext;

        public async Task<ResponseViewModel> getAllOrder(Guid userId)
        {
            var procedureName = Constant.spGetAllOrder;
            var parameters = new DynamicParameters();
            parameters.Add("@userId", userId, DbType.Guid);

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<OrderByUserIds>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                    return new ResponseViewModel
                    {
                        statusCode = result.Any() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.NotFound,
                        message = result.Any() ? "Data Found" : "Data Not Found",
                        data = result
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = "An error occurred while fetching the data.",
                    data = null,                  
                };
            }
        }
        public async Task<ResponseViewModel> getAllOrderlist()
        {
            var procedureName = Constant.spGetAllOrderlist;
            var parameters = new DynamicParameters();

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<AllOrder>(procedureName, commandType: CommandType.StoredProcedure);

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
                    message = $"Error occurred: {ex.Message}",
                    data = null
                };
            }
        }


        public async Task<ResponseViewModel> getAllReturnOrderlist()
        {
            var procedureName = Constant.spGetAllReturnOrder;
            var parameters = new DynamicParameters();

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<AllOrder>(procedureName, commandType: CommandType.StoredProcedure);

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
                // Log the error if needed
                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = $"Error occurred: {ex.Message}",
                    data = null
                };
            }
        }

        public async Task<ResponseViewModel> getAllShippingOrderlist()
        {
            var procedureName = Constant.spGetAllShipping;
            var parameters = new DynamicParameters();

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<AllOrder>(procedureName, commandType: CommandType.StoredProcedure);

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
                // Log the error if needed
                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = $"Error occurred: {ex.Message}",
                    data = null
                };
            }
        }
        public async Task<ResponseViewModel> getAllPendingOrder()
        {
            var procedureName = Constant.spGetAllPendingOrder;
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Order>(procedureName, commandType: CommandType.StoredProcedure);
                var getAllPendngOrder = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllPendngOrder;
            }
        }
        public async Task<ResponseViewModel> getAllProcessingOrder(Guid adminUserId)
        {
            var procedureName = Constant.spGetAllProcessingOrder;
            var parameters = new DynamicParameters();
            parameters.Add("@adminUserId", adminUserId, DbType.Guid);
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Order>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var getAllPendngOrder = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllPendngOrder;
            }
        }
        public async Task<ResponseViewModel> getAllCompletedOrder()
        {
            var procedureName = Constant.spGetAllCompletedOrder;           
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<Order>(procedureName, commandType: CommandType.StoredProcedure);
                var getAllPendngOrder = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllPendngOrder;
            }
        }
        public async Task<ResponseViewModel> getAllCancelOrder()
        {
            var procedureName = Constant.spGetAllCancelOrder;          
            using (var connection = _dapperContext.createConnection())
            {
                var result = await connection.QueryAsync<CancelOrder>(procedureName, commandType: CommandType.StoredProcedure);
                var getAllPendngOrder = new ResponseViewModel
                {
                    statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
                    message = result.Count() == 0 ? "Data Not Found" : "Data Found",
                    data = result
                };
                return getAllPendngOrder;
            }
        }

        public async Task<ResponseViewModel> addOrderWithDetails(AddOrderWithDetailsViewModel addOrderDetails)
        {
            var procedureName = Constant.spAddOrderWithDetails;
            var parameters = new DynamicParameters();

            // Adding parameters
            parameters.Add("@userId", addOrderDetails.userId, DbType.Guid);
            parameters.Add("@addressId", addOrderDetails.addressId, DbType.Guid);
            parameters.Add("@paymentId", addOrderDetails.paymentId, DbType.Guid);
            parameters.Add("@price", addOrderDetails.price, DbType.Decimal);
            parameters.Add("@discountPrice", addOrderDetails.discountPrice, DbType.Decimal);
            parameters.Add("@deliveryCharge", addOrderDetails.deliveryCharge, DbType.Decimal);
            parameters.Add("@gstCharge", addOrderDetails.gstCharge, DbType.Decimal);
            parameters.Add("@extraCharge", addOrderDetails.extraCharge, DbType.Decimal);
            parameters.Add("@totalAmount", addOrderDetails.totalAmount, DbType.Decimal);
            parameters.Add("@paymentMethod", addOrderDetails.paymentMethod, DbType.String);
            parameters.Add("@transactionId", addOrderDetails.transactionId, DbType.String);
            parameters.Add("@trackingNo", addOrderDetails.trackingNo, DbType.String);
            parameters.Add("@note", addOrderDetails.note, DbType.String);
            parameters.Add("@createdBy", addOrderDetails.createdBy, DbType.Guid);
            
            string orderNo = "ORD" + Guid.NewGuid().ToString("N").Substring(0, 8); // Example: ORD9fcac100
            //addOrderDetails.orderNo = orderNo;
            //parameters.Add("@orderNo", addOrderDetails.orderNo, DbType.String);
            parameters.Add("@orderNo", orderNo, DbType.String);
            parameters.Add("@couponId", addOrderDetails.couponId, DbType.Guid);

            parameters.Add("@OrderDetailsXML", addOrderDetails.OrderDetailsXML, DbType.String); // Assuming it's a string, not Guid
            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(
                        procedureName, parameters, commandType: CommandType.StoredProcedure);

                    if (result != null)
                    {
                        if (result.statusCode == 1)
                        {
                            result.statusCode = (int)HttpStatusCode.OK;
                            result.message = "Order placed successfully.";
                            result.data = new OrderResponseData
                            {
                                //orderNo = addOrderDetails.orderNo
                                orderNo = orderNo
                            };
                        }
                        else if (result.statusCode == -1)
                        {
                            result.statusCode = (int)HttpStatusCode.BadRequest;
                            result.message = "This product is not available in sufficient stock.";
                        }
                        else if (result.statusCode == 0)
                        {
                            result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                            result.message = "Failed to place the order.";
                        }
                        else
                        {
                            result.statusCode = (int)HttpStatusCode.ExpectationFailed;
                            result.message = "An unexpected error occurred while placing the order.";
                        }

                        return result;
                    }
                    else
                    {
                        throw new Exception("No response from the server while placing the order.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.Error.WriteLine($"Error in addOrderWithDetails: {ex.Message}");

                // Return a failed response with the exception message
                return new ResponseViewModel
                {
                    statusCode = (int)HttpStatusCode.InternalServerError,
                    message = "No response from the server while placing the order."
                };
            }            
        }

        public class OrderResponseData
        {
            public string? orderNo { get; set; }
        }

      
        public async Task<ResponseViewModel> updateOrderStatus(UpdateStausViewModel updateStausViewModel)
        {
            var procedureName = Constant.spUpdateOrderStatus;
            var response = new ResponseViewModel();
            var updatedOrders = new List<Guid>();

            using (var connection = _dapperContext.createConnection())
            {
                foreach (var orderId in updateStausViewModel.orderIds)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@orderId", orderId, DbType.Guid);
                    parameters.Add("@status", updateStausViewModel.status, DbType.String);

                    var result = await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

                    if (result <= 0)
                    {
                        response.statusCode = (int)HttpStatusCode.ExpectationFailed;
                        response.message = $"Failed to update order ID: {orderId}";
                        return response;
                    }

                    updatedOrders.Add(orderId);
                }

                response.statusCode = (int)HttpStatusCode.OK;
                response.message = "All orders updated successfully.";
                response.data = updatedOrders;
                return response;
            }
        }

        public async Task<ResponseViewModel> getOrderWithItems(string orderIdOrOrderNo)
        {
            var procedureName = Constant.getOrderWithItems;
            var parameters = new DynamicParameters();
            parameters.Add("@orderIdOrOrderNo", orderIdOrOrderNo, DbType.String);

            var response = new ResponseViewModel();

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    using (var multi = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure))
                    {
                        var order = await multi.ReadFirstOrDefaultAsync<OrderViewModel>();
                        if (order != null)
                        {
                            order.items = (await multi.ReadAsync<OrderItemModel>()).ToList();

                            response.statusCode = 200;
                            response.message = "Order fetched successfully.";
                            response.data = order;
                        }
                        else
                        {
                            response.statusCode = 404;
                            response.message = "Order not found.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.statusCode = 500;
                response.message = $"Server error: {ex.Message}";
            }

            return response;
        }
          
        public async Task<ResponseViewModel> getOrdersBySearch(string searchValue)
        {
            var procedureName = Constant.spGetAllOrderDetailSearch;
            var parameters = new DynamicParameters();
            parameters.Add("@searchValue", searchValue, DbType.String);
            var response = new ResponseViewModel();

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<AllSearchOrder>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                    response.statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK;
                    response.message = result.Count() == 0 ? "Data Not Found" : "Data Found";
                    response.data = result;
                }
            }
            catch (Exception ex)
            {
                response.statusCode = (int)HttpStatusCode.InternalServerError;
                response.message = "An error occurred while fetching the order details.";
            }

            return response;
        }

        public async Task<ResponseViewModel> getAllReturnOrderCompleted()
        {
            var procedureName = Constant.spReturnOrderCompleted;
            var parameters = new DynamicParameters();

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<AllOrder>(procedureName, commandType: CommandType.StoredProcedure);

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
                    message = $"Error occurred: {ex.Message}",
                    data = null
                };
            }
        }
        public async Task<ResponseViewModel> getAllReturnOrderAccepted()
        {
            var procedureName = Constant.spReturnOrderAccepted;
            var parameters = new DynamicParameters();

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<AllOrder>(procedureName, commandType: CommandType.StoredProcedure);

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
                    message = $"Error occurred: {ex.Message}",
                    data = null
                };
            }
        }
    }
}
