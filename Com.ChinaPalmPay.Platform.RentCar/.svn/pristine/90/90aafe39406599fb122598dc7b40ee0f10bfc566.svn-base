using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.ChinaPalmPay.Platform.RentCar.Model;

namespace Com.ChinaPalmPay.Platform.RentCar.IMessaging
{
    public interface IUserReg
    {
        void Send(UserGroup group);
        void Send(UserLogin login);
        void Send(User user);
        void Send(UserRegister register);
         UserGroup  ReceiveUserGroup();
         UserLogin ReceiveUserLogin();
         User ReceiveUser();
         UserRegister ReceiveUserRegister();
        bool Send(UserGroup group,UserLogin login,User user,UserRegister register);
        object[] GetAllUserMessage();

    }
}
