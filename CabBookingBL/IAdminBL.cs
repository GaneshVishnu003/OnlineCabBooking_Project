using CabBookingEntity;
using System.Collections;
using System.Collections.Generic;

namespace CabBookingBL
{
    public interface IAdminBL
    {
        IEnumerable<User> GetCustomerDetails();
        IEnumerable<User> GetDriverDetails();
        void DeleteUser(int id);
        IEnumerable<Role> GetAllRoles();
    }
}
