using System.Diagnostics;
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
        public class Menu
        {
            public int id { get; set; }
            public Guid menuId { get; set; }
            public string? menuName { get; set; }
            public string? menuIcon { get; set; }
            public string? status { get; set; }
            public bool active { get; set; }
        }

        public record MenuByUserRole(int id, string menuName, string actionName, string controllerName, string pageName,
            int displayOrder, string roleName);

        public record SubMenu(Guid subMenuId, Guid menuId, string subMenuName, string subMenuPageName, string menuName, string pageName);
        public record GetAllSubMenu(int id, Guid subMenuId, Guid menuId, string subMenuName, string subMenuPageName, string menuName, string pageName, string status, bool active);

        public record SubMenubyid(int id, Guid subMenuId, Guid menuId, string subMenuName, string subMenuPageName, int displayOrder, string createdDate,
        Guid createdBy, string Status, bool active);


        public record RoleMenu(int id, Guid roleMenuId, Guid menuId, Guid appRoleId, Guid subMenuId, string menuName,
            string subMenuName, string roleName, int displayOrder);

        public record AdminUserDetails(Guid adminUserId, Guid appRoleId, string username, string firstName, string middleName,
            string lastName, string email, string phoneNumber, string password);

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
            public int lastWeekUsers { get; set; }
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
                        Guid subCategoryTypeId, string subCategoryTypeName, Guid sellerId, string sellerName, Guid stepsId, string stepsName,
                        Guid typeOfProductId, string typeOfProductIdName, Guid sizeId, string sizeName, string sizeCode, string productName,
                        string subName, string description, Int32 rating, Int32 noOfRating, Int32 stock, Decimal price, Decimal discountPrice,
                        DateTime createdDate, DateTime updatedDate, String status, bool active, string imageUrl, string concernName, string ingredientName, Guid ConcernId, Guid IngredientId);

        public record AllProduct(Int64 id, Guid productId, Guid categoryId, string categoryName, Guid subCategoryId, string subCategoryName,
                        Guid subCategoryTypeId, string subCategoryTypeName, Guid sellerId, string sellerName, Guid sizeId, string sizeName, string sizeCode,
                        string productName, string subName, string description, Int32 rating, Int32 noOfRating, Int32 stock, Decimal price, Decimal discountPrice,
                        DateTime createdDate, DateTime updatedDate, string status, bool active, string imageUrl, string concernName, string ingredientName,
                        Guid concernId, Guid ingredientId, bool isNewArrial, bool isBestSeller, bool isRecommended, Guid stepsId, string stepsName,
                        Guid typeOfProductId, string typeOfProductName);

        public record AllSteps(
            Int64 id, Guid StepsId, string name, string description, DateTime createdDate, string status, bool active);

        public record AllTypeofProduct(
            Int64 id, Guid TypeofProductId, string name, string description, DateTime createdDate, string status, bool active);

        public record searchProductNew(
      Guid commonId, string typeName, string commonProduct, int Ids, string createdDate, Guid createdBy, string status, bool active);

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

            public ProductbyIdImage() { }
        }

        public record ProductDetails(Int64 id, Guid productId, Guid categoryId, string categoryName, Guid subCategoryId, string subCategoryName,
            Guid subCategoryTypeId, string subCategoryTypeName, Guid sellerId, string sellerName, Guid sizeId, string sizeName, string sizeCode, string productName,
            string subName, string description, Int32 rating, Int32 noOfRating, Int32 stock, Decimal price, Decimal discountPrice,
            DateTime createdDate, DateTime updatedDate, String status, bool active, string image, string concernName, string ingredientName, Guid stepsId, string stepsName, Guid typeOfProductId, string typeOfProductName);
        public record ProductImage(Int64 id, Guid productImageId, Guid productId, string title, string imageUrl, DateTime createdDate);
        public record Discount(Int64 id, Guid discountId, Guid productId, string code, string discountType, Decimal discount,
            Decimal productAmount, DateTime validDate, DateTime expireDate, DateTime createdDate, string Status);
        public record Coupon(long Id, Guid CouponId, string Code, string Details, string AmountType, decimal Amount, Guid CreatedBy, DateTime CreatedDate, string Status, bool active, Guid UpdatedBy, DateTime UpdatedDate);

        public record GiftCard(Int64 id, Guid giftCardId, Guid appUserId, string cardNumber, Decimal balance, string status, DateTime issueDate,
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
        public class OrderByUserIds
        {
            public long Id { get; set; }
            public Guid OrderId { get; set; }
            public Guid UserId { get; set; }
            public string Username { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public Guid AddressId { get; set; }
            public Guid PaymentId { get; set; }
            public string ShippedDate { get; set; }
            public decimal Price { get; set; }
            public decimal DiscountPrice { get; set; }
            public decimal DeliveryCharge { get; set; }
            public decimal GstCharge { get; set; }
            public decimal ExtraCharge { get; set; }
            public decimal TotalAmount { get; set; }
            public string PaymentMethod { get; set; }
            public string TransactionId { get; set; }
            public string TrackingNo { get; set; }
            public string Note { get; set; }
            public string Status { get; set; }
            public string CreatedDate { get; set; }
            public string OrderNo { get; set; }
            public Guid CouponId { get; set; }
            public string CouponCode { get; set; }
            public decimal CouponAmount { get; set; }
            public string FullAddress { get; set; }
        }


        public record Orderbyuserid(
                            long Id, Guid OrderId, Guid UserId, string Username, string FirstName, string MiddleName,
                            string LastName, string PhoneNumber, string Email, Guid AddressId, Guid PaymentId, string ShippedDate,
                            decimal Price, decimal DiscountPrice, decimal DeliveryCharge, decimal GstCharge, decimal ExtraCharge,
                            decimal TotalAmount, string PaymentMethod, string TransactionId, string TrackingNo, string Note,
                            string Status, string CreatedDate, string orderNo, Guid couponId, string couponCode, decimal couponAmount, string FullAddress);

        public class Order
        {
            public long Id { get; set; }
            public string? OrderNo { get; set; }
            public Guid OrderId { get; set; }
            public Guid UserId { get; set; }
            public string? Username { get; set; }
            public string? FirstName { get; set; }
            public string? MiddleName { get; set; }
            public string? LastName { get; set; }
            public string? PhoneNumber { get; set; }
            public string? Email { get; set; }
            public Guid AddressId { get; set; }
            public Guid PaymentId { get; set; }
            public string? ShippedDate { get; set; }
            public decimal Price { get; set; }
            public decimal DiscountPrice { get; set; }
            public decimal DeliveryCharge { get; set; }
            public decimal GstCharge { get; set; }
            public decimal ExtraCharge { get; set; }
            public decimal TotalAmount { get; set; }
            public string? PaymentMethod { get; set; }
            public string? TransactionId { get; set; }
            public string? TrackingNo { get; set; }
            public string? Note { get; set; }
            public string? Status { get; set; }
            public string? CreatedDate { get; set; }
            public Guid CouponId { get; set; }
            public string? CouponCode { get; set; }
            public decimal Amount { get; set; }
            public string? FullAddress { get; set; }
        }

        public class AllOrder
        {
            public long Id { get; set; }
            public string? OrderNo { get; set; }
            public Guid OrderId { get; set; }
            public Guid UserId { get; set; }
            public string? Username { get; set; }
            public string? FirstName { get; set; }
            public string? MiddleName { get; set; }
            public string? LastName { get; set; }
            public string? PhoneNumber { get; set; }
            public string? Email { get; set; }
            public Guid AddressId { get; set; }
            public Guid PaymentId { get; set; }
            public string? ShippedDate { get; set; }
            public decimal Price { get; set; }
            public decimal DiscountPrice { get; set; }
            public decimal DeliveryCharge { get; set; }
            public decimal GstCharge { get; set; }
            public decimal ExtraCharge { get; set; }
            public decimal TotalAmount { get; set; }
            public string? PaymentMethod { get; set; }
            public string? TransactionId { get; set; }
            public string? TrackingNo { get; set; }
            public string? Note { get; set; }
            public string? Status { get; set; }
            public string? CreatedDate { get; set; }
            public Guid CouponId { get; set; }
            public string? CouponCode { get; set; }
            public decimal? CouponAmount { get; set; }
            public string? FullAddress { get; set; }
        }

        public class AllSearchOrder
        {
            public int id { get; set; }
            public string shippedDate { get; set; }
            public string transactionId { get; set; }
            public string status { get; set; }
            public string orderNo { get; set; }
            public int quantity { get; set; }
            public decimal price { get; set; }
            public decimal discountPrice { get; set; }
            public decimal totalAmount { get; set; }
            public Guid orderId { get; set; }
            public string username { get; set; }
            public string name { get; set; }
            public string Image { get; set; }
            public string productName { get; set; }
            public Guid couponId { get; set; }
            public string BillingAddress { get; set; }
            public string sellerName { get; set; }
            public string sellerAddress { get; set; }

            // Parameterless constructor required by Dapper
            public AllSearchOrder() { }
        }

        public class OrderDetailsById
        {
            public long Id { get; set; }
            public string? ShippedDate { get; set; }
            public string? TransactionId { get; set; }
            public string? Status { get; set; }
            public string? OrderNo { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public decimal DiscountPrice { get; set; }
            public decimal TotalAmount { get; set; }
            public string? Username { get; set; }
            public string? Name { get; set; }
            public string? Image { get; set; }
            public string? ProductName { get; set; }
            public Guid CouponId { get; set; }
            public string? BillingAddress { get; set; }
            public string? SellerName { get; set; }
            public string? SellerAddress { get; set; }
        }

        public record OrderDetailsByName(long Id, string ShippedDate, string TransactionId, string Status, int Quantity, decimal Price,
                              decimal DiscountPrice, decimal TotalAmount, string Username, string Name, string Image, string ProductName);

        public record OrderDetails(
            Int64 id, Guid orderId, Guid userId, string username, string firstName, string middleName, string lastName, string phoneNumber, string email, Guid addressId, Guid paymentId, string shippedDate, decimal price,
        decimal discountPrice, decimal deliveryCharge, decimal gstCharge, decimal extraCharge, decimal totalAmount, string paymentMethod, string transactionId,
        string trackingNo, string note, string status, DateTime createdDate);

        public record CancelOrder(
                    Int64 id, string orderNo, Guid orderId, Guid userId, string username,
                    string firstName, string middleName, string lastName, string phoneNumber, string email, Guid addressId,
                    Guid paymentId, string cancelOrderDate, decimal price, decimal discountPrice, decimal deliveryCharge,
                    decimal gstCharge, decimal extraCharge, decimal totalAmount, string paymentMethod, string transactionId, string trackingNo,
                    string note, string status, string createdDate);

        public record AllRefundOrder(
            Int64 id, Guid returnId, Guid orderId, Guid userId, int quantity, string reason, string returnStatus,
            string refundMethod, Decimal refundAmount, string refundStatus, string refundTrackingNo, DateTime refundDate, string adminRemark, DateTime createdDate, bool active);

        public record PinCodeActive(int pinCode, int noOfDays);
        public class Shipping
        {
            public long Id { get; set; }
            public string? OrderNo { get; set; }
            public Guid ShippingId { get; set; }
            public Guid OrderId { get; set; }
            public string? TrackingNo { get; set; }
            public string? Carrier { get; set; }
            public string? EstimateDelivery { get; set; }
            public string? Status { get; set; }
            public string? CreatedDate { get; set; }
            public string? username { get; set; }
        }

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
        public record AllSkinInsightProduct(long id, Guid skininsightproductId, Guid productId, string Age, string Gender, string Skintype,
            string SkinSensitive, DateTime createdDate, Guid createdBy, string Status, bool active
        );
        public class SimilarProduct
        {
            public int id { get; set; }
            public Guid SimilarProductId { get; set; }
            public Guid productId { get; set; }
            public Guid subProductId { get; set; }
            public string? createdDate { get; set; }
            public Guid createdBy { get; set; }
            public string? Status { get; set; }
            public bool active { get; set; }
            public string? productName { get; set; }
            public string? description { get; set; }
            public decimal discountPrice { get; set; }
            public decimal price { get; set; }
            public int rating { get; set; }

            // ✅ Add this property to hold image URLs
            public List<string>? image { get; set; } = new List<string>();
        }


        public class SimilarProductImage
        {
            public string? image { get; set; }
        }



        //public record SimilarProduct(int id, Guid SimilarProductId, Guid productId, Guid subProductId, string createdDate, Guid createdBy, string Status, bool active,
        //    string productName, string description, decimal discountPrice, decimal price, int rating, string image);
        //public class SimilarProductImage
        //{
        //    public string? imgae { get; set; }
        //}
        public class SkinInsightProductModel
        {
            public int id { get; set; }
            public Guid skininsightproductId { get; set; }
            public Guid productId { get; set; }
            public string? Age { get; set; }
            public string? Gender { get; set; }
            public string? Skintype { get; set; }
            public string? SkinSensitive { get; set; }
            public string? createdDate { get; set; }
            public Guid createdBy { get; set; }
            public string? Status { get; set; }
            public bool active { get; set; }
        }

        public class SearchByPrdoct
        {
            public int id { get; set; }
            public string? categoryName { get; set; }
            public string? subCategoryName { get; set; }
            public string? subCategoryTypeName { get; set; }
            public string? stepsName { get; set; }
            public string? typeOfProductName { get; set; }
            public string? sizename { get; set; }
            public string? concernname { get; set; }
            public string? ingredientName { get; set; }
            public string? productname { get; set; }

            public int ProductId { get; set; }
            public int categoryId { get; set; }
            public int SubcategoryId { get; set; }
            public int SubCategoryType { get; set; }
            public int stepsId { get; set; }
            public int typeOfProductId { get; set; }
            public int sizeId { get; set; }
            public int concernId { get; set; }
            public int IngredientId { get; set; }
        }

        public class SkinInsightProduct
        {
            public string? age { get; set; }
            public string? Gender { get; set; }
            public string? skinType { get; set; }
            public string? SkinSensitive { get; set; }
            public string? categoryName { get; set; }
            public string? subCategoryName { get; set; }
            public string? stepsName { get; set; }
            public string? typeOfProductName { get; set; }
            public string? sizeName { get; set; }
            public string? concernName { get; set; }
            public string? ingredientName { get; set; }
            public string? productName { get; set; }
            public decimal rating { get; set; }
            public string? description { get; set; }
            public string? tittle { get; set; }
            public decimal discountPrice { get; set; }
            public decimal price { get; set; }
            public int noOfRating { get; set; }
            public string? Image { get; set; }

            public int productId { get; set; }
            public int categoryId { get; set; }
            public int subCategoryId { get; set; }
            public int subCategoryTypeId { get; set; }
            public int sellerId { get; set; }
            public int stepsId { get; set; }
            public int typeOfId { get; set; }
            public int sizeId { get; set; }
            public int concernId { get; set; }
            public int ingredientId { get; set; }
        }

        public class PrdoctSearchByFilter
        {
            public int categoryId { get; set; }
            public int subcategoryId { get; set; }
            public int subcategoryTypeId { get; set; }
            public int productId { get; set; }
            public Guid GproductId { get; set; }
            public int sellerId { get; set; }
            public int stepsId { get; set; }
            public int typeofProductId { get; set; }
            public int SizeId { get; set; }
            public int concernId { get; set; }
            public int ingredientId { get; set; }
            public string? categoryName { get; set; }
            public string? subCategoryName { get; set; }
            public string? subcategoryTypeName { get; set; }
            public string? productName { get; set; }
            public long stock { get; set; }
            public string? productDescription { get; set; }
            public decimal productPrice { get; set; }
            public decimal discountPrice { get; set; }
            public string? productImage { get; set; }
            public int rating { get; set; }
            public int noOfRating { get; set; }
            public string? sellerName { get; set; }
            public string? stepsName { get; set; }
            public string? typeofProductName { get; set; }
            public string? sizeName { get; set; }
            public string? concernName { get; set; }
            public string? ingredientName { get; set; }
        }

        public class PinCodeshippingMethod
        {
            public long Id { get; set; }
            public Guid PinCodeShippingId { get; set; }
            public int PinCode { get; set; }
            public Guid ShippingMethodId { get; set; }
            public DateTime CreatedDate { get; set; }
            public string Status { get; set; }
            public bool Active { get; set; }
            public int noOfDays { get; set; }

            public PinCodeshippingMethod() { }

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
        public class AllOrderByUserId
        {
            public Int64 Id { get; set; }
            public string? ShippedDate { get; set; }
            public decimal Price { get; set; }
            public decimal DiscountPrice { get; set; }
            public decimal DeliveryCharge { get; set; }
            public decimal GstCharge { get; set; }
            public decimal ExtraCharge { get; set; }
            public decimal TotalAmount { get; set; }
            public string? PaymentMethod { get; set; }
            public string? TransactionId { get; set; }
            public string? TrackingNo { get; set; }
            public string? Note { get; set; }
            public string? Status { get; set; }
            public DateTime CreatedDate { get; set; }
            public string? OrderNo { get; set; }
            public string? FirstName { get; set; }
            public string? MiddleName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public string? PhoneNumber { get; set; }
            public string? AddressName { get; set; }
            public string? AddressMobile { get; set; }
            public string? AddressEmail { get; set; }
            public string? StreetAddress { get; set; }
            public string? State { get; set; }
            public string? City { get; set; }
            public string? Pincode { get; set; }
            public string? Country { get; set; }
        }


        public record UserProfile(
            Guid userId, string username, string firstName, string middleName, string lastName, string email, string phoneNumber, DateTime createdDate);

        public record Address(
            long id, Guid addressId, bool isDefualt, string name, string mobile, string email, string streetAddress, string state, string city, string pincode, string country, DateTime createdDate, string Status, bool active, string city_Name, string state_Name, string country_Name);

        public record CartItemCount
        {
            public Int64 ItemCount { get; init; }

            public CartItemCount() { }
            public CartItemCount(Int64 itemCount) => ItemCount = itemCount;
        }

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

        public record RatingRiviewByProductId(long id, Guid ProductFaqid, Guid productId, string Title, string Description, Guid CreatedBy, string createdDate, string Status, bool active, string faqType);
        public record Faq(long id, Guid ProductFaqid, Guid productId, string Title, string Description, Guid CreatedBy, string createdDate, string Status, bool active, string faqType);

        public record ProductSpecification(long id, Guid ProductSpecificationid, Guid productId, string producttype, string netquantity, string shelfLife, string countryOfOrigin, string SKUcode, Guid ManufacturedBy, string ConsumerCareAddress, Guid CreatedBy, string CreatedDate, Guid updatedBy, string updatedDate, string status, bool active);
        public record FaqIngredient(long id, Guid ProductFaqid, Guid productId, string Title, string Description, Guid CreatedBy, string createdDate, string Status, bool active, string faqType);
        public record FaqWithProduct(long id, Guid ProductFaqid, Guid productId, string Title, string Description, Guid CreatedBy, string createdDate, string Status, bool active, string faqType);


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
