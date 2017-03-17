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
  public   class MsmqUserChangeTel : RentCarQueue, IUserChangeTel
    {
       private static readonly string queuePath = ConfigurationManager.AppSettings["UserComplQueuePath"];
        private static int queueTimeout = 20;
        //**创建消息队列**
        public MsmqUserChangeTel()
            : base(queuePath, queueTimeout)
        {
            // Set the queue to use Binary formatter for smaller foot print and performance
            queue.Formatter = new BinaryMessageFormatter();
        }

        public void Send(UserLogin user)
        {
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(user);
        }

        public new UserLogin Receive()
        {
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (UserLogin)((Message)base.Receive()).Body;
        }
    }
}
