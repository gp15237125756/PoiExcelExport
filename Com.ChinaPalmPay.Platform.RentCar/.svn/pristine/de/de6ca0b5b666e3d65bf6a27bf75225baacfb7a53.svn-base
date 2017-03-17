using Com.ChinaPalmPay.Platform.RentCar.BLLFacs;
using Com.ChinaPalmPay.Platform.RentCar.IBLLS;
using Com.ChinaPalmPay.Platform.RentCar.Model;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketServer
{
    public class Stop : CommandBase<MySession,StringRequestInfo>
    {
        // GET: /RealTime/

        private static readonly IRealTimeHandler db_realtime = BllAccess.CreateRealTimeService();
        public override void ExecuteCommand(MySession session, StringRequestInfo requestInfo)
        {
            // Console.WriteLine("Run:" + requestInfo.Body.Length);
            //foreach (var x in requestInfo.Body)
            //{
            //    Console.WriteLine((int)Convert.ToChar(x));
            //}
            //session.Send(requestInfo.Body);
            StopRealTime real = Analysis.analysisStop(requestInfo);
            //  33字节请求数据
            if (RealTimeThread.dic.ContainsKey(real.TerminalId))
            {
                CarInfo info = RealTimeThread.dic[real.TerminalId] as CarInfo;
                if (info != null)
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

            if (requestInfo != null)
            {
                db_realtime.uploadStopRealTime(real);
            }
            //服务器响应
            // session.Send(requestInfo.Body);
        }
    }
}
