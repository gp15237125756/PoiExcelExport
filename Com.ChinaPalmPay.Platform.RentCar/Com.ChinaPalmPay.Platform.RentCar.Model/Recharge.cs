using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
    [Table(Name = "T_RentCarPlatformLog")]
    [Serializable]
   public class Recharge
    {
         [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public string ID { get; set; }
         [Column]
         public string UserID { get; set; }
         [Column]
         public string OrderID { get; set; }
         [Column]
         public int Amount { get; set; }
         [Column]
         public int Type { get; set; }
         [Column]
         public string Remark { get; set; }
         [Column]
         public string CreateTime { get; set; }
         [Column]
         public string Creater { get; set; }
         [Column]
         public string PayOrderID { get; set; }
    }
}
