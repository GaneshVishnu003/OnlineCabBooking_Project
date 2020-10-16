using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CabBookingEntity
{
    public class Location
    {
        public int LocationId { get; set; }
        [Required]
        [StringLength(20)]
        [Index("OfficialIds", 1)]
        public string CityName { get; set; }
        [Required]
        [StringLength(30)]
        public string DistrictName { get; set; }

    }
}
