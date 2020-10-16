using System.ComponentModel.DataAnnotations;

namespace OnlineCabBooking.Models
{
    public class SignUpVM
    {
        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(26)]
        public string LastName { get; set; }
        public int RoleId { get; set; }
        
        [Required]
        [DataType(DataType.PhoneNumber)]
        public long MobileNumber { get; set; }
        [Required]
        [EmailAddress]
        public string MailId { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password and Confirm Password must be same")]
        public string ConfirmPassword { get; set; }
    }
}