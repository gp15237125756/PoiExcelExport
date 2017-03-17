
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Com.pal
{
   public class CacheAccess
    {
            // Look up the DAL implementation we should be using
        private static readonly string dbpath = ConfigurationManager.AppSettings["UserRegDbDAL"];
        private CacheAccess() { }
        //使用反射得到IUserManager接口
        public static Com.ChinaPalmPay.Platform.RentCar.IDAL.IUserManager CreateUserDbManager()
        {
            //****通过反射，实际通过web配置文件返回的是具体实现****
            string className1 = dbpath + ".UserOperations";
            return (Com.ChinaPalmPay.Platform.RentCar.IDAL.IUserManager)(Assembly.Load(dbpath).CreateInstance(className1));
        }
    }
}
