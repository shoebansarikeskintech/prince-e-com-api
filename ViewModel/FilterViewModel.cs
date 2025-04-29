using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class FilterViewModel
    {
        public string? categoryName { get; set; }
        public string? subCategoryName { get; set; }
        public string? subcategoryTypeName { get; set; }
        public string? productName { get; set; }
        public string? sellerName { get; set; }
        public string? stepsName { get; set; }
        public string? typeofProductName { get; set; }
        public string? sizeName { get; set; }
        public string? concernName { get; set; }
        public string? ingredientName { get; set; }
    }
    public class FilterViewModelNew
    {
        public string? categoryIds { get; set; }
        public string? subCategoryIds { get; set; }
        public string? subcategoryTypeIds { get; set; }
        public string? productIds { get; set; }
        public string? sellerIds { get; set; }
        public string? stepsIds { get; set; }
        public string? typeofProductIds { get; set; }
        public string? sizeIds { get; set; }
        public string? concernIds { get; set; }
        public string? ingredientIds { get; set; }
    }

    public class AddSkinInsightProductViewModel
    {
        public Guid? productId { get; set; }
        public string? Age { get; set; }
        public string? Gender { get; set; }
        public string? Skintype { get; set; }
        public string? SkinSensitive { get; set; }
        public Guid createdBy { get; set; }    
    }
    public class UpdateSkinInsightProductViewModel
    {
        public Guid? skininsightproductId { get; set; }
        public Guid? productId { get; set; }
        public string? Age { get; set; }
        public string? Gender { get; set; }
        public string? Skintype { get; set; }
        public string? SkinSensitive { get; set; }
        public Guid updatedBy { get; set; }
        public bool active { get; set; }
    }
    public class DeleteSkinInsightProductViewModel
    {
        public Guid skininsightproductId { get; set; }
        public Guid updatedBy { get; set; }
    }
}
