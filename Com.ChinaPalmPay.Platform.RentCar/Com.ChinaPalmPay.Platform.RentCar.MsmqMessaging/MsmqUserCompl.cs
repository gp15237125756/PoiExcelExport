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
    public class MsmqUserCompl : RentCarQueue, IUserCompl
    {
        private static readonly string queuePath = ConfigurationManager.AppSettings["UserChangeTelQueuePath"];
        private static int queueTimeout = 20;
        //**创建消息队列**
        public MsmqUserCompl()
            : base(queuePath, queueTimeout)
        {
            // Set the queue to use Binary formatter for smaller foot print and performance
            queue.Formatter = new BinaryMessageFormatter();
        }
        /// <summary>
        /// Method to send asynchronous order to Pet Shop Message Queue
        /// </summary>
        /// <param name="orderMessage">All information for an order</param>
        public void Send(User group)
        {
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(group);
        }
        public User Receive()
        {
            // This method involves in distributed transaction and need Automatic Transaction type
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (User)((Message)base.Receive()).Body;
        }
      
    }
}
