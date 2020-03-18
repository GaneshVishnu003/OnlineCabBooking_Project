using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CabBookingEntity
{
    public class Area
    {
        [Required]
        public int AreaId { get; set; }
        [Required]
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
        [Required]
        [StringLength(30)]
        [Index("OfficialIds", 1)]
        public string AreaName { get; set; }
    }
}
