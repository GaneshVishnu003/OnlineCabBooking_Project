using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        public string DistrictName { get; set; }
    }
}