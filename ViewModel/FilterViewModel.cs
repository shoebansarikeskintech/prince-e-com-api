using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class FilterViewModel
    {
        public string? categoryId { get; set; }
        public string? subCategoryId { get; set; }
        public string? subcategoryTypeId { get; set; }       
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

    public class AddSimilarProductViewModel
    {
        public Guid productId { get; set; }
        public Guid subProductId { get; set; }
        public bool active { get; set; }
        public Guid createdBy { get; set; }
    }
    public class UpdateSimilarProductViewModel
    {
        public Guid SimilarProductId { get; set; }
        public Guid productId { get; set; }
        public Guid subProductId { get; set; }
        public Guid updatedBy { get; set; }
        public bool active { get; set; }

    }
    public class DeleteSimilarProductViewModel
    {

        public Guid SimilarProductId { get; set; }
        public Guid updatedBy { get; set; }
    }
}
