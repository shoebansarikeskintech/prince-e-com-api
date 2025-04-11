
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class AddBannerViewModel
    { 
        public Guid categoryId { get; set; }
        public Guid subCategoryId { get; set; }
        public Guid subCategoryTypeId { get; set; }
        [Required]
        public IFormFile? image { get; set; }
        [Required]
        public string? title { get; set; }
        [Required]
        public string? subTitle { get; set; }
        [Required]
        public Guid createdBy { get; set; }
    }
    public class DeleteBannerViewModel
    {
        [Required]
        public Guid bannerId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
    public class UpdateBannerViewModel
    {
        [Required]
        public Guid bannerId { get; set; }
        //[Required]
        //public Guid categoryId { get; set; }
        [Required]
        public Guid subCategoryId { get; set; }
        //[Required]
        //public Guid subCategoryTypeId { get; set; }

        public IFormFile? image { get; set; }
        [Required]
        public string? title { get; set; }
        [Required]
        public string? subTitle { get; set; }
        [Required]
        public bool active { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
}
