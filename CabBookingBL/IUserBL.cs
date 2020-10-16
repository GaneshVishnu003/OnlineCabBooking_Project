using CabBookingEntity;
using System.Collections.Generic;

namespace CabBookingBL
{
    public interface IUserBL
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
