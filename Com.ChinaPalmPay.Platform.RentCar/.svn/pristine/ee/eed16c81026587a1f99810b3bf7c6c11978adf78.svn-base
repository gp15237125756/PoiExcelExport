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
    public class cupMsmq : RentCarQueue, ICupMsmq
    {
         private static readonly string queuePath = ConfigurationManager.AppSettings["CupQueuePath"];
        private static int queueTimeout = 20;
        //**创建消息队列**
        public cupMsmq()
            : base(queuePath, queueTimeout)
        {
            // Set the queue to use Binary formatter for smaller foot print and performance
            queue.Formatter = new BinaryMessageFormatter();
        }
        public void SendCup(Cup user)
        {
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(user);
        }

        public Cup ReceiveCup()
        {
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (Cup)((Message)base.Receive()).Body;
        }

        public void SendRecharge(Recharge user)
        {
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(user);
        }

        public Recharge ReceiveRecharge()
        {
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (Recharge)((Message)base.Receive()).Body;
        }

        public void SendOrderLog(OrderLog user)
        {
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(user);
        }

        public OrderLog ReceiveOrderLog()
        {
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (OrderLog)((Message)base.Receive()).Body;
        }
    }
}
