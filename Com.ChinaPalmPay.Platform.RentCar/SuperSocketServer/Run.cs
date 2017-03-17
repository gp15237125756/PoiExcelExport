using Com.ChinaPalmPay.Platform.RentCar.BLLFacs;
using Com.ChinaPalmPay.Platform.RentCar.Common;
using Com.ChinaPalmPay.Platform.RentCar.DALFactory;
using Com.ChinaPalmPay.Platform.RentCar.IBLLS;
using Com.ChinaPalmPay.Platform.RentCar.IDAL;
using Com.ChinaPalmPay.Platform.RentCar.Model;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketServer
{
    public class Run : CommandBase<MySession, StringRequestInfo>
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
              RunRealTime real = Analysis.analysisRun(requestInfo);
              //  33字节请求数据
              real.sampleTime = string.Format("{0:yyyyMMddHHmmssfff}", DateTime.Now);
              if (RealTimeThread.dic.ContainsKey(real.TerminalId))
              {
                  CarInfo info = RealTimeThread.dic[real.TerminalId] as CarInfo;
                  if (info != null)
                  {
                      info.Power = real.batteryInfo;
                      info.Voltage = real.voltage;
                      info.Speed = real.speed;
                      info.Mile = real.mile;
                      info.Longitude = real.longitude;
                      info.Latitude = real.latitude;
                      RealTimeThread.dic[real.TerminalId] = info;
                  }

              }
              else
              {
                  CarInfo c = new CarInfo();
                  c.Power = real.batteryInfo;
                  c.Voltage = real.voltage;
                  c.Speed = real.speed;
                  c.Mile = real.mile;
                  c.Longitude = real.longitude;
                  c.Latitude = real.latitude;
                  RealTimeThread.dic.Add(real.TerminalId, c);
              }

              if (requestInfo != null)
              {
                  db_realtime.uploadRunRealTime(real);
              }
              //服务器响应
              // session.Send(requestInfo.Body);
             }
        }
    }

