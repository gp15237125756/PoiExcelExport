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
   public class MsmqCreateOrder : RentCarQueue, IOrderMsmq
    {
         private static readonly string queuePath = ConfigurationManager.AppSettings["CreateOrderQueuePath"];
        private static int queueTimeout = 20;
        //**创建消息队列**
        public MsmqCreateOrder()
            : base(queuePath, queueTimeout)
        {
            // Set the queue to use Binary formatter for smaller foot print and performance
            queue.Formatter = new BinaryMessageFormatter();
        }

        public void Send(Order order)
        {
            // This method does not involve in distributed transaction and optimizes performance using Single type
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(order);
        }
        public  new Order Receive()
        {
            // This method involves in distributed transaction and need Automatic Transaction type
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (Order)((Message)base.Receive()).Body;
        }

        public Order Receive(int timeout)
        {
            base.timeout = TimeSpan.FromSeconds(Convert.ToDouble(timeout));
            return Receive();
        }


        public void SendUserAuth(UserAuthorization order)
        {
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(order);
        }

        //public UserAuthorization ReceiveUserAuth(int timeout)
        //{
        //    base.timeout = TimeSpan.FromSeconds(Convert.ToDouble(timeout));
        //    return Receive();
        //}

        public UserAuthorization ReceiveUserAuth()
        {
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (UserAuthorization)((Message)base.Receive()).Body;
        }
    }
}
