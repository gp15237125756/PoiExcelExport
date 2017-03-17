using Com.ChinaPalmPay.Platform.RentCar.IMessaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using Com.ChinaPalmPay.Platform.RentCar.Model;
using System.Collections;

namespace Com.ChinaPalmPay.Platform.RentCar.MsmqMessaging
{

    public class MsmqUserRegister : RentCarQueue, IUserReg
    {
        private static readonly string queuePath = ConfigurationManager.AppSettings["UserRegisterQueuePath"];
        private static int queueTimeout = 20;
        //**创建消息队列**
        public MsmqUserRegister()
            : base(queuePath, queueTimeout)
        {
            // Set the queue to use Binary formatter for smaller foot print and performance
            queue.Formatter = new BinaryMessageFormatter();
        }
        /// <summary>
        /// Method to send asynchronous order to Pet Shop Message Queue
        /// </summary>
        /// <param name="orderMessage">All information for an order</param>
        public void Send(UserGroup group)
        {
            //MessageQueue queue = new MessageQueue(queuePath);
            //base.transactionType = MessageQueueTransactionType.Single;
            //queue.Send(group, base.transactionType);
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(group);
           // base.Send(group);
        }
        public  UserGroup ReceiveUserGroup()
        {
            // This method involves in distributed transaction and need Automatic Transaction type
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (UserGroup)((Message)base.Receive()).Body;
        }
        public void Send(UserLogin group)
        {
            //MessageQueue queue = new MessageQueue(queuePath);
            //// This method does not involve in distributed transaction and optimizes performance using Single type
            base.transactionType = MessageQueueTransactionType.Single;
          //  queue.Send(group, base.transactionType);
            base.Send(group);

        }
        public UserLogin ReceiveUserLogin()
        {
            // This method involves in distributed transaction and need Automatic Transaction type
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (UserLogin)((Message)base.Receive()).Body;
        }
        public void Send(User group)
        {
            // This method does not involve in distributed transaction and optimizes performance using Single type
            //MessageQueue queue = new MessageQueue(queuePath);
            //base.transactionType = MessageQueueTransactionType.Single;
            //queue.Send(group, base.transactionType);
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(group);

        }
        public User ReceiveUser()
        {
            // This method involves in distributed transaction and need Automatic Transaction type
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (User)((Message)base.Receive()).Body;
        }
      

        //public  object Receive()
        //{
        //    // This method involves in distributed transaction and need Automatic Transaction type
        //    base.transactionType = MessageQueueTransactionType.Automatic;
        //    return (UserGroup)((Message)base.Receive()).Body;
        //}
        public object ReceiveGroup(int timeout)
        {
            MessageQueue queue = new MessageQueue(queuePath);
            base.timeout = TimeSpan.FromSeconds(Convert.ToDouble(timeout));
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (UserGroup)((Message)queue.Receive()).Body;
        }
        public object ReceiveLogin(int timeout)
        {
            MessageQueue queue = new MessageQueue(queuePath);
            base.timeout = TimeSpan.FromSeconds(Convert.ToDouble(timeout));
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (UserLogin)((Message)queue.Receive()).Body;
        }
        public object ReceiveUser(int timeout)
        {
            MessageQueue queue = new MessageQueue(queuePath);
            base.timeout = TimeSpan.FromSeconds(Convert.ToDouble(timeout));
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (User)((Message)queue.Receive()).Body;
        }
        public object ReceiveRegister(int timeout)
        {
            MessageQueue queue = new MessageQueue(queuePath);
            base.timeout = TimeSpan.FromSeconds(Convert.ToDouble(timeout));
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (MsmqUserRegister)((Message)queue.Receive()).Body;
        }
      
