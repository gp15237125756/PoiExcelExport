using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
    [Table(Name = "T_CarStat")]
    [Serializable]
    public class CarStat
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public string id { get; set; }
        [Column]
        public string UserID { get; set; }
        [Column]
        public string CarID { get; set; }
        [Column]
        public int stat{ get; set; }
        [Column]
        public int PilesID { get; set; }
        [Column]
        public string CreateTime { get; set; }


    }
}
