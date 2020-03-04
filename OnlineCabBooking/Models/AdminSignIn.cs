using System.ComponentModel.DataAnnotations;

namespace OnlineCabBooking.Models
{
    public class AdminSignIn
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}