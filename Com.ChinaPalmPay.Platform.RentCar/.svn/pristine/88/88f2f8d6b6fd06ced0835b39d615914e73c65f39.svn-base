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
    public class MsmqWechatUserReg : RentCarQueue, IWechatUserReg
    {
        private static readonly string queuePath = ConfigurationManager.AppSettings["WeChatRegisterQueuePath"];
        private static int queueTimeout = 20;
        public MsmqWechatUserReg()
            : base(queuePath, queueTimeout)
        {
            queue.Formatter = new BinaryMessageFormatter();
        }
        public void Send(UserGroup group)
        {
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(group);
        }
        public UserGroup ReceiveUserGroup()
        {
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (UserGroup)((Message)base.Receive()).Body;
        }
        public void Send(UserLogin group)
        {
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(group);

        }
        public UserLogin ReceiveUserLogin()
        {
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (UserLogin)((Message)base.Receive()).Body;
        }
        public void Send(User group)
        {
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(group);

        }
        public User ReceiveUser()
        {
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (User)((Message)base.Receive()).Body;
        }
        public void Send(UserRegister register)
        {
            base.transactionType = MessageQueueTransactionType.Single;
            base.Send(register);

        }
        public UserRegister ReceiveUserRegister()
        {
            base.transactionType = MessageQueueTransactionType.Automatic;
            return (UserRegister)((Message)base.Receive()).Body;
        }


    }
}
