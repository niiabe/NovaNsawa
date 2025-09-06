using System.ComponentModel.DataAnnotations;

namespace NovaNsawa.Models
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Name must be between 4 and 100 characters")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Subject is required")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "Subject must be between 4 and 200 characters")]
        public string Subject { get; set; } = "";

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Please enter a valid phone number")]
        [RegularExpression(@"^[\+]?[0-9\s\-\(\)]+$", ErrorMessage = "Please enter a valid phone number")]
        public string Phone { get; set; } = "";

        [Required(ErrorMessage = "Message is required")]
        [StringLength(1000, ErrorMessage = "Message cannot exceed 1000 characters")]
        public string Message { get; set; } = "";
    }
}