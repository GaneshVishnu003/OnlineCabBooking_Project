using CabBookingEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBookingDal
{
    public interface IUser      //user interface
    {
        //methods used by UserBL and UserDal
        IEnumerable<Role> GetRoles();
        void SignUp(User user);
        void SignUpNext(Cab cab);
        User GetUserById(int userId);
        int GetUserId(string mail);
        IEnumerable<CabType> GetCabType();
        User CheckLogin(User user);
    }
}
