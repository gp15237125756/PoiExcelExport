using Com.ChinaPalmPay.Platform.RentCar.BLLFacs;
using Com.ChinaPalmPay.Platform.RentCar.IBLLS;
using Com.ChinaPalmPay.Platform.RentCar.Model;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperSocketServer
{
    public class Aut : CommandBase<MySession, StringRequestInfo>
    {
        private static readonly IRealTimeHandler db_realtime = BllAccess.CreateRealTimeService();
        public override void ExecuteCommand(MySession session, StringRequestInfo requestInfo)
        {
            AuthorizationRequest real = Analysis.analysisAuthorizationReq(requestInfo);
            if (RealTimeThread.dic.ContainsKey(real.TerminalId))
            {
                CarInfo info = RealTimeThread.dic[real.TerminalId] as CarInfo;
                if (info == null)
                {
                    info.Power = int.Parse(real.Power);
                    info.Voltage = int.Parse(real.Voltage);
                    info.Current = int.Parse(real.Current);
                    info.Temperature = int.Parse(real.Temperature);
                    RealTimeThread.dic[real.TerminalId] = info;
                }
            }
            else
            {
                CarInfo c = new CarInfo();
                c.Power = int.Parse(real.Power);
                c.Voltage = int.Parse(real.Voltage);
                c.Current = int.Parse(real.Current);
                c.Temperature = int.Parse(real.Temperature);
                RealTimeThread.dic.Add(real.TerminalId, c);
            }
            if (real != null)
            {
                byte[] head = new byte[] {0xd3,0xd3};
                byte[] outs = db_realtime.uploadAuthorization(real);
                session.Send(head, 0, head.Length);
                session.Send(outs, 0, outs.Length);
            }
        }
    }
}
