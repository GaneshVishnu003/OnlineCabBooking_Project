using CabBookingDal;
using CabBookingEntity;
using System.Collections;
using System.Collections.Generic;

namespace CabBookingBL
{
    public class AdminBL : IAdminBL
    {
        IAdmin admin;           
        public AdminBL()
        {
            admin = new UserRepository();          
        }
        //gets the list of the customers
        public IEnumerable<User> GetCustomerDetails()        
        {
           return admin.GetCustomerDetails();
        }

        //gets the list of the drivers
        public IEnumerable<User> GetDriverDetails()              
        {
            return admin.GetDriverDetails();
        }

        //delete the user using the user id
        public void DeleteUser(int id)             
        {
            admin.DeleteUser(id);
        }

        //gets all the roles including admin
        public IEnumerable<Role> GetAllRoles()
        {
            return admin.GetAllRoles();
        }
    }
}
