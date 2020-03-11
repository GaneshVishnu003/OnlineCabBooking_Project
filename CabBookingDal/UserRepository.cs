using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CabBookingEntity;

namespace CabBookingDal
{
    public class UserRepository
    {
        UserContext userContext = new UserContext();
        // public static List<User> UserList = new List<User>();
        public static IEnumerable<Role> GetRoles()
        {
            UserContext userContext = new UserContext();
            return userContext.Role.Where(id => id.RoleID < 3).ToList();
        }
        public static int GetUserId(string mail)
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.UserEntity.Where(m => m.MailId == mail).FirstOrDefault().UserId;
            }
        }

        public static IEnumerable<CabType> GetCabType()
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.CabType.ToList();
            }
        }
        public void SignUp(User user)
        {
            //UserContext userContext = new UserContext();
            userContext.UserEntity.Add(user);
            userContext.SaveChanges();
        }
        public void SignUpNext(Cab cab)
        {
            userContext.CabEntity.Add(cab);
            userContext.SaveChanges();
        }
        public static User CheckLogin(User user)
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.UserEntity.Where(data => data.MailId == user.MailId && data.Password == user.Password).SingleOrDefault();
            }
        }
        public static IEnumerable<CabBookingEntity.User> GetCustomerDetails()
        {
            UserContext userContext = new UserContext();
            return userContext.UserEntity.Where(role=>role.RoleId==1).ToList();
        }
        public static IEnumerable<CabBookingEntity.User> GetDriverDetails()
        {
            UserContext userContext = new UserContext();
            return userContext.UserEntity.Where(role => role.RoleId == 2).Include("Cab").ToList();
        }
        public User GetUserById(int userId)
        {
            UserContext userContext = new UserContext();
            return userContext.UserEntity.Single(id => id.UserId == userId);
        }
        public void DeleteUser(int userId)
        {
            User user = userContext.UserEntity.Single(id => id.UserId == userId);
            userContext.UserEntity.Remove(user);
            userContext.SaveChanges();
        }
        
    }
}
