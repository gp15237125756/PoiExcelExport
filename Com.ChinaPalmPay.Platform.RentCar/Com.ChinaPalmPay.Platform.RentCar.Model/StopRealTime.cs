using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
    [Table(Name = "C_StopRealTime")]
    [Serializable]
    public class StopRealTime
    {
        //终端id
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public Guid Id { get; set; }
        [Column]
        public string TerminalId { get; set; }
        //以下电池信息
        [Column]
        public string Power { get; set; }
        [Column]
        public string Voltage { get; set; }
        [Column]
        public string Current { get; set; }
        [Column]
        public string Temperature { get; set; }


    }
}
