using System.ComponentModel.DataAnnotations;

namespace Judah_Kahler_Portfolio.Models
{
    public class EmailDto
    {
        // public string To { get; set; } = string.Empty;
        // public string From { get; set; } = string.Empty;
        // public string Subject { get; set; } = string.Empty;
        // public string Body { get; set; } = string.Empty;
        
        // Email of the recipient, though not required here. Can be used later if necessary.
        public string To { get; set; } = string.Empty;

        // 'From' email with validation to ensure it's a valid email format and required.
        [Required(ErrorMessage = "Your email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string From { get; set; } = string.Empty;

        // 'Subject' field which is required.
        [Required(ErrorMessage = "Please add a subject.")]
        public string Subject { get; set; } = string.Empty;

        // 'Body' (message content) which is also required.
        [Required(ErrorMessage = "Please add a message.")]
        public string Body { get; set; } = string.Empty;

        // ConfirmEmail field to ensure it matches the 'From' field.
        [Required(ErrorMessage = "Please confirm your email address.")]
        [Compare("From", ErrorMessage = "Your Email and the Confirmation Email do not match.")]
        public string ConfirmEmail { get; set; } = string.Empty;
    }
} 