using Com.ChinaPalmPay.Platform.RentCar.Model;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketServer
{
    public class myServer : AppServer<MySession>
    {
        //public myServer()
        //    : base()
        //{

        //}
        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
          //  this.NewRequestReceived += myServer_NewRequestReceived;
        }

        //void myServer_NewRequestReceived(MySession session, SuperSocket.SocketBase.Protocol.StringRequestInfo requestInfo)
        //{
            
        //}

        protected override void OnStartup()
        {
            base.OnStartup();
        }

        protected override void OnStopped()
        {
            base.OnStopped();
        }

        
    }
}
