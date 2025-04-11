using RepositoryContract;
using ServiceContract;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationContract> _authenticationContract;
        private readonly Lazy<IAppRoleContract> _appRoleContract;
        private readonly Lazy<IMenuContract> _menuContract;
        private readonly Lazy<ISubMenuContract> _subMenuContract;
        private readonly Lazy<IRoleMenuContract> _roleMenuContract;
        private readonly Lazy<IAdminAuthenticationContract> _adminAuthenticationContract;
        private readonly Lazy<ICategoryContract> _categoryContract;
        private readonly Lazy<ISubCategoryContract> _subCategoryContract;
        private readonly Lazy<ISubCategoryTypeContract> _subCategoryTypeContract;
        private readonly Lazy<ISellerContract> _sellerContract;
        private readonly Lazy<IBrandContract> _brandContract;
        private readonly Lazy<IColorContract> _colorContract;
        private readonly Lazy<ISizeContract> _sizeContract;
        private readonly Lazy<IProductContract> _productContract;
        private readonly Lazy<IDiscountContract> _discountContract;
        private readonly Lazy<IGiftCardContract> _giftCardContract;
        private readonly Lazy<INotificationContract> _notificationContract;
        private readonly Lazy<IOrderContract> _orderContract;
        private readonly Lazy<IPaymentContract> _paymentContract;
        private readonly Lazy<IReturnRefundContract> _returnRefundContract;
        private readonly Lazy<IShippingContract> _shippingContract;
        private readonly Lazy<IBannerContract> _bannerContract;
        private readonly Lazy<IDashboardContract> _dashboardContract;
        private readonly Lazy<IFilterContract> _filterContract;
        private readonly Lazy<ICustomerManagementContract> _customerManagementContract;
        private readonly Lazy<IAddressContract> _addressContract;
        private readonly Lazy<IShippingMethodContract> _shippingMethodContract;
        private readonly Lazy<ICartContract> _cartContract;
        private readonly Lazy<IIngredientContract> _ingredientContract;
        private readonly Lazy<IGeographyContract> _geographyContract;
        private readonly Lazy<IConcernContract> _concernContract;
        
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _authenticationContract = new Lazy<IAuthenticationContract>(() => new AuthenticationService(repositoryManager));
            _appRoleContract = new Lazy<IAppRoleContract>(() => new AppRoleService(repositoryManager));
            _menuContract = new Lazy<IMenuContract>(() => new MenuService(repositoryManager));
            _subMenuContract = new Lazy<ISubMenuContract>(() => new SubMenuService(repositoryManager));
            _roleMenuContract = new Lazy<IRoleMenuContract>(() => new RoleMenuService(repositoryManager));
            _adminAuthenticationContract = new Lazy<IAdminAuthenticationContract>(() => new AdminAuthenticationService(repositoryManager));
            _categoryContract = new Lazy<ICategoryContract>(() => new CategoryService(repositoryManager));
            _subCategoryContract = new Lazy<ISubCategoryContract>(() => new SubCategoryService(repositoryManager));
            _subCategoryTypeContract = new Lazy<ISubCategoryTypeContract>(() => new SubCategoryTypeService(repositoryManager));
            _sellerContract = new Lazy<ISellerContract>(() => new SellerService(repositoryManager));
            _brandContract = new Lazy<IBrandContract>(() => new BrandService(repositoryManager));
            _colorContract = new Lazy<IColorContract>(() => new ColorService(repositoryManager));
            _sizeContract = new Lazy<ISizeContract>(() => new SizeService(repositoryManager));        
            _productContract = new Lazy<IProductContract>(() => new ProductService(repositoryManager));
            _discountContract = new Lazy<IDiscountContract>(() => new DiscountService(repositoryManager));        
            _giftCardContract = new Lazy<IGiftCardContract>(() => new GiftCardService(repositoryManager));
            _notificationContract = new Lazy<INotificationContract>(() => new NotificationService(repositoryManager));
            _orderContract = new Lazy<IOrderContract>(() => new OrderService(repositoryManager));
            _paymentContract = new Lazy<IPaymentContract>(() => new PaymentService(repositoryManager));
            _returnRefundContract = new Lazy<IReturnRefundContract>(() => new ReturnRefundService(repositoryManager));        
            _shippingContract = new Lazy<IShippingContract>(() => new ShippingService(repositoryManager));
            _bannerContract = new Lazy<IBannerContract>(() => new BannerService(repositoryManager));
            _dashboardContract = new Lazy<IDashboardContract>(() => new DashboardService(repositoryManager));
            _filterContract = new Lazy<IFilterContract>(() => new FilterService(repositoryManager));
            _customerManagementContract = new Lazy<ICustomerManagementContract>(() => new CustomerManagementService(repositoryManager));        
            _addressContract = new Lazy<IAddressContract>(() => new AddressService(repositoryManager));
            _shippingMethodContract = new Lazy<IShippingMethodContract>(() => new ShippingMethodService(repositoryManager));        
            _addressContract = new Lazy<IAddressContract>(() => new AddressService(repositoryManager));        
            _cartContract = new Lazy<ICartContract>(() => new CartService(repositoryManager));
            _ingredientContract = new Lazy<IIngredientContract>(() => new IngredientServices(repositoryManager));
            _geographyContract = new Lazy<IGeographyContract>(() => new GeographyService(repositoryManager));
            _concernContract = new Lazy<IConcernContract>(() => new ConcernService(repositoryManager));        
        }

        public IAuthenticationContract authenticationContract => _authenticationContract.Value;
        public IAppRoleContract appRoleContract => _appRoleContract.Value;
        public IMenuContract menuContract => _menuContract.Value;
        public ISubMenuContract subMenuContract => _subMenuContract.Value;
        public IRoleMenuContract roleMenuContract => _roleMenuContract.Value;
        public IAdminAuthenticationContract adminAuthenticationContract => _adminAuthenticationContract.Value;
        public ICategoryContract categoryContract => _categoryContract.Value;
        public ISubCategoryContract subCategoryContract => _subCategoryContract.Value;
        public ISubCategoryTypeContract subCategoryTypeContract => _subCategoryTypeContract.Value;
        public ISellerContract sellerContract => _sellerContract.Value;
        public IBrandContract brandContract => _brandContract.Value;
        public IColorContract colorContract => _colorContract.Value;
        public ISizeContract sizeContract => _sizeContract.Value;
        public IProductContract productContract => _productContract.Value;
        public IDiscountContract discountContract => _discountContract.Value;
        public IGiftCardContract giftCardContract => _giftCardContract.Value;
        public INotificationContract notificationContract => _notificationContract.Value;
        public IOrderContract orderContract => _orderContract.Value;
        public IPaymentContract paymentContract => _paymentContract.Value;
        public IReturnRefundContract returnRefundContract => _returnRefundContract.Value;
        public IShippingContract shippingContract => _shippingContract.Value;
        public IBannerContract bannerContract => _bannerContract.Value;
        public IDashboardContract dashboardContract => _dashboardContract.Value;
        public IFilterContract filterContract => _filterContract.Value;
        public ICustomerManagementContract customerManagementContract => _customerManagementContract.Value;
        public IAddressContract addressContract => _addressContract.Value;
        public IShippingMethodContract shippingMethodContract => _shippingMethodContract.Value;
        public ICartContract cartContract => _cartContract.Value;
        public IIngredientContract ingredientContract => _ingredientContract.Value;
        public IGeographyContract geographyContract => _geographyContract.Value;

        public IConcernContract concernContract => _concernContract.Value;
    }
}
