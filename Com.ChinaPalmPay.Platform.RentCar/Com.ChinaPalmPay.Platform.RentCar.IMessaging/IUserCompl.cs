using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.IMessaging
{
    public interface IUserCompl
    {
        void Send(User user);
        User Receive();

    }
}
