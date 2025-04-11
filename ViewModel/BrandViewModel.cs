using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class AddBrandViewModel
    {
        [Required]
        public string? name { get; set; }
        [Required]
        public string? description { get; set; }
        [Required]
        public Guid createdBy { get; set; }
    }
    public class DeleteBrandViewModel
    {
        [Required]
        public Guid brandId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
    public class UpdateBrandViewModel
    {
        [Required]
        public Guid brandId { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public bool active { get; set; }
        [Required]
        public string? description { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
}
