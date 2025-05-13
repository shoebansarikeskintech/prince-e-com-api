
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class AddProductViewModel
    {
        [Required]
        public Guid categoryId { get; set; }
        [Required]
        public Guid subCategoryId { get; set; }
        [Required]
        public Guid subCategoryTypeId { get; set; }
        [Required]
        public Guid sellerId { get; set; }

        [Required]
        public Guid sizeId { get; set; }
        [Required]
        public string? title { get; set; }
        [Required]
        public string? subTitle { get; set; }
        [Required]
        public int rating { get; set; }
        [Required]
        public int noOfRating { get; set; }
        [Required]
        public int stock { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public decimal discountPrice { get; set; }
        [Required]
        public string? description { get; set; }
        [Required]
        public Guid createdBy { get; set; }

        [Required]
        public Guid ConcernId { get; set; }
        [Required]
        public Guid IngredientId { get; set; }

        [Required]
        public Guid TypeofProductId { get; set; }

        [Required]
        public Guid stepsId { get; set; }
        public bool isNewArrial { get; set; }
        public bool isBestSeller { get; set; }
        public bool isRecommended { get; set; }

        public string? categoryName { get; set; }
        public string? subCategoryName { get; set; }
        public string? subCategoryTypeName { get; set; }
        public string? stepsName { get; set; }
        public string? typeOfProductName { get; set; }
        public string? sizename { get; set; }
        public string? concernname { get; set; }
        public string? ingredientName { get; set; }
        public string? productname { get; set; }      
        public string? MRP { get; set; }      

    }
    public class UpdateProductViewModel
    {
        [Required]
        public Guid productId { get; set; }
        public Guid categoryId { get; set; }
        public Guid subCategoryId { get; set; }
        public Guid subCategoryTypeId { get; set; }
        public Guid sellerId { get; set; }
        public Guid brandId { get; set; }
        [Required]
        public Guid colorId { get; set; }
        [Required]
        public Guid sizeId { get; set; }
        [Required]
        public string? title { get; set; }
        [Required]
        public string? subTitle { get; set; }
        [Required]
        public int rating { get; set; }
        [Required]
        public int noOfRating { get; set; }
        [Required]
        public int stock { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public decimal discountPrice { get; set; }
        [Required]
        public string? description { get; set; }
        [Required]
        public bool active { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
        [Required]
        public Guid ConcernId { get; set; }
        [Required]
        public Guid IngredientId { get; set; }

        [Required]
        public Guid TypeofProductId { get; set; }

        [Required]
        public Guid StepsId { get; set; }
        public bool isNewArrial { get; set; }
        public bool isBestSeller { get; set; }
        public bool isRecommended { get; set; }

        public string? categoryName { get; set; }
        public string? subCategoryName { get; set; }
        public string? subCategoryTypeName { get; set; }
        public string? stepsName { get; set; }
        public string? typeOfProductName { get; set; }
        public string? sizename { get; set; }
        public string? concernname { get; set; }
        public string? ingredientName { get; set; }
        public string? productname { get; set; }
        public string? MRP { get; set; }
    }
    public class DeleteProductViewModel
    {
        [Required]
        public Guid productId { get; set; }
        [Required]
        public Guid categoryId { get; set; }
        [Required]
        public Guid subCategoryId { get; set; }
        [Required]
        public Guid subCategoryTypeId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }

    }
    public class AddProductImageViewModel
    {
        [Required]
        public Guid productId { get; set; }
        public string? title { get; set; }
        [Required]
        public List<IFormFile>? image { get; set; }
        [Required]
        public Guid createdBy { get; set; }
    }
    public class UpdateProductImageViewModel
    {
        [Required]
        public Guid productImageId { get; set; }
        [Required]
        public Guid productId { get; set; }
        public string? title { get; set; }
        [Required]
        public List<IFormFile>? image { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }
    public class DeleteProductImageViewModel
    {
        [Required]
        public Guid productImageId { get; set; }
        [Required]
        public Guid productId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }

    public class AddStepsViewModel
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public Guid createdBy { get; set; }
    }
    public class UpdateStepsViewModel
    {
        [Required]
        public Guid stepsId { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public bool active { get; set; }
        public Guid updatedBy { get; set; }
    }

    public class DeleteStepsViewModel
    {
        public Guid stepsId { get; set; }
        public Guid updatedBy { get; set; }
    }

    public class AddTypeOfProductViewModel
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public Guid? createdBy { get; set; }
    }
    public class UpdateTypeOfProductViewModel
    {
        [Required]
        public Guid TypeofProductId { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public bool active { get; set; }
        public Guid? updateddBy { get; set; }
    }

    public class DeleteSTypeOfProductMdoel
    {
        public Guid TypeofProductId { get; set; }
        public Guid updatedBy { get; set; }
    }

    public class SearchCommonDataViewModel
    {     
        public string? categoryName { get; set; }
        public string? subCategoryName { get; set; }
        public string? subCategoryTypeName { get; set; }
        public string? stepsName { get; set; }
        public string? typeOfProductName { get; set; }
        public string? sizename { get; set; }
        public string? concernname { get; set; }
        public string? ingredientName { get; set; }
        public string? productname { get; set; }
    }

    public class getAllProductByIdViewModel
    {     
        public string? id { get; set; }
    }

}
