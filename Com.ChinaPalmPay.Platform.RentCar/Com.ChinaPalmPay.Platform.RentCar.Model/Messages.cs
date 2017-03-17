using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
    [Table(Name = "T_Message")]
    [Serializable]
    public class Messages
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }
        [Column]
        public string userid { get; set; }
        [Column]
        public string content { get; set; }
        [Column]
        public string time { get; set; }
        [Column]
        public string type { get; set; }
    }
}
