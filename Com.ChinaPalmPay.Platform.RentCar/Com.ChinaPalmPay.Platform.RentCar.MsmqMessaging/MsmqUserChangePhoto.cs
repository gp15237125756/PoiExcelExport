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
  public  class MsmqUserChangePhoto : RentCarQueue, IUserChangePhoto
    {
          private static readonly string queuePath = ConfigurationManager.AppSettings["UserChangePhotoQueuePath"];
        private static int queueTimeout = 20;
        //**创建消息队列**
        public MsmqUserChangePhoto()
            : base(queuePath, queueTimeout)
        {
            // Set the queue to use Binary formatter for smaller foot print and performance
            queue.Formatter = new BinaryMessageFormatter();
        }
        public void Send(User user)
        {
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(user);
        }

        public new User Receive()
        {
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (User)((Message)base.Receive()).Body;
        }
    }
}
