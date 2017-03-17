using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
    [Table(Name = "T_Station")]
    [Serializable]
   public class Station
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public string Addr { get; set; }
        [Column]
        public string ZoneID { get; set; }
        [Column]
        public int state { get; set; }
        [Column]
        public int Longitude { get; set; }
        [Column]
        public int Latitude { get; set; }
        [Column]
        public string CreateTime { get; set; }
        [Column]
        public string UpdateTime { get; set; }

    }
}
