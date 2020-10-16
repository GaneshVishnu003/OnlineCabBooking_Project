using System.Collections.Generic;
using CabBookingEntity;
using CabBookingDal;
using System.Collections;

namespace CabBookingBL
{
    public class UserBL : IUserBL
    {
        IUser userRepository = new UserRepository();        //userrepository instance for user interface

        //returns the roles for registration
        public IEnumerable<Role> GetRoles()             
        {
            return userRepository.GetRoles();
        }

        // pass the signup object to repository
        public void SignUp(User user)               
        {
            userRepository.SignUp(user);
        }

        //driver signup additional registration
        public void DriverRegistration(Cab cab)             
        {
            cab.RequestStatus = "Requested";
            userRepository.DriverRegistration(cab);
        }

        //get the user row by the id
        public User GetUserById(int userId)         
        {
            return userRepository.GetUserById(userId);
        }

        //get the user id using the unique mail id
        public int GetUserId(string mailId)      
        {
            return userRepository.GetUserId(mailId);
        }

        //get the type of cab while driver registration
        public IEnumerable<CabType> GetCabType()      
        {
            return userRepository.GetCabType();
        }

        //check for valid login
        public User CheckLogin(User user)        
        {
            return userRepository.CheckLogin(user);
        }
    }
}
