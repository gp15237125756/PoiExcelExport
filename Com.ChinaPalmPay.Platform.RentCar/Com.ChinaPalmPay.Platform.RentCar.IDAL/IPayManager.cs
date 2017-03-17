using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.IDAL
{
    public interface IPayManager
    {
        Recharge Addpay(Recharge recharge);
        Alipay Addalipay(Alipay ali);
        Cup AddCup(Cup ali);
        OrderLog Addlog(OrderLog log);
    }
}
