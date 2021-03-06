﻿using CabBookingEntity;
using System.Collections.Generic;

namespace CabBookingDal
{
    public interface IUser      //user interface
    {
        IEnumerable<Role> GetRoles();
        void SignUp(User user);
        void DriverRegistration(Cab cab);
        User GetUserById(int userId);
        int GetUserId(string mail);
        IEnumerable<CabType> GetCabType();
        User CheckLogin(User user);
    }
}
