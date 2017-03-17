using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Com.ChinaPalmPay.Platform.RentCar.IBLLS;
using System.Reflection;

namespace Com.ChinaPalmPay.Platform.RentCar.BLLFacs
{
    public class BllAccess
    {
         // Look up the DAL implementation we should be using
        private static readonly string UserBllPath = ConfigurationManager.AppSettings["UserBll"];
        private static readonly string ZSCBllPath = ConfigurationManager.AppSettings["ZSCBll"];

        private BllAccess() { 
        
        }
        //使用反射得到IUserManager接口
        public static IUserHandler CreateUserService()
        {
            //****通过反射，实际通过web配置文件返回的是具体实现****
            string className = UserBllPath + ".UserHandlers";
            object obis = (Com.ChinaPalmPay.Platform.RentCar.IBLLS.IUserHandler)Assembly.Load(UserBllPath).CreateInstance(className);
            return (Com.ChinaPalmPay.Platform.RentCar.IBLLS.IUserHandler)obis;
        }

        public static IZSCHandler CreateZSCService()
        {
            //****通过反射，实际通过web配置文件返回的是具体实现****
            string className = ZSCBllPath + ".ZSCHandlers";
            object obis = (Com.ChinaPalmPay.Platform.RentCar.IBLLS.IZSCHandler)Assembly.Load(ZSCBllPath).CreateInstance(className);
            return (Com.ChinaPalmPay.Platform.RentCar.IBLLS.IZSCHandler)obis;
        }
        public static IOrderHandler CreateOrderService()
        {
            //****通过反射，实际通过web配置文件返回的是具体实现****
            string className = ZSCBllPath + ".OrderHandler";
            object obis = (Com.ChinaPalmPay.Platform.RentCar.IBLLS.IOrderHandler)Assembly.Load(ZSCBllPath).CreateInstance(className);
            return (Com.ChinaPalmPay.Platform.RentCar.IBLLS.IOrderHandler)obis;
        }
        public static IPayHandler CreatePayService()
        {
            //****通过反射，实际通过web配置文件返回的是具体实现****
            string className = ZSCBllPath + ".PayHandler";
            object obis = (Com.ChinaPalmPay.Platform.RentCar.IBLLS.IPayHandler)Assembly.Load(ZSCBllPath).CreateInstance(className);
            return (Com.ChinaPalmPay.Platform.RentCar.IBLLS.IPayHandler)obis;
        }
        public static IPaymentHandler CreatePaymentService()
        {
            //****通过反射，实际通过web配置文件返回的是具体实现****
            string className = ZSCBllPath + ".PaymentHandler";
            object obis = (Com.ChinaPalmPay.Platform.RentCar.IBLLS.IPaymentHandler)Assembly.Load(ZSCBllPath).CreateInstance(className);
            return (Com.ChinaPalmPay.Platform.RentCar.IBLLS.IPaymentHandler)obis;
        }
        public static IRealTimeHandler CreateRealTimeService()
        {
            //****通过反射，实际通过web配置文件返回的是具体实现****
            string className = ZSCBllPath + ".RealTimeHandler";
            object obis = (Com.ChinaPalmPay.Platform.RentCar.IBLLS.IRealTimeHandler)Assembly.Load(ZSCBllPath).CreateInstance(className);
            return (Com.ChinaPalmPay.Platform.RentCar.IBLLS.IRealTimeHandler)obis;
        }
        public static ITerminalLiveHandler CreateTerminalLiveService()
        {
            //****通过反射，实际通过web配置文件返回的是具体实现****
            string className = ZSCBllPath + ".TerminalLiveHandler";
            object obis = (Com.ChinaPalmPay.Platform.RentCar.IBLLS.ITerminalLiveHandler)Assembly.Load(ZSCBllPath).CreateInstance(className);
            return (Com.ChinaPalmPay.Platform.RentCar.IBLLS.ITerminalLiveHandler)obis;
        }
    }
}
