using Com.ChinaPalmPay.Platform.RentCar.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.DALFactory
{
    class Test
    {
        public static void main()
        {
            try
            {
                IUserManager manager = DataAccess.CreateUserDbManager();
                Console.Write(manager.GetType());
            }
            catch { 
            
            }
        }

    }
}
