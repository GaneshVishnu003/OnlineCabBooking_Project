using System.ComponentModel.DataAnnotations;
namespace OnlineCabBooking.Models
{
    public class SignInVM
    {
        [Required]
        [EmailAddress]
        public string MailId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}