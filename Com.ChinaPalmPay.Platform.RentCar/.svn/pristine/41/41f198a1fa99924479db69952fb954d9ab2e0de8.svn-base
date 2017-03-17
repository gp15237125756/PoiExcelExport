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
  public  class MsmqUserUpdate : RentCarQueue, IUserUp
    {
      private static readonly string queuePath = ConfigurationManager.AppSettings["UserUpdateQueuePath"];
        private static int queueTimeout = 20;
        //**创建消息队列**
        public MsmqUserUpdate()
            : base(queuePath, queueTimeout)
        {
            // Set the queue to use Binary formatter for smaller foot print and performance
            queue.Formatter = new BinaryMessageFormatter();
        }
        public void Send(UserLogin group)
        {
            //MessageQueue queue = new MessageQueue(queuePath);
            //base.transactionType = MessageQueueTransactionType.Single;
            //queue.Send(group, base.transactionType);
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(group);
            // base.Send(group);
        }
        public UserLogin Receive()
        {
            // This method involves in distributed transaction and need Automatic Transaction type
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (UserLogin)((Message)base.Receive()).Body;
        }
    }
}
