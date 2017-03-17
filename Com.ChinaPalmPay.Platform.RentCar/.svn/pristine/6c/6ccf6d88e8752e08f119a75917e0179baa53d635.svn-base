using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
    [Table(Name = "C_RunRealTime")]
    [Serializable]
    public class RunRealTime:IRequestInfo
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public Guid Id { get; set; }
        [Column]
        public string TerminalId { get; set; }
        [Column]
        public long latitude { get; set; }
        [Column]
        public long longitude { get; set; }
        [Column]
        //电池信息
        public int batteryInfo { get; set; }
        [Column]
        //电量信息
        public int voltage { get; set; }
        [Column]
        //电流
        public int current { get; set;}
        [Column]
        //温度
        public int Temper { get; set; }
        [Column]
        //门状态
        public int beforeGateStatus { get; set; }
        [Column]
        //门状态
        public int behindGateStatus { get; set; }
        [Column]
        //速度
        public long speed { get; set; }
        [Column]
        //速度
        public long mile { get; set; }
        [Column]
        //时间
        public string sampleTime { get; set; }

        public string Key
        {
            get { throw new NotImplementedException(); }
        }
    }
}
