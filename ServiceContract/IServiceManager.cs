
namespace ServiceContract
{
    public interface IServiceManager
    {
        IAuthenticationContract authenticationContract { get; }
        IAppRoleContract appRoleContract { get; }
        IMenuContract menuContract { get; }
        ISubMenuContract subMenuContract { get; }
        IAdminAuthenticationContract adminAuthenticationContract { get; }
        IRoleMenuContract roleMenuContract { get; }
        ICategoryContract categoryContract { get; }
        ISubCategoryContract subCategoryContract { get; }
        ISubCategoryTypeContract subCategoryTypeContract { get; }
        ISellerContract sellerContract { get; }
        IBrandContract brandContract { get; }
        IColorContract colorContract { get; }
        ISizeContract sizeContract { get; }
        IProductContract productContract { get; }
        IDiscountContract discountContract { get; }
        IGiftCardContract giftCardContract { get; }
        INotificationContract notificationContract { get; }
        IOrderContract orderContract { get; }
        IPaymentContract paymentContract { get; }
        IReturnRefundContract returnRefundContract { get; }
        IShippingContract shippingContract { get; }
        IBannerContract bannerContract { get; }
        IDashboardContract dashboardContract { get; }
        IFilterContract filterContract { get; }
        ICustomerManagementContract customerManagementContract { get; }
        IAddressContract addressContract { get; }
        IShippingMethodContract shippingMethodContract { get; }
        ICartContract cartContract { get; }
        IIngredientContract ingredientContract { get; }
        IGeographyContract geographyContract { get; }
        IConcernContract concernContract { get; }
    }
}
