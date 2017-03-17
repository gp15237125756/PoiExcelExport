using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
    [Table(Name = "S_District")]
    [Serializable]
    public class District
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public long DistrictID { get; set; }
        [Column]
        public string DistrictName { get; set; }
        [Column]
        public long CityID { get; set; }
        [Column]
        public Nullable<DateTime> DateCreated { get; set; }
        [Column]
        public Nullable<DateTime> DateUpdated { get; set; }
    }
}
