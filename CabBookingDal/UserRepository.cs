using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CabBookingEntity;

namespace CabBookingDal
{
    public class UserRepository : IUser, IAdmin
    {

        //gets the roles of the users except admin for signup
        public IEnumerable<Role> GetRoles()
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.Roles.Where(id => id.RoleName != "Admin").ToList();
            }
        }

        //gets the roles of the users including admin for signup
        public IEnumerable<Role> GetAllRoles()
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.Roles.ToList();
            }
        }

        //adds the signup values to the properties
        public void SignUp(User user)
        {
            using (UserContext userContext = new UserContext())
            {
                userContext.UserEntities.Add(user);
                userContext.SaveChanges();
            }
        }

        //gets the cab details and driver datails 
        public void DriverRegistration(Cab cab)
        {
            using (UserContext userContext = new UserContext())
            {
                userContext.CabEntities.Add(cab);
                userContext.SaveChanges();
            }
        }

        //gets the corresponding user 
        public User GetUserById(int userId)
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.UserEntities.Single(id => id.UserId == userId);
            }
        }

        //gets the user's generated id
        public int GetUserId(string mail)
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.UserEntities.Where(m => m.MailId == mail).FirstOrDefault().UserId;
            }
        }

        //returns the all cab types
        public IEnumerable<CabType> GetCabType()
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.CabTypes.ToList();
            }
        }

        //checks the user login
        public User CheckLogin(User user)
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.UserEntities.Include("Role").Where(data => data.MailId == user.MailId && data.Password == user.Password).SingleOrDefault();
            }
        }

        //Admin
        //returns all customer details
        public IEnumerable<User> GetCustomerDetails()
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.UserEntities.Where(role => role.Role.RoleName == "Customer").ToList();
            }
        }

        //returns all driver details
        public IEnumerable<User> GetDriverDetails()
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.UserEntities.Where(role => role.Role.RoleName == "Driver").Include("Cab").ToList();
            }
        }

        //deletes the user with corresponding id
        public void DeleteUser(int userId)
        {
            using (UserContext userContext = new UserContext())
            {
                User user = userContext.UserEntities.Single(id => id.UserId == userId);
                userContext.UserEntities.Remove(user);
                userContext.SaveChanges();
            }
        }
    }
}
