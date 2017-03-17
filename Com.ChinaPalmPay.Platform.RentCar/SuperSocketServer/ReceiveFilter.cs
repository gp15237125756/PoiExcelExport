//using Com.ChinaPalmPay.Platform.RentCar.Common;
//using SuperSocket.SocketBase.Protocol;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Com.ChinaPalmPay.Platform.RentCar.Model;
//namespace SuperSocketServer
//{
//    public class ReceiveFilter : IReceiveFilter<IRequestInfo>
//    {
//        //字节数组转换对象CarInfo
//        public RunRealTime Filter(byte[] readBuffer, int offset, int length, bool toBeCopied, out int rest)
//        {
//            //如果有数据可读
//           // RunRealTime run = new RunRealTime();
//            //byte[] readBuffer = new byte[33];
//            RunRealTime run = new RunRealTime();
//            //3字节ID
//            byte[] id = new byte[3];
//            Array.Copy(readBuffer, 0, id, 0, id.Length);
//            run.TerminalId = ByteUtils.byteToHexStr(id);
//            //4字节纬度--6  31 15.12 34 50
//            byte[] lat = new byte[5];
//            Array.Copy(readBuffer, 3, lat, 0, lat.Length);
//            //lat转换int 直接放大10^6倍取整传输 
//            run.latitude = long.Parse("" + lat[0] + lat[1] + lat[2] + lat[3] + lat[4]);
//            //run.latitude = ((lat[0] << 24) & 0xff000000) + ((lat[1] << 16) & 0xff0000) + ((lat[2] << 8) & 0xff00) + (lat[3] & 0xff);
//            //经度--6 120 10 .56 78 90
//            byte[] lon = new byte[5];
//            Array.Copy(readBuffer, 3 + 5, lon, 0, lon.Length);
//            // run.longitude = ((lon[0] << 24) & 0xff000000) + ((lon[1] << 16) & 0xff00000) + ((lon[2] << 8) & 0xff00) + (lon[3] & 0xff);
//            run.longitude = long.Parse("" + lon[0] + lon[1] + lon[2] + lon[3] + lon[4]);
//            //Power 1byte
//            byte[] power = new byte[1];
//            Array.Copy(readBuffer, 3 + 5 + 5, power, 0, power.Length);
//            run.batteryInfo = power[0];
//            //voltage 1+1byte
//            byte[] voltage = new byte[2];
//            Array.Copy(readBuffer, 3 + 5 + 5 + 1, voltage, 0, voltage.Length);
//            run.voltage = ((voltage[0] << 8) & 0xff00) + (voltage[1] & 0xff);
//            //current 1+1byte
//            byte[] current = new byte[2];
//            Array.Copy(readBuffer, 3 + 5 + 5 + 1 + 2, current, 0, current.Length);
//            run.current = ((current[0] << 8) & 0xff00) + (current[1] & 0xff);
//            //temper 1+1byte
//            byte[] temper = new byte[2];
//            Array.Copy(readBuffer, 3 + 5 + 5 + 1 + 2 + 2, temper, 0, temper.Length);
//            run.Temper = ((temper[0] << 8) & 0xff00) + (temper[1] & 0xff);
//            //门状态：前门1111开  0000关 后门1111开  0000关
//            byte[] gate = new byte[1];
//            Array.Copy(readBuffer, 3 + 5 + 5 + 1 + 2 + 2 + 2, gate, 0, gate.Length);
//            run.beforeGateStatus = ((gate[0] >> 4) & 0x0f);
//            run.behindGateStatus = ((gate[0]) & 0x0f);
//            //车速 1+4byte 车速+续航
//            byte[] speed = new byte[5];
//            Array.Copy(readBuffer, 3 + 5 + 5 + 1 + 2 + 2 + 2 + 1, speed, 0, speed.Length);
//            run.speed = speed[0];
//            run.mile = ((speed[1] << 24) & 0xff000000) + ((speed[2] << 16) & 0xff0000) + ((speed[3] << 8) & 0xff00) + (speed[4] & 0xff);
//            //时间
//            byte[] date = new byte[7];
//            Array.Copy(readBuffer, 3 + 5 + 5 + 1 + 2 + 2 + 2 + 1 + 5, date, 0, date.Length);
//            run.sampleTime =RealTimeAnalysis.dateAnalisis(date, 0);
//            rest =0;
//            return run;
//        }

//        public int LeftBufferSize
//        {
//            get { throw new NotImplementedException(); }
//        }

//        public IReceiveFilter<BinaryRequestInfo> NextReceiveFilter
//        {
//            get { throw new NotImplementedException(); }
//        }

//        public void Reset()
//        {
//        }

//        public FilterState State
//        {
//            get { throw new NotImplementedException(); }
//        }
//    }
//}
