using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{

    [Table(Name = "T_Car")]
    [Serializable]
    public class Car
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public string id { get; set; }
        [Column]
        public string TermID { get; set; }
        [Column]
        public string CarNo { get; set; }
        [Column]
        public string CarFac { get; set; }
        [Column]
        public string CarType { get; set; }
        [Column]
        public string CarVolume { get; set; }
        [Column]
        public string CarCharge { get; set; }
        [Column]
        public string CarStartDate { get; set; }
        [Column]
        public string CreateTime { get; set; }
        [Column]
        public string UpdateTime { get; set; }
        public string lastUsedTime { get; set; }
        public string miles { get; set; }
    }
}
