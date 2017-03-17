using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
    [Table(Name = "T_Order")]
    [Serializable]
    public class Order
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public string ID { get; set; }
        [Column]
        public string UserID { get; set; }
        [Column]
        public string CarID { get; set; }
        [Column]
        public string Time { get; set; }
        [Column]
        public int State { get; set; }
        [Column]
        public string Pubkey { get; set; }
        [Column]
        public string SecKey { get; set; }
        [Column]
        public string CreateTime { get; set; }
        [Column]
        public string Creater { get; set; }
        public string CarType { get; set; }
        public string CarNo { get; set; }
        public string TerminalId { get; set; }
        public string AuthStatus { get; set; }
        public string AuthUserID { get; set; }
        public string AuthDate { get; set; }
        public bool CanAuth { get; set; }
    }
}
