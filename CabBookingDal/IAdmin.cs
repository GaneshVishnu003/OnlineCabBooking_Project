using CabBookingEntity;
using System.Collections.Generic;
namespace CabBookingDal
{
    public interface IAdmin         //admin interface
    {
        //methods used by AdminBL and AdminDal
        IEnumerable<User> GetCustomerDetails();
        IEnumerable<User> GetDriverDetails();
        void DeleteUser(int id);
    }
}
