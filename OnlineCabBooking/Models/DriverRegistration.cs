using System.ComponentModel.DataAnnotations;

namespace OnlineCabBooking.Models
{
    public class DriverRegistration
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(10)]
        public string CabNumber { get; set; }
        public int TypeId { get; set; }

        [Required]
        [StringLength(15)]
        public string LicenceNumber { get; set; }
        public string RequestStatus { get; set; }
    }
}