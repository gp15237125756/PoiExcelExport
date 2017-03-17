using Com.ChinaPalmPay.Platform.RentCar.IMessaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.MessagingFactory
{
    public sealed class QueueAccess
    {
        //公用Queue实例程序集
        private static readonly string path = ConfigurationManager.AppSettings["UserRegisterMessaging"];

        private QueueAccess() { }
        //用户注册
        public static IUserReg CreateUserRegister()
        {
            string className = path + ".MsmqUserRegister";
            return (IUserReg)Assembly.Load(path).CreateInstance(className);
        }
        //订单生成
        public static IOrderMsmq CreateOrder()
        {
            string className = path + ".MsmqCreateOrder";
            return (IOrderMsmq)Assembly.Load(path).CreateInstance(className);
        }
        //充值消费生成
        public static IPayMsmq Pay()
        {
            string className = path + ".MsmqPay";
            return (IPayMsmq)Assembly.Load(path).CreateInstance(className);
        }
        public static IUserCompl CompleteUser()
        {
            string className = path + ".MsmqUserCompl";
            return (IUserCompl)Assembly.Load(path).CreateInstance(className);
        }
        public static IUserUp UpdateUser()
        {
            string className = path + ".MsmqUserUpdate";
            return (IUserUp)Assembly.Load(path).CreateInstance(className);
        }
        public static IUserChangeTel ChangeUserTel()
        {
            string className = path + ".MsmqUserChangeTel";
            return (IUserChangeTel)Assembly.Load(path).CreateInstance(className);
        }

        public static IUserChangePhoto ChangeUserPhoto()
        {
            string className = path + ".MsmqUserChangePhoto";
            return (IUserChangePhoto)Assembly.Load(path).CreateInstance(className);
        }
        public static IalipayMsmq Alipay()
        {
            string className = path + ".alipayMsmq";
            return (IalipayMsmq)Assembly.Load(path).CreateInstance(className);
        }
        public static ICupMsmq Cup()
        {
            string className = path + ".cupMsmq";
            return (ICupMsmq)Assembly.Load(path).CreateInstance(className);
        }
        public static IExistUserReg ExistUserReg()
        {
            string className = path + ".ExistUserReg";
            return (IExistUserReg)Assembly.Load(path).CreateInstance(className);
        }
        public static IReturnCarMsmq ReturnCarPay()
        {
            string className = path + ".ReturnCarMsmq";
            return (IReturnCarMsmq)Assembly.Load(path).CreateInstance(className);
        }
        public static IWechatUserReg WechatUserReg()
        {
            string className = path + ".MsmqWechatUserReg";
            return (IWechatUserReg)Assembly.Load(path).CreateInstance(className);
        }
    }
}
