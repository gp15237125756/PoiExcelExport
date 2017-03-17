using Com.Chinapalmpay.Component.Log;
using Com.ChinaPalmPay.Platform.RentCar.Common;
using Com.ChinaPalmPay.Platform.RentCar.DALFactory;
using Com.ChinaPalmPay.Platform.RentCar.IBLLS;
using Com.ChinaPalmPay.Platform.RentCar.IDAL;
using Com.ChinaPalmPay.Platform.RentCar.IMessaging;
using Com.ChinaPalmPay.Platform.RentCar.MessagingFactory;
using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.BLL
{
   public class PayHandler:IPayHandler
    {
       //插入消息队列
      
       IPayMsmq msmq = QueueAccess.Pay();
       public Recharge pay(Recharge charge)
        {
                if (!String.IsNullOrWhiteSpace(charge.UserID) && charge.Amount != 0 && !String.IsNullOrWhiteSpace(charge.PayOrderID) && charge.Type != 0)
                {
                    charge.Creater = charge.UserID;
                    charge.CreateTime = DateTime.Now.ToString();
                    charge.ID = Guid.NewGuid().ToString();
                    if (charge.Type == (int)Commons.PayType.RECHARGE)
                    {
                        charge.Type = (int)Commons.PayType.RECHARGE;
                        charge.Remark = "充值";
                    }
                    else if (charge.Type == (int)Commons.PayType.OTHERCONSUME)
                    {
                        charge.Type = (int)Commons.PayType.OTHERCONSUME;
                        charge.Remark = "其他业务";
                    }
                    //如果是订单消费业务或订单付款业务
                    else if ((charge.Type == (int)Commons.PayType.CONSUME && !String.IsNullOrWhiteSpace(charge.OrderID)))
                    {
                        charge.Type = (int)Commons.PayType.CONSUME;
                        charge.Remark = "消费";
                    }
                    else if ((charge.Type == (int)Commons.PayType.PAYMENT) && !String.IsNullOrWhiteSpace(charge.OrderID))
                    {
                        charge.Type = (int)Commons.PayType.PAYMENT;
                        charge.Remark = "订单付款";
                    }
                    msmq.Send(charge);
                    return charge;
                }
              
            return null;
        }


    }
}
