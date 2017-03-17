using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.IMessaging
{
    public interface IalipayMsmq
    {
        void Send(Alipay user);
        Alipay ReceiveAlipay();
        void Send(Recharge user);
        Recharge ReceiveRecharge();
        void Send(OrderLog user);
        OrderLog ReceiveOrderLog();

    }
}
