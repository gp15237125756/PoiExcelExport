using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
        [Table(Name = "T_UserRegister")]
        [Serializable]
   public class UserRegister
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        [Column]
        public string UserId { get; set; }
        [Column]
        public string Imei { get; set; }
        [Column]
        public int WlanMac { get; set; }
        [Column]
        public int BtMac { get; set; }
        [Column]
        public int Os { get; set; }
        [Column]
        public int Type { get; set; }
        [Column]
        public string CreateTime { get; set; }
    }
}
