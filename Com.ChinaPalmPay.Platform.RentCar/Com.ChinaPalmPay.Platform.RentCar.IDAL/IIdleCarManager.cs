using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.IDAL
{
    public interface IIdleCarManager
    {
        //return 有空闲车辆租赁点
        IList<Station> queryIdleStation();
    }
}
