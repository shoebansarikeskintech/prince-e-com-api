using Common;
using Dapper;
using Microsoft.AspNetCore.SignalR.Protocol;
using Newtonsoft.Json;
using RepositoryContract;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Xml;
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
            var procedureImage = Constant.spGetProductSearchByFilterImages;
            var procedureNames = Constant.spgetProductNamebyProductId;
            var GetAdressbyAddressId = Constant.spGetAdressbyAddressId;
            var ProductMRP = Constant.spGetMRPByProductId;
            var pincodeActive = Constant.spgetAllPinCodeActive;
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

            string orderNo = "ORD" + Guid.NewGuid().ToString("N").Substring(0, 8);
            parameters.Add("@orderNo", orderNo, DbType.String);
            parameters.Add("@couponId", addOrderDetails.couponId, DbType.Guid);
            parameters.Add("@OrderDetailsXML", addOrderDetails.OrderDetailsXML, DbType.String); 

            try
            {
                //using(var connection = _dapperContext.createConnection())
                //{
                //    var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(
                //     procedureName, parameters, commandType: CommandType.StoredProcedure);
                //}

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

                            // Step: Parse XML to get Order Detail Info
                            var xmlDoc = new XmlDocument();
                            xmlDoc.LoadXml(addOrderDetails.OrderDetailsXML);
                            var detailNodes = xmlDoc.SelectNodes("//Detail");

                            List<ProductImageModel> productDetails = new List<ProductImageModel>();

                            foreach (XmlNode detailNode in detailNodes)
                            {
                                var productIdText = detailNode["productId"]?.InnerText;
                                var quantityText = detailNode["quantity"]?.InnerText;
                                var priceText = detailNode["price"]?.InnerText;
                                var discountPriceText = detailNode["discountPrice"]?.InnerText;
                                var mrpText = detailNode["MRP"]?.InnerText;

                                if (Guid.TryParse(productIdText, out Guid productId))
                                {
                                    int.TryParse(quantityText, out int quantity);
                                    decimal.TryParse(priceText, out decimal price);
                                    decimal.TryParse(discountPriceText, out decimal discountPrice);
                                    decimal.TryParse(mrpText, out decimal mrp);

                                    // Get product images
                                    DynamicParameters imgParam = new DynamicParameters();
                                    imgParam.Add("@productid", productId);

                                    var images = await connection.QueryAsync<string>(
                                        procedureImage, imgParam, commandType: CommandType.StoredProcedure);

                                    // Get product name
                                    DynamicParameters nameParam = new DynamicParameters();
                                    nameParam.Add("@productid", productId);

                                    var productName = await connection.QueryFirstOrDefaultAsync<string>(
                                        procedureNames, nameParam, commandType: CommandType.StoredProcedure);

                                    productDetails.Add(new ProductImageModel
                                    {
                                        ProductId = productId,
                                        ProductName = productName,
                                        Quantity = quantity,
                                        Price = price,
                                        DiscountPrice = discountPrice,
                                        MRP = mrp.ToString("F2"),
                                        Images = images.ToList()
                                    });
                                }
                            }


                            // Get address, phoneNumber, Pincode
                            DynamicParameters addressIdParam = new DynamicParameters();
                            addressIdParam.Add("@addressId", addOrderDetails.addressId);

                            var addressData = await connection.QueryFirstOrDefaultAsync<DeliveryAddressModel>(
                                GetAdressbyAddressId, addressIdParam, commandType: CommandType.StoredProcedure);

                            DynamicParameters pincode = new DynamicParameters();
                            pincode.Add("@pinCode", addressData.pincode);


                            var pincodeDetail = await connection.QueryFirstOrDefaultAsync<PincodeDetail>(
                                                 pincodeActive, pincode, commandType: CommandType.StoredProcedure);

                            var expectedDate = DateTime.UtcNow
                                .AddDays(pincodeDetail?.noOfDays ?? 3)
                                .ToString("yyyy-MM-dd");

                            
                            result.data = new OrderResponseData
                            {
                                orderNo = orderNo,
                                price = addOrderDetails.price,
                                discountPrice = addOrderDetails.discountPrice,
                                totalAmount = addOrderDetails.totalAmount,
                                status = "Order Successful",
                                productDetails = productDetails,
                                deliveryAddress= addressData.fullAddress,
                                phone = addressData.mobile,
                                userName = addressData.userName,
                                email = addressData.email,
                               expectedDelivery=expectedDate
                                
                            };
                            //To send Email after Order Placed Uncomment this line.
                            await SendOrderConfirmationEmail((OrderResponseData)result.data);
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
                Console.Error.WriteLine($"Error in addOrderWithDetails: {ex.Message}");

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
            public decimal price { get; set; }
            public decimal discountPrice { get; set; }
            public decimal totalAmount { get; set; }
            public string? status { get; set; }
            public string? phone { get; set; }
            public string? userName { get; set; }
            public List<ProductImageModel> productDetails { get; set; }
            public string? deliveryAddress { get; set; }
            public string? email { get; set; }
            public string? expectedDelivery { get; set; }
        }
        public class ProductImageModel
        {
            public Guid ProductId { get; set; }
            public string? ProductName { get; set; }
            public string? MRP { get; set; }
            public int? Quantity { get; set; }
            public decimal? Price { get; set; }
            public decimal? DiscountPrice { get; set; }
            public List<string> Images { get; set; }
        }

        public class DeliveryAddressModel
        {
            public string userName { get; set; }
            public string mobile { get; set; }
            public string pincode { get; set; }
            public string fullAddress { get; set; }
            public string email { get; set; }
        }
        public class PincodeDetail
        {
            public string pinCode { get; set; }
            public int noOfDays { get; set; }
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
                    parameters.Add("@shippedFrom", updateStausViewModel.shippedFrom, DbType.String);
                    parameters.Add("@arrivedTo", updateStausViewModel.arrivedTo, DbType.String);

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
                    var rawResult = await connection.QueryAsync<AllSearchOrder>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                    var result = rawResult.ToList();
                    foreach (var order in result)
                    {
                        if (!string.IsNullOrEmpty(order.productsJson))
                        {
                            try
                            {
                                order.products = JsonConvert.DeserializeObject<List<OrderProduct>>(order.productsJson);
                            }
                            catch
                            {
                                order.products = new List<OrderProduct>(); // Fallback if invalid JSON
                            }
                        }
                    }

                    response.statusCode = result.Count == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK;
                    response.message = result.Count == 0 ? "Data Not Found" : "Data Found";
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
        public async Task<ResponseViewModel> getAllCancelOrderAccepted()
        {
            var procedureName = Constant.spGetAllcancelAccepted;
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
        public async Task<ResponseViewModel> getAllCancelOrderAcceptedCompleted()
        {
            var procedureName = Constant.spGetAllcancelAcceptedCompleted;
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
        public async Task<ResponseViewModel> getAllArrivedToOrderlist()
        {
            var procedureName = Constant.spGetOrderArrivedTo;
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
        public async Task<ResponseViewModel> getTrackOrder(string OrderNo)
        {
            var procedureName = Constant.spGetTrackOrder;
            var parameters = new DynamicParameters();
            parameters.Add("@orderNo", OrderNo, DbType.String);
            var response = new ResponseViewModel();

            try
            {
                using (var connection = _dapperContext.createConnection())
                {
                    var result = await connection.QueryAsync<TrackOrder>(procedureName, parameters, commandType: CommandType.StoredProcedure);

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
        public async Task SendOrderConfirmationEmail(OrderResponseData data)
        {
            var fromAddress = new MailAddress("shoebansari2013@gmail.com", "Zaddy");
            var toAddress = new MailAddress(data.email, data.userName);
            const string fromPassword = "nzvr memm dyak xxmb"; // Use secure storage
            string subject = $"Order Confirmation - {data.orderNo}";

            // Logo image path
            string logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logo", "Zaddy_Logo.png");

            // HTML body with inline logo and product details
            var bodyBuilder = new StringBuilder();
            bodyBuilder.Append($@"
        <html>
        <body>
            <img src='cid:zaddyLogo' alt='Zaddy Logo' style='height:60px;' />
            <p>Hi {data.userName},</p>
            <p>Your order <b>{data.orderNo}</b> has been placed successfully on {DateTime.UtcNow:yyyy-MM-dd}.</p>
            <h3>Order Details:</h3>
            <table border='1' cellpadding='5' cellspacing='0'>
                <tr><th>Product</th><th>Image</th><th>MRP</th><th>Price</th><th>Discount</th><th>Qty</th></tr>");

            foreach (var item in data.productDetails)
            {
                bodyBuilder.Append($@"
            <tr>
                <td>{item.ProductName}</td>
                <td><img src='{item.Images[0]}' alt='product' style='height:50px;' /></td>
                <td>{item.MRP}</td>
                <td>{item.Price}</td>
                <td>{item.DiscountPrice}</td>
                <td>{item.Quantity}</td>
            </tr>");
            }

            bodyBuilder.Append($@"
            </table>
            <p><b>Total Amount:</b> {data.totalAmount}</p>
            <p><b>Delivery Address:</b> {data.deliveryAddress}</p>
            <p><b>Expected Delivery Date:</b> {data.expectedDelivery}</p>
            <p>Thank you for shopping with Zaddy!</p>
        </body>
        </html>");

            var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = bodyBuilder.ToString(),
                IsBodyHtml = true
            };

            // Add inline logo image
            var logo = new LinkedResource(logoPath)
            {
                ContentId = "zaddyLogo",
                TransferEncoding = System.Net.Mime.TransferEncoding.Base64
            };

            var view = AlternateView.CreateAlternateViewFromString(bodyBuilder.ToString(), null, "text/html");
            view.LinkedResources.Add(logo);
            message.AlternateViews.Add(view);

            using var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            await smtp.SendMailAsync(message);
        }
    }
}
