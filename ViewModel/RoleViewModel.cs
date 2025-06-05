using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class AddAppRoleViewModel
    {
        [Required]
        public string? roleName { get; set; }
        [Required]
        public Guid createdBy { get; set; }
    }
    public class DeleteAppRoleViewModel
    {
        [Required]
        public Guid appRoleId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }

    public class UpdateAppRoleViewModel
    {
        public Guid appRoleId { get; set; }
        [Required]
        public string? roleName { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }

    //New Ticket

    public class AddTicketViewModel
    {
        public string? ticketType { get; set; }
        public string? subject { get; set; }
        public string? message { get; set; }
        public string? appUserId { get; set; }

        public IFormFile? image { get; set; } 
        public Guid createdBy { get; set; }
    }

    public class DeleteTicketViewModel
    {
        [Required]
        public Guid ticketId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }

    public class UpdateTicketViewModel
    {
        public Guid ticketId { get; set; }
        public string? ticketType { get; set; }
        public string? subject { get; set; }
        public string? message { get; set; }
        public string? appUserId { get; set; }

        public IFormFile? image { get; set; } 

        public Guid updatedBy { get; set; }
        public bool active { get; set; }
    }


    //New Ticket Reply 

    public class AddTicketReplyViewModel
    {
        public Guid? ticketId { get; set; }
        public string? ticketType { get; set; }
        public string? message { get; set; }
        public string? appUserId { get; set; }

        public IFormFile? image { get; set; } 
        public Guid createdBy { get; set; }
    }

    public class DeleteTicketReplyViewModel
    {
        [Required]
        public Guid ticketReplyId { get; set; }
        [Required]
        public Guid updatedBy { get; set; }
    }

    public class UpdateTicketReplyViewModel
    {
        public Guid? ticketReplyId { get; set; }
        public Guid? ticketId { get; set; }
        public string? ticketType { get; set; }
        public string? message { get; set; }
        public string? appUserId { get; set; }

        public IFormFile? image { get; set; }   

        public bool active { get; set; }
        public Guid updatedBy { get; set; }
    }

}
