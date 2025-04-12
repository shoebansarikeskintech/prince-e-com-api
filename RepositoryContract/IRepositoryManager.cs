
namespace RepositoryContract
{
    public interface IRepositoryManager
    {
        IAuthenticationRepository authenticationRepository { get; }
        IAppRoleRepository appRoleRepository { get; }
        IMenuRepository menuRepository { get; }
        ISubMenuRepository subMenuRepository { get; }
        IRoleMenuRepository roleMenuRepository { get; }
        IAdminAuthenticationRepository adminAuthenticationRepository { get; }
        ICategoryRepository categoryRepository { get; }
        ISubCategoryRepository subCategoryRepository { get; }
        ISubCategoryTypeRepository subCategoryTypeRepository { get; }
        ISellerRepository sellerRepository { get; }
        IBrandRepository brandRepository { get; }
        IColorRepository colorRepository { get; }
        ISizeRepository sizeRepository { get; }
        IProductRepository productRepository { get; }
        IDiscountRepository discountRepository { get; }
        IGiftCardRepository giftCardRepository { get; }
        INotificationRepository notificationRepository { get; }
        IOrderRepository orderRepository { get; }
        IPaymentRepository paymentRepository { get; }
        IReturnRefundRepository returnRefundRepository { get; }
        IShippingRepository shippingRepository { get; }
        IBannerRepository bannerRepository { get; }
        IDashboardRepository dashboardRepository { get; }
        IFilterRepository filterRepository { get; }
        ICustomerManagementRepository customerManagementRepository { get; }
        IAddressRepository addressRepository { get; }
        IShippingMethodRepository shippingMethodRepository { get; }
        ICartRepository cartRepository { get; }
        IIngredientRepository ingredientRepository { get; }

        IGeographyRepository geographyRepository { get; }
        IConcernReposotory concernReposotory { get; }
        IRatingReviewRepository ratingReviewRepository { get; }
    }
}
