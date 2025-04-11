
namespace ViewModel
{
    public class AddProductInCartViewModel
    {
        public Guid userId { get; set; }
        public Guid productId { get; set; }
        public int quantity { get; set; }
        public Guid createdBy { get; set; }
    }
    public class UpdateQuantityInCartViewModel
    {
        public Guid userId { get; set; }
        public Guid productId { get; set; }
        public int quantity { get; set; }
        public Guid updatedBy { get; set; }
    }
    public class RemoveProductInCartViewModel
    {
        public Guid userId { get; set; }
        public Guid productId { get; set; }
    }
}
