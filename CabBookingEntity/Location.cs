using System.ComponentModel.DataAnnotations;

namespace CabBookingEntity
{
    public class Location
    {
        public int LocationId { get; set; }
        [Required]
        
        public string CityName { get; set; }
        [Required]
        public string DistrictName { get; set; }
    }
}
