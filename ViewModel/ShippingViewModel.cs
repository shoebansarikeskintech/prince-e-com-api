
using System.ComponentModel.DataAnnotations;
namespace ViewModel
{
    public class AddShippingViewModel
    {
        [Required]
        public Guid orderId { get; set; }
        [Required]
        public string? trackingNo { get; set; }
        public string? carrier { get; set; }
        [Required]
        public DateTime? estimateDelivery { get; set; }
        [Required]
        public string? status { get; set; }
        [Required]
        public Guid createdBy { get; set; }
    }
    public class UpdateShippingViewModel
    {
        [Required]
        public Guid shippingId { get; set; }
        [Required]
        public Guid orderId { get; set; }
        [Required]
        public string? trackingNo { get; set; }
        [Required]
        public string? carrier { get; set; }
        [Required]
        public DateTime? estimateDelivery { get; set; }
        [Required]
        public string? status { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
    public class DeleteShippingViewModel
    {
        [Required]
        public Guid shippingId { get; set; }
        [Required]
        public Guid orderId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }

    public class AddShippingMethodViewModel
    {
        [Required]
        public string? name { get; set; }
        [Required]
        public string? courier { get; set; }
        [Required]
        public string? shippingZone { get; set; }
        [Required]
        public string? baseCost { get; set; }
        [Required]
        public string? costPerKg { get; set; }
        [Required]
        public string? maxWeightLimit { get; set; }
        [Required]
        public string? minOrderValue { get; set; }
        [Required]
        public string? trackingURL { get; set; }
        [Required]
        public Guid? createdBy { get; set; }
    }
    public class UpdateShippingMethodViewModel
    {
        [Required]
        public Guid shippingMethodId { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? courier { get; set; }
        [Required]
        public string? shippingZone { get; set; }
        [Required]
        public string? baseCost { get; set; }
        [Required]
        public string? costPerKg { get; set; }
        [Required]
        public string? maxWeightLimit { get; set; }
        [Required]
        public string? minOrderValue { get; set; }
        [Required]
        public string? trackingURL { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
        public bool active { get; set; }

    }
    public class DeleteShippingMethodViewModel
    {
        [Required]
        public Guid shippingMethodId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }

    public class AddPinCodeShippingViewModel
    {
        [Required]
        public int pincode { get; set; }
        [Required]
        public Guid? shippingMethodId { get; set; }

        [Required]
        public Guid? createdBy { get; set; }
        public int noOfDays { get; set; }
    }

    public class UpdatePinCodeShippingViewModel
    {
        [Required]
        public Guid pinCodeShippingId { get; set; }

        [Required]
        public int pincode { get; set; }

        [Required]
        public Guid updatedBy { get; set; }
        public bool active { get; set; }
        public int noOfDays { get; set; }

    }
    public class DeletePinCodeShippingViewModel
    {
        [Required]
        public Guid pinCodeShippingId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
   
}

