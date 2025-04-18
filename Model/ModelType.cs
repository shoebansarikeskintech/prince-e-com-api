﻿using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Xml.Linq;
using static Model.ModelType;

namespace Model
{
    public class ModelType
    {
        public record RegistrationValidation(Int32 statusCode, string message);

        public record AppRole(Guid appRoleId, string roleName);

        public record Menu(Guid menuId, string menuName, string menuIcon);

        public record MenuByUserRole(int id, string menuName, string actionName, string controllerName, string pageName,
            int displayOrder, string roleName);

        public record SubMenu(Guid subMenuId, Guid menuId, string subMenuName, string subMenuPageName, string menuName, string pageName);

        public record RoleMenu(int id, Guid roleMenuId, Guid menuId, Guid appRoleId, Guid subMenuId, string menuName,
            string subMenuName, string roleName, int displayOrder);

        public record AdminUserDetails(Guid adminUserId, Guid appRoleId, string username, string firstName, string middleName,
            string lastName, string email, string phoneNumber);

        public record AdminAllUserDetails(Guid adminUserId, Guid appRoleId, string username, string firstName, string middleName,
        string lastName, string password, string email, string phoneNumber, DateTime createdDate, Guid createdBy, DateTime updatedDate, Guid updatedBy, bool active, int otp, string activeStatus);
        public record AdminDashboard(int pendingOrder, int todayOrder, int totalOrder, int returnOrder);
        public record TodayOrderList(Guid orderId, Guid userId, Guid addressId, Guid paymentId, DateTime shippedDate, decimal price,
            decimal discountPrice, decimal deliveryCharge, decimal gstCharge, decimal extraCharge, decimal totalAmount,
            string paymentMethod, string transactionId, string trackingNo, string note, string status, DateTime createdDate);

        public record Category(
            Int64 Id, Guid categoryId, string name, string image, DateTime createdDate, string status, bool active);
        public record SubCategory(
            Int64 id, Guid categoryId, string categoryName, Guid subCategoryId, string name, DateTime createdDate, string status, bool active);
        public record SubCategoryType(
            Int64 id, Guid categoryId, string categorName, Guid subCategoryId, string subCategoryName, Guid subCategoryTypeId, string name, DateTime createdDate, string status, bool active);

        public class AdminDashboardToday
        {
            public int totalUsers { get; set; }
            public int totalOrder { get; set; }
            public int pendingOrder { get; set; }
            public int todayOrder { get; set; }
            public int returnOrder { get; set; }
            public int lowProduct { get; set; }
            public int outOfStock { get; set; }
            public int totalProduct { get; set; }
            public int totalRevenue { get; set; }
            public int todayRevenue { get; set; }
            public int cancelOrder { get; set; }
            //public int StatusCode { get; set; }  // For error/unauthorized case
            //public string Message { get; set; }

            //public AdminDashboardToday() { }
        }

        public record SubCategoryTypeForUser(
            Int64 id, Guid categoryId, string categorName, Guid subCategoryId, string subCategoryName,
            Guid subCategoryTypeId, string name, DateTime createdDate, string status, bool active);

        public record Seller(
            Int64 id, Guid sellerId, string name, string mobile, string email, string streetAddress, string state, string city, string pincode,
            string country, string description, DateTime createdDate, string status, bool active);

        public record Brand(
            Int64 id, Guid brandId, string name, string description, DateTime createdDate, string status, bool active);
        public record Color(
            Int64 id, Guid colorId, string name, string code, DateTime createdDate, Guid createdBy, string status, bool active);
        public record SizeRes(
            Int64 id, Guid sizeId, string name, string code, DateTime createdDate, string status, bool active);

        public record Product(
            Int64 id, Guid productId, Guid categoryId, string categoryName, Guid subCategoryId, string subCategoryName,
            Guid subCategoryTypeId, string subCategoryTypeName, Guid sellerId, string sellerName, Guid brandId, string brandName,
            Guid colorId, string colorName, string colorCode, Guid sizeId, string sizeName, string sizeCode, string productName,
            string subName, string description, Int32 rating, Int32 noOfRating, Int32 stock, Decimal price, Decimal discountPrice,
            DateTime createdDate, DateTime updatedDate, String status, bool active, string imageUrl, string concernName, string ingredientName, Guid ConcernId, Guid IngredientId);

