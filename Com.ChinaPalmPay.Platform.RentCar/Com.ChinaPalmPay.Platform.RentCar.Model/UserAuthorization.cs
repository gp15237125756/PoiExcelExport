using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
    [Table(Name = "T_Authorization")]
    [Serializable]
    public class UserAuthorization
    {

        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public string Id { get; set; }
        [Column]
        public string UserId { get; set; }
        [Column]
        public string OrderId { get; set; }
        [Column]
        public int Status { get; set; }
        [Column]
        public string Date { get; set; }
    }
}
