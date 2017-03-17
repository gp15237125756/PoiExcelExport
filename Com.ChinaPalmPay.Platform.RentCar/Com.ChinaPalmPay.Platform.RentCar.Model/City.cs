using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
    [Table(Name = "S_City")]
    [Serializable]
   public class City
    {
         [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long CityID { get; set; }
         [Column]
         public string CityName { get; set; }
         [Column]
         public string ZipCode { get; set; }
         [Column]
         public long ProvinceID { get; set; }
         [Column]
         public DateTime DateCreated { get; set; }
         [Column]
         public DateTime DateUpdated { get; set; }
    }
}