        public class Productdetaisl
        {
            public Int64 Id { get; set; }
            public Guid ProductId { get; set; }
            public Guid CategoryId { get; set; }
            public string? CategoryName { get; set; }
            public Guid? SubCategoryId { get; set; }
            public string? SubCategoryName { get; set; }
            public Guid? SubCategoryTypeId { get; set; }
            public string? SubCategoryTypeName { get; set; }
            public Guid SellerId { get; set; }
            public string? SellerName { get; set; }
            public Guid BrandId { get; set; }
            public string? BrandName { get; set; }
            public Guid ColorId { get; set; }
            public string? ColorName { get; set; }
            public string? ColorCode { get; set; }
            public Guid? SizeId { get; set; }
            public string? SizeName { get; set; }
            public string? SizeCode { get; set; }
            public string? ProductName { get; set; }
            public string? SubName { get; set; }
            public string? Description { get; set; }
            public Int32 Rating { get; set; }
            public Int32 NoOfRating { get; set; }
            public Int32 Stock { get; set; }
            public Decimal Price { get; set; }
            public Decimal DiscountPrice { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime UpdatedDate { get; set; }
            public string? Status { get; set; }
            public bool Active { get; set; }
            public string? concernName { get; set; }
            public string? ingredientName { get; set; }
            public Guid ConcernId { get; set; }
            public Guid IngredientId { get; set; }
            public string? ImageUrl { get; set; }
            public List<string> ImageUrls { get; set; }


        }

        public class ProductbyIdImage
        {
            public string name { get; set; }
            public string imageUrl { get; set; }

            public ProductbyIdImage() { } // 👈 parameterless constructor required for Dapper
        }

        public record ProductDetails(Int64 id, Guid productId, Guid categoryId, string categoryName, Guid subCategoryId, string subCategoryName,
            Guid subCategoryTypeId, string subCategoryTypeName, Guid sellerId, string sellerName, Guid brandId, string brandName,
            Guid colorId, string colorName, string colorCode, Guid sizeId, string sizeName, string sizeCode, string productName,
            string subName, string description, Int32 rating, Int32 noOfRating, Int32 stock, Decimal price, Decimal discountPrice,
            DateTime createdDate, DateTime updatedDate, String status, bool active, string image, string concernName, string ingredientName);
        public record ProductImage(Int64 id, Guid productImageId, Guid productId, string title, string imageUrl, DateTime createdDate);
        public record Discount(Int64 id, Guid discountId, Guid productId, string code, string discountType, Decimal discount,
            Decimal productAmount, DateTime validDate, DateTime expireDate, DateTime createdDate, string Status);
        public record Coupon( long Id,Guid CouponId, string Code, string Details, string AmountType, decimal Amount,Guid CreatedBy, DateTime CreatedDate,string  Status,bool active, Guid UpdatedBy,DateTime UpdatedDate);

        public record GiftCard(
            Int64 id, Guid giftCardId, Guid appUserId, string cardNumber, Decimal balance, string status, DateTime issueDate,
            DateTime expireDate, DateTime createdDate, string Status);
        public class Notification
        {
            public Int64 id { get; set; }
            public Guid notificationId { get; set; }
            public string? title { get; set; }
            public string? description { get; set; }
            public string? createdDate { get; set; }
            public string? status { get; set; }          
            public bool active { get; set; }          
        }


