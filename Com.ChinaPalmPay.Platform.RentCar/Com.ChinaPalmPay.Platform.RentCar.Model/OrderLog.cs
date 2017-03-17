using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
    [Table(Name = "T_OrderLog")]
    [Serializable]
  public  class OrderLog
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        [Column]
        public string OrderID { get; set; }
        [Column]
        public string UserID { get; set; }
        [Column]
        public string CarID { get; set; }
        [Column]
        public string Time { get; set; }
        [Column]
        public int State { get; set; }
        [Column]
        public string Remark { get; set; }
        [Column]
        public string CreateTime { get; set; }
    }
}
