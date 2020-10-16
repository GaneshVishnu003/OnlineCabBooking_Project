using System.ComponentModel.DataAnnotations;

namespace OnlineCabBooking.Models
{
    public class AreaVM
    {
        public int AreaId { get; set; }
        public int LocationId { get; set; }

        [Required]
        [StringLength(30)]
        public string AreaName { get; set; }
    }
}