        public record Orderbyuserid(
                                    long Id, Guid OrderId, Guid UserId, string Username, string FirstName, string MiddleName,
                                    string LastName, string PhoneNumber, string Email, Guid AddressId, Guid PaymentId, string ShippedDate,
                                    decimal Price, decimal DiscountPrice, decimal DeliveryCharge, decimal GstCharge, decimal ExtraCharge,
                                    decimal TotalAmount, string PaymentMethod, string TransactionId, string TrackingNo, string Note,
                                    string Status, string CreatedDate, string orderNo, Guid couponId, string couponCode, decimal couponAmount, string FullAddress);
        public record Order(
       long Id, Guid OrderId, Guid UserId, string Username, string FirstName, string MiddleName,
       string LastName, string PhoneNumber, string Email, Guid AddressId, Guid PaymentId, string ShippedDate,
       decimal Price, decimal DiscountPrice, decimal DeliveryCharge, decimal GstCharge, decimal ExtraCharge,
       decimal TotalAmount, string PaymentMethod, string TransactionId, string TrackingNo, string Note,
       string Status, string CreatedDate, string orderNo, Guid couponId);

        public record OrderDetailsById(
       long Id, string ShippedDate, string TransactionId, string Status, string orderNo, int Quantity, decimal Price,
       decimal DiscountPrice, decimal TotalAmount, string Username, string Name, string Image, string ProductName, Guid couponId,string BillingAddress,string sellerName,string sellerAddress);

        public record OrderDetailsByName(
       long Id, string ShippedDate, string TransactionId, string Status, int Quantity, decimal Price,
       decimal DiscountPrice, decimal TotalAmount, string Username, string Name, string Image, string ProductName);

        public record OrderDetails(
            Int64 id, Guid orderId, Guid userId, string username, string firstName, string middleName, string lastName, string phoneNumber, string email, Guid addressId, Guid paymentId, string shippedDate, decimal price,
        decimal discountPrice, decimal deliveryCharge, decimal gstCharge, decimal extraCharge, decimal totalAmount, string paymentMethod, string transactionId,
        string trackingNo, string note, string status, DateTime createdDate);

        public record CancelOrder(
            Int64 id, Guid orderId, Guid userId, string username,
        string firstName, string middleName, string lastName, string phoneNumber, string email, Guid addressId,
       Guid paymentId, string cancelOrderDate, decimal price, decimal discountPrice, decimal deliveryCharge,
       decimal gstCharge, decimal extraCharge, decimal totalAmount, string paymentMethod, string transactionId, string trackingNo,
       string note, string status, DateTime createdDate);

        public record AllRefundOrder(
            Int64 id, Guid returnId, Guid orderId, Guid userId, int quantity, string reason, string returnStatus,
            string refundMethod, Decimal refundAmount, string refundStatus, string refundTrackingNo, DateTime refundDate, string adminRemark, DateTime createdDate, bool active);

        public record Shipping(
            Int64 id, Guid shippingId, Guid orderId, string trackingNo, string carrier, DateTime estimateDelivery, string status, DateTime createdDate);

        public record Banner(
            Int64 id, Guid bannerId, Guid categoryId, Guid subCategoryId, Guid subCategoryTypeId, string image,
            string title, string subTitle, DateTime createdDate, string status, bool active);

        public record BannerForUser(
            Int64 id, Guid bannerId, Guid categoryId, Guid subCategoryId, Guid subCategoryTypeId, string image,
            string title, string subTitle, DateTime createdDate);

        public record Payment(
            Int64 id, Guid paymentId, Guid orderId, string paymentMethod, string transactionId, string status, string createdDate);
        public record PaymentMode(
            Int64 id, Guid paymentModeId, string paymentName, DateTime createdDate, string status, bool active);
        public record AllPayment(Int64 id, Guid paymentId, Guid orderId, string paymentMethod, string transactionId, string status, string createdDate, string username, decimal price,
            decimal discountPrice, decimal deliveryCharge, decimal gstCharge, decimal extraCharge, decimal totalAmount);

        public record SortBy(Int64 id, Guid sortById, string sortByName, DateTime createdDate, string status, bool active);

        public class PinCodeshippingMethod
        {
            public long Id { get; set; }
            public Guid PinCodeShippingId { get; set; }
            public int PinCode { get; set; }
            public Guid ShippingMethodId { get; set; }
            public DateTime CreatedDate { get; set; }
            public string Status { get; set; }
            public bool Active { get; set; }

            // Ensure the class has a parameterless constructor
            public PinCodeshippingMethod() { }

