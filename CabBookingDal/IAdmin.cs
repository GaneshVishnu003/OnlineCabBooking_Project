﻿using CabBookingEntity;
using System.Collections.Generic;
namespace CabBookingDal
{
    public interface IAdmin         //admin interface
    {
        IEnumerable<User> GetCustomerDetails();
        IEnumerable<User> GetDriverDetails();
        void DeleteUser(int id);
        IEnumerable<Role> GetAllRoles();
    }
}
