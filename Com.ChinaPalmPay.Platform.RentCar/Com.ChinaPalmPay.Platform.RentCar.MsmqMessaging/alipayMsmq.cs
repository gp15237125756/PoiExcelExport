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
    public class alipayMsmq : RentCarQueue, IalipayMsmq
    {
        private static readonly string queuePath = ConfigurationManager.AppSettings["AlipayQueuePath"];
        private static int queueTimeout = 20;
        //**创建消息队列**
        public alipayMsmq()
            : base(queuePath, queueTimeout)
        {
            // Set the queue to use Binary formatter for smaller foot print and performance
            queue.Formatter = new BinaryMessageFormatter();
        }
        public void Send(Alipay user)
        {
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(user);
        }

        public new Alipay ReceiveAlipay()
        {
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (Alipay)((Message)base.Receive()).Body;
        }

        public void Send(Recharge user)
        {
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(user);
        }

        public Recharge ReceiveRecharge()
        {
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (Recharge)((Message)base.Receive()).Body;
        }

        public void Send(OrderLog user)
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
