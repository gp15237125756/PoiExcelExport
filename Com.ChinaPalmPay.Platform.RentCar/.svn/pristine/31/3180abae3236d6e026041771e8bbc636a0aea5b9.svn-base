using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;
using System.Data;
using Com.ChinaPalmPay.Platform.RentCar.IDAL;
using Com.ChinaPalmPay.Platform.RentCar.SQLServer;
namespace Com.ChinaPalmPay.Platform.RentCar.DALFactory
{
   public class DataAccess
    {
        // Look up the DAL implementation we should be using
        private static readonly string dbpath = ConfigurationManager.AppSettings["UserRegDbDAL"];
        private static readonly string cachepath = ConfigurationManager.AppSettings["UserRegCacheDAL"];
        private DataAccess() { }
        //使用反射得到IUserManager接口
        public static UserOperations CreateUserDbManager()
        {
            //****通过反射，实际通过web配置文件返回的是具体实现****
            string className1 = dbpath + ".UserOperations";
            return (UserOperations)(Assembly.Load(dbpath).CreateInstance(className1));
        }
        public static IUserManager CreateUserCacheManager()
        {
            //****通过反射，实际通过web配置文件返回的是具体实现****
            string className2 = cachepath + ".UserRegisterDataProxy";
            return (IUserManager)Assembly.Load(cachepath).CreateInstance(className2);
        }
       //地区查询租赁点db
        public static IZSCManager CreateZSCDbManager()
        {
            //****通过反射，实际通过web配置文件返回的是具体实现****
            string className2 = dbpath + ".ZSCOperations";
            return (IZSCManager)Assembly.Load(dbpath).CreateInstance(className2);
        }
        //地区查询租赁点cache

        public static IZSCManager CreateZSCCacheManager()
        {
            //****通过反射，实际通过web配置文件返回的是具体实现****
            string className2 = cachepath + ".ZSCDataProxy";

            return (IZSCManager)Assembly.Load(cachepath).CreateInstance(className2);
        }

        //订单生成db
        public static IOrderManager CreateOrderDbManager()
        {
            //****通过反射，实际通过web配置文件返回的是具体实现****
            string className2 = dbpath + ".OrderOperations";
            return (IOrderManager)Assembly.Load(dbpath).CreateInstance(className2);
        }
        //订单生成cache

        public static IOrderManager CreateOrderCacheManager()
        {
            //****通过反射，实际通过web配置文件返回的是具体实现****
            string className2 = cachepath + ".OrderDataProxy";

            return (IOrderManager)Assembly.Load(cachepath).CreateInstance(className2);
        }
        //消费db
        public static IPayManager CreatePayDbManager()
        {
            //****通过反射，实际通过web配置文件返回的是具体实现****
            string className2 = dbpath + ".PayOperations";
            return (IPayManager)Assembly.Load(dbpath).CreateInstance(className2);
        }
        //实时数据db
        public static IRealTimeManager CreateRealTimeDbManager()
        {
            //****通过反射，实际通过web配置文件返回的是具体实现****
            string className2 = dbpath + ".RealTimeManager";
            return (IRealTimeManager)Assembly.Load(dbpath).CreateInstance(className2);
        }
       //空闲车辆所在租赁点
        public static IIdleCarManager CreatIdleCarDbManager()
        {
            //****通过反射，实际通过web配置文件返回的是具体实现****
            string className2 = dbpath + ".IdleCarManager";
            return (IIdleCarManager)Assembly.Load(dbpath).CreateInstance(className2);
        }

    }
}
