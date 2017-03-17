using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.MsmqMessaging
{
    public class RentCarQueue:IDisposable
    {
        protected MessageQueueTransactionType transactionType = MessageQueueTransactionType.Automatic;
        protected MessageQueue queue;
        protected TimeSpan timeout;

        public RentCarQueue(string queuePath, int timeoutSeconds)
        {
            if (!MessageQueue.Exists(queuePath))
            {
            queue =MessageQueue.Create(queuePath,true);
            }
            queue = new MessageQueue(queuePath);
            timeout = TimeSpan.FromSeconds(Convert.ToDouble(timeoutSeconds));
            // Performance optimization since we don't need these features
           // queue.DefaultPropertiesToSend.AttachSenderId = false;
           // queue.DefaultPropertiesToSend.UseAuthentication = false;
           // queue.DefaultPropertiesToSend.UseEncryption = false;
            //queue.DefaultPropertiesToSend.AcknowledgeType = AcknowledgeTypes.None;
            //queue.DefaultPropertiesToSend.UseJournalQueue = false;
        }

        public virtual object Receive()
        {
            try
            {
                //using (Message message = queue.Receive(timeout,transactionType))
                using (Message message = queue.Receive(transactionType))
                    return message;
            }
            catch (MessageQueueException mqex)
            {
                if (mqex.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
                    throw new TimeoutException();

                throw;
            }
        }

        public virtual void Send(object msg)
        {
            queue.Send(msg, transactionType);
        }

        #region IDisposable Members
        public void Dispose()
        {
            queue.Dispose();
        }
        #endregion
    }
}
