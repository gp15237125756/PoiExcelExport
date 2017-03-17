using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
   public class CarInfo
    {
   
       //电量
       public  int Power { get; set; }
       //电压
       public  int Voltage { get; set; }
       //电流
       public  int Current { get; set; }
       //温度
       public  int Temperature { get; set; }
       //经度
       public  long Longitude { get; set; }
       //纬度
       public  long Latitude { get; set; }
       //车速
       public  long Speed { get; set; }
       //公里数
       public  long Mile { get; set; }
    }
}
