using CabBookingDal;
using CabBookingEntity;
using System.Collections.Generic;

namespace CabBookingBL
{
    public class AdminBL
    {
        UserRepository userRepository = new UserRepository();
        public void DeleteUser(int id)
        {
            userRepository.DeleteUser(id);
        }

        public static IEnumerable<User> GetCustomerDetails()
        {
           return UserRepository.GetCustomerDetails();
        }

        public static IEnumerable<User> GetDriverDetails()
        {
            return UserRepository.GetDriverDetails();
        }
    }
}
