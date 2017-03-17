using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Common
{
    public class OrderIdUtil
    {
        public static string create()
        {
            StringBuilder sb = new StringBuilder();
            Random ran = new Random();
            return sb.Append("MDLB").Append(string.Format("{0:yyyyMMddHHmmssfff}",DateTime.Now)).Append(ran.Next(10)).Append(ran.Next(10)).Append(ran.Next(10)).ToString();
        }
    }
}
