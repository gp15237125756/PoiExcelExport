using Com.ChinaPalmPay.Platform.RentCar.Model;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketServer
{
    //自定义sessioin,包含三个Command
    public class MySession : AppSession<MySession>
    {
        protected override void OnSessionStarted()
        {
            Console.WriteLine("Welcome to SuperSocket Telnet Server");
           // this.Send("Welcome to SuperSocket Telnet Server");
        }


        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            Console.WriteLine(requestInfo.Key+"  "+ requestInfo.Body);
            this.Send("Unknow request");
        }

        protected override void HandleException(Exception e)
        {
            Console.WriteLine("Application error: {0}", e.Message);
            this.Send("Application error: {0}", e.Message);
        }

        protected override void OnSessionClosed(CloseReason reason)
        {
            //add you logics which will be executed after the session is closed
            base.OnSessionClosed(reason);
        }
        //自定义属性
        public int GameHallId { get; internal set; }

        public int RoomId { get; internal set; }
    }
}
