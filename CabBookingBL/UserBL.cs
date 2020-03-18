using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabBookingEntity;
using CabBookingDal;
using System.Collections;

namespace CabBookingBL
{
    public class UserBL
    {
        UserRepository userRepository = new UserRepository();
        public static IEnumerable<Role> GetRoles()
        {
            return UserRepository.GetRoles();
        }
        public void SignUp(User user)
        {
            userRepository.SignUp(user);
        }

        public User GetUserById(int userId)
        {
            return userRepository.GetUserById(userId);
        }

        public static int GetUserId(string mailId)
        {
            return UserRepository.GetUserId(mailId);
        }

        public static IEnumerable GetCabType()
        {
            return UserRepository.GetCabType();
        }

        public void SignUpNext(Cab cab)
        {
            userRepository.SignUpNext(cab);
        }

        public static User CheckLogin(User user)
        {
            return UserRepository.CheckLogin(user);
        }
    }
}
