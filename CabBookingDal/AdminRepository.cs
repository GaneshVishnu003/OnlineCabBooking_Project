using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBookingDal
{
    public class AdminRepository
    {
        public static bool CheckLogin(string userName, string password)
        {
            UserContext userContext = new UserContext();
            foreach (var result in userContext.AdminEntity)
            {
                if (result.UserName == userName)
                {
                    if (result.Password == password)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