            // Or, constructor matching the signature
            public PinCodeshippingMethod(long id, Guid pinCodeShippingId, int pinCode, Guid shippingMethodId, DateTime createdDate, string status, bool active)
            {
                Id = id;
                PinCodeShippingId = pinCodeShippingId;
                PinCode = pinCode;
                ShippingMethodId = shippingMethodId;
                CreatedDate = createdDate;
                Status = status;
                Active = active;
            }
        }
        public record AppUser(Int64 id, Guid userId, Guid appRoleId, string username, string firstName, string middleName, string lastName,
         string email, string phoneNumber, string createdDate, string Status, bool active);
        public record AllOrderByUserId(
    Int64 id, string shippedDate, decimal price, decimal discountPrice, decimal deliveryCharge,
    decimal gstCharge, decimal extraCharge, decimal totalAmount, string paymentMethod, string transactionId,
    string trackingNo, string note, string status, DateTime createdDate, string orderNo, string firstName,
    string middleName, string lastName, string email, string phoneNumber,
    string addressName, string addressMobile, string addressEmail, string streetAddress,
    string state, string city, string pincode, string country);

        public record UserProfile(
            Guid userId, string username, string firstName, string middleName, string lastName, string email, string phoneNumber, DateTime createdDate);

        public record Address(
            long id, Guid addressId, int isDefualt, string name, string mobile, string email, string streetAddress, string state, string city, string pincode, string country, DateTime createdDate, string Status, bool active, string city_Name, string state_Name, string country_Name);

        public record CartItemCount
        {
            public Int64 ItemCount { get; init; }

            public CartItemCount() { }
            public CartItemCount(Int64 itemCount) => ItemCount = itemCount;
        }

        //public record CartItemCount(Int64 ItemCount);
        public record Cart(
            Guid productId, string productName, string subName, string image, decimal price, decimal discountPrice,
            Int32 quantity, decimal totalPrice);
        public record ShippingMethod(
            Int64 Id, Guid shippingMethodId, string name, string courier, string shippingZone, string baseCost, string costPerKg,
            string maxWeightLimit, string minOrderValue, string trackingURL, DateTime createdDate, string Status, bool active);

        public record IngredientMethod(
            Int64 Id, Guid ingredientId, string name, string description, DateTime createdDate, string Status, bool active);
        public record class CountryMethod(
            int Country_Id, string Country_Code, string Country_Name, int phonecode, bool IsActive)
        {
            public CountryMethod() : this(0, string.Empty, string.Empty, 0, false) { }
        }

        public record class StateMethod(
            int Pk_StateId, string StateName, int Fk_CountryId)
        {
            public StateMethod() : this(0, string.Empty, 0) { }
        }
        public record City(
            int Fk_StateId, string CityName, int Pk_CityId);
        public record ConcernMethod(Int64 Id, Guid ConcernId, string name, string description, DateTime createdDate, string Status, bool active);

        public record RatingRiview(long id, string username, string description, int like, int dislike, DateTime createdDate, DateTime updatedDate, bool active, string title);

        public class RatingRiviewStar
        {
            public long TotalReview { get; set; }
            public long rating1 { get; set; }
            public long rating2 { get; set; }
            public long rating3 { get; set; }
            public long rating4 { get; set; }
            public long rating5 { get; set; }
            public decimal AverageRating { get; set; }
            public string? ProductName { get; set; }
        }

        public class OrderViewModel
        {
            public Guid orderId { get; set; }
            public string? shippedDate { get; set; }
            public string? orderNo { get; set; }
            public string? BillingAddress { get; set; }
                   
            public string? sellerAddress { get; set; }
            public List<OrderItemModel> items { get; set; }
        }

        public class OrderItemModel
        {
            public string? name { get; set; }
            public string? image { get; set; }
            public int quantity { get; set; }
            public decimal? price { get; set; }
            public decimal? discountPrice { get; set; }
            public decimal? gstCharge { get; set; }
            public decimal? totalAmount { get; set; }
            public decimal? extraCharge { get; set; }
        }
    }
}
