#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Judah_Kahler_Portfolio.Models;

public class ContactForm
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Subject is required.")]
    public string Subject { get; set; }

    [Required(ErrorMessage = "Message is required.")]
    public string Message { get; set; } 
}