        // 打开队列并获取队列的全部消息
        public  object[] GetAllUserMessage()
        {
            //连接到本地队列
                try
                {

                    MessageQueue myQueue = new MessageQueue(queuePath);
                    Message[] message = myQueue.GetAllMessages();
                    myQueue.Purge();
                    UserGroup userbase = null;
                    UserLogin login = null;
                    User userinfo = null;
                    UserRegister reg = null;
                    MessageQueueTransaction transaction = new MessageQueueTransaction();
                    if (message.Length > 0)
                    {
                        object[] All = new object[message.Length];
                        XmlMessageFormatter formatter1 = new XmlMessageFormatter(new Type[] { typeof(UserGroup) });
                        XmlMessageFormatter formatter2 = new XmlMessageFormatter(new Type[] { typeof(UserLogin) });
                        XmlMessageFormatter formatter3 = new XmlMessageFormatter(new Type[] { typeof(User) });
                        XmlMessageFormatter formatter4 = new XmlMessageFormatter(new Type[] { typeof(UserRegister) });
                        for (int i = 0; i < message.Length; i += 4)
                        {
                            Message x = message[i];
                            Message y = message[i + 1];
                            Message z = message[i + 2];
                            Message w = message[i + 3];
                            x.Formatter = formatter1;
                            y.Formatter = formatter2;
                            z.Formatter = formatter3;
                            w.Formatter = formatter4;
                            // 如果消息队列采用了事务，则开始事务  
                            if (myQueue.Transactional)
                                transaction.Begin();
                            userbase = (UserGroup)x.Body;
                            login = (UserLogin)y.Body;
                            userinfo = (User)z.Body;
                            reg = (UserRegister)w.Body;
                            All[i] = userbase;
                            All[i + 1] = login;
                            All[i + 2] = userinfo;
                            All[i + 3] = reg;
                            if (myQueue.Transactional)
                                transaction.Commit();
                        }
                        return All;
                    }
                    // 如果消息队列采用了事务，则停止事务  
                    return null;
                }
                catch (Exception e)
                {
                    return null;
                }
        }
 

        public void Send(Model.UserRegister register)
        {
            // This method does not involve in distributed transaction and optimizes performance using Single type
            //MessageQueue queue = new MessageQueue(queuePath);
            //base.transactionType = MessageQueueTransactionType.Single;
            //queue.Send(register, base.transactionType);
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(register);

        }
        public UserRegister ReceiveUserRegister()
        {
            // This method involves in distributed transaction and need Automatic Transaction type
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (UserRegister)((Message)base.Receive()).Body;
        }


        public bool Send(UserGroup group, UserLogin login, User user, Model.UserRegister register)
        {
              //发送消息
            //连接到本地的队列     
                MessageQueue myQueue = new MessageQueue(queuePath);
                MessageQueueTransaction trans = new MessageQueueTransaction();
                try
                {
                    if (myQueue.Transactional)
                    {
                        trans.Begin();
                    }
                    Message myMessage1 = new Message(group);
                    myMessage1.AdministrationQueue = myQueue;
                    myMessage1.AcknowledgeType = AcknowledgeTypes.PositiveReceive | AcknowledgeTypes.PositiveArrival;
                    myMessage1.Formatter = new XmlMessageFormatter(new Type[] { typeof(UserGroup) });
                    myMessage1.Priority = MessagePriority.Highest;
                    myQueue.Send(myMessage1, trans);

                    Message myMessage2 = new Message(login);
                    myMessage2.Priority = MessagePriority.Highest;
                    myMessage2.Formatter = new XmlMessageFormatter(new Type[] { typeof(UserLogin) });
                    myQueue.Send(myMessage2, trans);

                    Message myMessage3 = new Message(user);
                    myMessage3.Priority = MessagePriority.Highest;
                    myMessage3.Formatter = new XmlMessageFormatter(new Type[] { typeof(User) });
                    myQueue.Send(myMessage3, trans);

                    Message myMessage4 = new Message(register);
                    myMessage4.Priority = MessagePriority.Highest;
                    myMessage4.Formatter = new XmlMessageFormatter(new Type[] { typeof(MsmqUserRegister) });
                    myQueue.Send(myMessage4, trans);
                    if (myQueue.Transactional)
                        trans.Commit();
                    return true;

                }
                catch (ArgumentException e)
                {
                    // 如果消息队列采用了事务并且出现了异常，则终止事务  
                    if (myQueue.Transactional)
                        trans.Abort();
                    return false;
                }
        }


       
    }
}
