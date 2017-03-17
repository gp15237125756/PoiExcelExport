using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.IMessaging
{
 public   interface IOrderMsmq
    {
    void Send(Order order);
    Order Receive(int timeout);
    Order Receive();
    void SendUserAuth(UserAuthorization order);
   // UserAuthorization ReceiveUserAuth(int timeout);
    UserAuthorization ReceiveUserAuth();
    }
}
