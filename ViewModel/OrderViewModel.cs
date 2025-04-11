
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class AddOrderWithDetailsViewModel
    {
        public Guid userId { get; set; }
        public Guid addressId { get; set; }
        public Guid paymentId { get; set; }
        public DateTime shippedDate { get; set; }
        public decimal price { get; set; }
        public decimal discountPrice { get; set; }
        public decimal deliveryCharge { get; set; }
        public decimal gstCharge { get; set; }
        public decimal extraCharge { get; set; }
        public decimal totalAmount { get; set; }
        public string? paymentMethod { get; set; }
        public string? transactionId { get; set; }
        public string? trackingNo { get; set; }
        public string? note { get; set; }
        public string? status { get; set; }
        public Guid? createdBy { get; set; }
        public DateTime? cancelOrderDate { get; set; }
        public string? orderNo { get; set; }
        public string? OrderDetailsXML { get; set; }
    }
}
