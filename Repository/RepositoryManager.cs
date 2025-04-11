using RepositoryContract;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DapperContext _dapperContext;
        private readonly Lazy<IAuthenticationRepository> _authenticationRepository;
        private readonly Lazy<IAppRoleRepository> _appRoleRepository;
        private readonly Lazy<IMenuRepository> _menuRepository;
        private readonly Lazy<ISubMenuRepository> _subMenuRepository;
        private readonly Lazy<IRoleMenuRepository> _roleMenuRepository;
        private readonly Lazy<IAdminAuthenticationRepository> _adminAuthenticationRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<ISubCategoryRepository> _subCategoryRepository;
        private readonly Lazy<ISubCategoryTypeRepository> _subCategoryTypeRepository;
        private readonly Lazy<ISellerRepository> _sellerRepository;
        private readonly Lazy<IBrandRepository> _brandRepository;
        private readonly Lazy<IColorRepository> _colorRepository;
        private readonly Lazy<ISizeRepository> _sizeRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IDiscountRepository> _discountRepository;
        private readonly Lazy<IGiftCardRepository> _giftCardRepository;
        private readonly Lazy<INotificationRepository> _notificationRepository;
        private readonly Lazy<IOrderRepository> _orderRepository;
        private readonly Lazy<IPaymentRepository> _paymentRepository;
        private readonly Lazy<IReturnRefundRepository> _returnRefundRepository;
        private readonly Lazy<IShippingRepository> _shippingRepository;
        private readonly Lazy<IBannerRepository> _bannerRepository;
        private readonly Lazy<IDashboardRepository> _dashboardRepository;
        private readonly Lazy<IFilterRepository> _filterRepository;
        private readonly Lazy<ICustomerManagementRepository> _customerManagementRepository;
        private readonly Lazy<IAddressRepository> _addressRepository;
        private readonly Lazy<ICartRepository> _cartRepository;
        private readonly Lazy<IShippingMethodRepository> _shippingMethodRepository;
        private readonly Lazy<IIngredientRepository> _ingredientRepository;
        private readonly Lazy<IGeographyRepository> _geographyRepository;
        private readonly Lazy<IConcernReposotory> _concernReposotory;


        public RepositoryManager(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
            _authenticationRepository = new Lazy<IAuthenticationRepository>(() => new AuthenticationRepository(_dapperContext));
            _appRoleRepository = new Lazy<IAppRoleRepository>(() => new AppRoleRepository(_dapperContext));
            _menuRepository = new Lazy<IMenuRepository>(() => new MenuRepository(_dapperContext));
            _subMenuRepository = new Lazy<ISubMenuRepository>(() => new SubMenuRepository(_dapperContext));
            _roleMenuRepository = new Lazy<IRoleMenuRepository>(() => new RoleMenuRepository(_dapperContext));
            _adminAuthenticationRepository = new Lazy<IAdminAuthenticationRepository>(() => new AdminAuthenticationRepository(_dapperContext));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_dapperContext));
            _subCategoryRepository = new Lazy<ISubCategoryRepository>(() => new SubCategoryRepository(_dapperContext));
            _subCategoryTypeRepository = new Lazy<ISubCategoryTypeRepository>(() => new SubCategoryTypeRepository(_dapperContext));
            _sellerRepository = new Lazy<ISellerRepository>(() => new SellerRepository(_dapperContext));
            _brandRepository = new Lazy<IBrandRepository>(() => new BrandRepository(_dapperContext));
            _colorRepository = new Lazy<IColorRepository>(() => new ColorRepository(_dapperContext));
            _sizeRepository = new Lazy<ISizeRepository>(() => new SizeRepository(_dapperContext));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_dapperContext));
            _discountRepository = new Lazy<IDiscountRepository>(() => new DiscountRepository(_dapperContext));
            _giftCardRepository = new Lazy<IGiftCardRepository>(() => new GiftCardRepository(_dapperContext));
            _notificationRepository = new Lazy<INotificationRepository>(() => new NotificationRepository(_dapperContext));
            _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(_dapperContext));
            _paymentRepository = new Lazy<IPaymentRepository>(() => new PaymentRepository(_dapperContext));
            _returnRefundRepository = new Lazy<IReturnRefundRepository>(() => new ReturnRefundRepository(_dapperContext));
            _shippingRepository = new Lazy<IShippingRepository>(() => new ShippingRepository(_dapperContext));
            _bannerRepository = new Lazy<IBannerRepository>(() => new BannerRepository(_dapperContext));
            _dashboardRepository = new Lazy<IDashboardRepository>(() => new DashboardRepository(_dapperContext));
            _filterRepository = new Lazy<IFilterRepository>(() => new FilterRepository(_dapperContext));
            _customerManagementRepository = new Lazy<ICustomerManagementRepository>(() => new CustomerManagementRepository(_dapperContext));
            _addressRepository = new Lazy<IAddressRepository>(() => new AddressRepository(_dapperContext));
            _cartRepository = new Lazy<ICartRepository>(() => new CartRepository(_dapperContext));
            _shippingMethodRepository = new Lazy<IShippingMethodRepository>(() => new ShippingMethodRepository(_dapperContext));
            _ingredientRepository = new Lazy<IIngredientRepository>(() => new IngredientRepository(_dapperContext));
            _geographyRepository = new Lazy<IGeographyRepository>(() => new GeographyRepository(_dapperContext));
            _concernReposotory = new Lazy<IConcernReposotory>(() => new ConcernRepository(_dapperContext));
        }
        public IAuthenticationRepository authenticationRepository => _authenticationRepository.Value;
        public IAppRoleRepository appRoleRepository => _appRoleRepository.Value;
        public IMenuRepository menuRepository => _menuRepository.Value;
        public ISubMenuRepository subMenuRepository => _subMenuRepository.Value;
        public IRoleMenuRepository roleMenuRepository => _roleMenuRepository.Value;
        public IAdminAuthenticationRepository adminAuthenticationRepository => _adminAuthenticationRepository.Value;
        public ICategoryRepository categoryRepository => _categoryRepository.Value;
        public ISubCategoryRepository subCategoryRepository => _subCategoryRepository.Value;
        public ISubCategoryTypeRepository subCategoryTypeRepository => _subCategoryTypeRepository.Value;
        public ISellerRepository sellerRepository => _sellerRepository.Value;
        public IBrandRepository brandRepository => _brandRepository.Value;
        public IColorRepository colorRepository => _colorRepository.Value;
        public ISizeRepository sizeRepository => _sizeRepository.Value;
        public IProductRepository productRepository => _productRepository.Value;
        public IDiscountRepository discountRepository => _discountRepository.Value;
        public IGiftCardRepository giftCardRepository => _giftCardRepository.Value;
        public INotificationRepository notificationRepository => _notificationRepository.Value;
        public IOrderRepository orderRepository => _orderRepository.Value;
        public IPaymentRepository paymentRepository => _paymentRepository.Value;
        public IReturnRefundRepository returnRefundRepository => _returnRefundRepository.Value;
        public IShippingRepository shippingRepository => _shippingRepository.Value;
        public IBannerRepository bannerRepository => _bannerRepository.Value;
        public IDashboardRepository dashboardRepository => _dashboardRepository.Value;
        public IFilterRepository filterRepository => _filterRepository.Value;
        public ICustomerManagementRepository customerManagementRepository => _customerManagementRepository.Value;
        public IAddressRepository addressRepository => _addressRepository.Value;
        public ICartRepository cartRepository => _cartRepository.Value;
        public IShippingMethodRepository shippingMethodRepository => _shippingMethodRepository.Value;
        public IIngredientRepository ingredientRepository => _ingredientRepository.Value;
        public IGeographyRepository geographyRepository => _geographyRepository.Value;
        public IConcernReposotory concernReposotory => _concernReposotory.Value;
    }
}
