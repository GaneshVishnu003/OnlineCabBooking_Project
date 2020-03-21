using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CabBookingEntity;

namespace CabBookingDal
{
    public class UserRepository : IUser,IAdmin
    {
        public IEnumerable<Role> GetRoles()             //gets the roles of the users
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.Role.Where(id => id.RoleID < 3).ToList();
            }
        }
         
        public void SignUp(User user)       //adds the signup values to the properties
        {
            using (UserContext userContext = new UserContext())
            {
                    userContext.UserEntity.Add(user);
                    userContext.SaveChanges();
            }
        } 
        public void SignUpNext(Cab cab)         //gets the cab details and driver datails 
        {
            using (UserContext userContext = new UserContext())
            {
                cab.RequestStatus = "Requested";
                userContext.CabEntity.Add(cab);
                userContext.SaveChanges();
            }
        }

        public User GetUserById(int userId)             //gets the corresponding user 
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.UserEntity.Single(id => id.UserId == userId);
            }
        }

        public int GetUserId(string mail)           //gets the user's generated id
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.UserEntity.Where(m => m.MailId == mail).FirstOrDefault().UserId;
            }
        }

        public IEnumerable<CabType> GetCabType()            //returns the cab types
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.CabType.ToList();
            }
        }
        
        public User CheckLogin(User user)           //checks the user login
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.UserEntity.Where(data => data.MailId == user.MailId && data.Password == user.Password).SingleOrDefault();
            }
        }

        //Admin
        public IEnumerable<User> GetCustomerDetails()           //returns all customer details
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.UserEntity.Where(role => role.RoleId == 1).ToList();
            }
        }
        public IEnumerable<User> GetDriverDetails()         //returns all driver details
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.UserEntity.Where(role => role.RoleId == 2).Include("Cab").ToList();
            }
        }
        
        public void DeleteUser(int userId)              //deletes the user with corresponding id
        {
            using (UserContext userContext = new UserContext())
            {
                User user = userContext.UserEntity.Single(id => id.UserId == userId);
                userContext.UserEntity.Remove(user);
                userContext.SaveChanges();
            }
        }
    }
}
