using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
      [Table(Name = "T_UserLogin")]
      [Serializable]
    public class UserLogin
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        [Column]
        public string LoginID { get; set; }
        [Column]
        public string LoginPwd { get; set; }
        [Column]
        public int type { get; set; }
        [Column]
        public string UserId { get; set; }
        [Column]
        public string CreateTime { get; set; }
        [Column]
        public string UpdateTime { get; set; }
    }
}
