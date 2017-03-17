using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.IMessaging
{
  public  interface IWechatUserReg
    {
        void Send(UserGroup group);
        void Send(UserLogin login);
        void Send(User user);
        void Send(UserRegister register);
        UserGroup ReceiveUserGroup();
        UserLogin ReceiveUserLogin();
        User ReceiveUser();
        UserRegister ReceiveUserRegister();
    }
}
