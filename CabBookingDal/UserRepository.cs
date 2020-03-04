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
        public void SignUp(User user)
        {
            //UserContext userContext = new UserContext();
            userContext.UserEntity.Add(user);
            userContext.SaveChanges();
        }
        public static int CheckLogin(string mailId, string password)
        {
           UserContext userContext = new UserContext();
            foreach (var result in userContext.UserEntity)
            {
                if (result.MailId == mailId)
                {
                    if (result.Password == password)
                    {
                        return result.RoleId;
                    }
                    else
                        return 0;
                }
            }
            return 0;
        }
        public static IEnumerable<CabBookingEntity.User> GetUserDetails()
        {
            UserContext userContext = new UserContext();
            return userContext.UserEntity.ToList();
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
        //public void UpdateChanges(CabBookingEntity.User user)
        //{
        //    userContext.Entry(user).State = EntityState.Modified;
        //    userContext.SaveChanges();
        //}
    }
}
