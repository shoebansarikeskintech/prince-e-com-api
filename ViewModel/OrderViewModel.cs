
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
        public Guid? createdBy { get; set; }
        public Guid? couponId { get; set; }
        public DateTime? cancelOrderDate { get; set; }
        //public string? orderNo { get; set; }
        public string? OrderDetailsXML { get; set; }
    }
    public class UpdateStausViewModel
    {
        public List<Guid> orderIds { get; set; }   // Multiple order IDs
        public string? status { get; set; }
    }

    //public class UpdateStausViewModel
    //{
    //    public Guid orderId { get; set; }
    //    public string? status { get; set; }
    //}
    public class updateShippedViewModel
    {        
        public string? shippedBy { get; set; }
        public List<Guid> orderIds { get; set; }

    }

    public class updateDelCanRetCompViewModel
    {
        public Guid orderId { get; set; }    
    }

}
