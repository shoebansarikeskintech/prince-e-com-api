

using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class AddSizeViewModel
    {
        [Required]
        public string? name { get; set; }
        [Required]
        public string? code { get; set; }
        [Required]
        public Guid createdBy { get; set; }
    }
    public class DeleteSizeViewModel
    {
        [Required]
        public Guid sizeId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
    public class UpdateSizeViewModel
    {
        [Required]
        public Guid sizeId { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? code { get; set; }
        [Required]
        public bool active { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
}
