using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;
using Com.ChinaPalmPay.Platform.RentCar.IDAL;

namespace Com.ChinaPalmPay.Platform.RentCar.CacheFac
{
   public class CacheAccess
    {
        private static readonly string dbpath = ConfigurationManager.AppSettings["UserRegDbDAL"];
        public static IUserManager CreateUserDbManager()
        {
            //Com.ChinaPalmPay.Platform.RentCar.SQLServer.UserRegisters
            //Com.ChinaPalmPay.Platform.RentCar.SQLServer.UserRegisters
            //****通过反射，实际通过web配置文件返回的是具体实现****
            string className1 = dbpath + ".UserRegisters";
            return (IUserManager)Assembly.Load(dbpath).CreateInstance(className1);
        }
    }
}
