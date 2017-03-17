using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.IBLLS
{
   public  interface IPaymentHandler
    { 
       //true-----成功  false-----失败
       bool alipayPayment(Alipay alipay);
       bool cupPayment(Cup cup);
       //还车扣款
       Recharge returnCar(string userId,string orderId,out string msg);
       //查询余额
       double queryRemainSum(string id);
       //微信支付回调
      bool chargePayment(string UserID,int? Amount,string PayOrderID,int? Type);
    }
}
