using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CabBookingEntity
{
    [Table("CabDetails")]
    public class Cab
    {
        [Required]
        public int CabId { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }
        [Required]
        [Index("OfficialIds", 1)]
        [StringLength(10)]
        public string CabNumber { get; set; }
        [Required]
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public CabType Type { get; set; }
        [Required]
        [Index("OfficialIds", 2)]
        [StringLength(15)]
        public string LicenceNumber { get; set; }
    }
    public class CabType
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}
