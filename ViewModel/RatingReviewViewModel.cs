using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class RatingReviewViewModel
    {

        [Required]
        public Guid productId { get; set; }
        [Required]
        public Guid userId { get; set; }
        [Required]
        public Int64 rating { get; set; }
        [Required]
        public string? title { get; set; }
        [Required]
        public string? description { get; set; }
        public Int64 like { get; set; }
        public Int64 dislike { get; set; }
        [Required]
        public Guid createdBy { get; set; }
    }

    public class UpdateReviewRatingViewModel
    {
        [Required]
        public Guid ratingReviewId { get; set; }
        [Required]
        public Guid productId { get; set; }
        [Required]
        public Guid userId { get; set; }
        [Required]
        public Int64 rating { get; set; }
        [Required]
        public string? title { get; set; }
        [Required]
        public string? description { get; set; }
        public Int64 like { get; set; }
        public Int64 dislike { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }

    public class AddFAQViewModel
    {

        [Required]
        public Guid productId { get; set; }
   
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }     
        [Required]
        public Guid createdBy { get; set; }
    }

    public class UpdateFAQViewModel
    {
        [Required]
        public Guid ProductFaqid { get; set; }
        [Required]
        public Guid productId { get; set; }

        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
     
        [Required]
        public Guid updatedBy { get; set; }
        public bool active { get; set; }
    }
    public class DeleteFAQViewModel
    {
        [Required]
        public Guid ProductFaqid { get; set; }        

        [Required]
        public Guid updatedBy { get; set; }
    }



    public class AddProductSpecificationViewModel
    {

        [Required]
        public Guid productId { get; set; }

        public string? producttype { get; set; }

        public string? netquantity { get; set; }
        public string? shelfLife { get; set; }
        public string? countryOfOrigin { get; set; }
        public string? SKUcode { get; set; }
        public Guid ManufacturedBy { get; set; }
        public string? ConsumerCareAddress { get; set; }       
        [Required]
        public Guid createdBy { get; set; }
    }

    public class UpdateProductSpecificationViewModel
    {
        [Required]
        public Guid ProductSpecificationid { get; set; }
        [Required]
        public Guid productId { get; set; }

        public string? producttype { get; set; }

        public string? netquantity { get; set; }
        public string? shelfLife { get; set; }
        public string? countryOfOrigin { get; set; }
        public string? SKUcode { get; set; }
        public Guid ManufacturedBy { get; set; }
        public string? ConsumerCareAddress { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
        public bool active { get; set; }
    }
    public class DeleteProductSpecificationViewModel
    {
        [Required]
        public Guid ProductSpecificationid { get; set; }

        [Required]
        public Guid updatedBy { get; set; }
    }
}
