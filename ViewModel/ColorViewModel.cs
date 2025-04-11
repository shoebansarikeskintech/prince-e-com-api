using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class AddColorViewModel
    {
        [Required]
        public string? name { get; set; }
        [Required]
        public Guid createdBy { get; set; }
    }
    public class DeleteColorViewModel
    {
        [Required]
        public Guid colorId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
    public class UpdateColorViewModel
    {
        [Required]
        public Guid colorId { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public bool active { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
}
