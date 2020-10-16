using System.ComponentModel.DataAnnotations;

namespace OnlineCabBooking.Models
{
    public class LocationVM
    {
        public int LocationId { get; set; }

        [Required]
        [StringLength(30)]
        public string CityName { get; set; }

        [Required]
        [StringLength(30)]
        public string DistrictName  { get; set; }
    }
}