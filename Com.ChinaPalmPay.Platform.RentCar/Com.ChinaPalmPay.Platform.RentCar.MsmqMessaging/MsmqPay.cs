using Com.ChinaPalmPay.Platform.RentCar.IMessaging;
using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.MsmqMessaging
{
   public class MsmqPay : RentCarQueue, IPayMsmq
    {
         private static readonly string queuePath = ConfigurationManager.AppSettings["PayQueuePath"];
        private static int queueTimeout = 20;
        //**创建消息队列**
        public MsmqPay()
            : base(queuePath, queueTimeout)
        {
            // Set the queue to use Binary formatter for smaller foot print and performance
            queue.Formatter = new BinaryMessageFormatter();
        }
        public void Send(Recharge charge)
        {
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(charge);
        }

        public Recharge Receive(int timeout)
        {
            base.timeout = TimeSpan.FromSeconds(Convert.ToDouble(timeout));
            return Receive();
        }

        public  new Recharge Receive()
        {
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (Recharge)((Message)base.Receive()).Body;
        }


    }
}
