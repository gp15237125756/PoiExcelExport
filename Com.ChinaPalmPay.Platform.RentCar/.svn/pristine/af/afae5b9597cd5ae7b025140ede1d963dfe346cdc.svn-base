using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.ChinaPalmPay.Platform.RentCar.IMessaging;
using Com.ChinaPalmPay.Platform.RentCar.MessagingFactory;
using Com.ChinaPalmPay.Platform.RentCar.Model;

namespace Com.ChinaPalmPay.Platform.RentCar.BLL
{
    class UserRegisterAsynchronous
    {
        // Get an instance of the MessagingFactory
        // Making this static will cache the Messaging instance after the initial load
        private static readonly IUserReg asynchUser = QueueAccess.CreateUserRegister();

        /// <summary>
        /// This method serializes the order object and send it to the queue for asynchronous processing
        /// </summary>
        /// <param name="order">All information about the order</param>
        public void Insert(UserGroup bas, UserLogin login, User info, UserRegister register)
        {
            //asynchUser.Send(bas,login,info,register);
        }
    }
}
