using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
    //该类是更新车辆实时数据
    public class RealTimeThread
    {
        private static RealTimeThread _instance = null;
        //key-车Id
        public  static Dictionary<string, CarInfo> dic = new Dictionary<string, CarInfo>();
        private static readonly object locks = new object();
        private RealTimeThread()
        {

        }
        //线程安全的同步锁
        public static RealTimeThread CreateInstance()
        {
            if (_instance == null)
            {
                lock (locks)
                {
                    if (_instance == null)
                        _instance = new RealTimeThread();
                }
            }
            return _instance;
        }
    }
}
