using CabBookingDal;
using CabBookingEntity;
using System.Collections.Generic;

namespace CabBookingBL
{
    public class AdminBL : IAdmin
    {
        IAdmin userRepository = new UserRepository();           //repository instance for admin interface object
        

        public IEnumerable<User> GetCustomerDetails()        //gets the list of the customers
        {
           return userRepository.GetCustomerDetails();
        }

        public IEnumerable<User> GetDriverDetails()              //gets the list of the drivers
        {
            return userRepository.GetDriverDetails();
        }

        public void DeleteUser(int id)              //delete the user using the user id
        {
            userRepository.DeleteUser(id);
        }
    }
}
