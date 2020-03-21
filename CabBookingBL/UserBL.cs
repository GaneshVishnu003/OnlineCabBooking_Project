using System.Collections.Generic;
using CabBookingEntity;
using CabBookingDal;
using System.Collections;

namespace CabBookingBL
{
    public class UserBL : IUser
    {
        IUser userRepository = new UserRepository();        //userrepository instance for user interface
        public IEnumerable<Role> GetRoles()             //returns the roles for registration
        {
            return userRepository.GetRoles();
        }
        public void SignUp(User user)               // pass the signup object to repository
        {
            userRepository.SignUp(user);
        }
        public void SignUpNext(Cab cab)             //driver signup additional registration
        {
            userRepository.SignUpNext(cab);
        }


        public User GetUserById(int userId)         //get the user row by the id
        {
            return userRepository.GetUserById(userId);
        }

        public int GetUserId(string mailId)      //get the user id using the unique mail id
        {
            return userRepository.GetUserId(mailId);
        }


        public IEnumerable<CabType> GetCabType()      //get the type of cab while driver registration
        {
            return userRepository.GetCabType();
        }

       
        public User CheckLogin(User user)        //check for valid login
        {
            return userRepository.CheckLogin(user);
        }
    }
}
