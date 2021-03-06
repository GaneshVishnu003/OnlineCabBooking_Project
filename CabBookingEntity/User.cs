﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CabBookingEntity
{
    [Table("Role")]
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
    [Table("User")]
    public class User
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RoleId { get; set; }
        //public int RoleId
        //{
        //    set
        //    {
        //        value = (int)UserRole;
        //    }
        //    get
        //    {
        //        return (int)UserRole;
        //    }
        //}
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(26)]
        public string LastName { get; set; }
        [Required]    
        public long MobileNumber { get; set; }
        [Required]
        [MaxLength(30)]
        public string MailId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        //[Required]
        //[NotMapped]
       
        public ICollection<Cab> Cab { get; set; }           //binding
    }

    public enum UserRoles
    {
        Customer = 1,
        Driver,
        Admin
    }
}