using Com.ChinaPalmPay.Platform.RentCar.Common;
using Com.ChinaPalmPay.Platform.RentCar.DALFactory;
using Com.ChinaPalmPay.Platform.RentCar.IBLLS;
using Com.ChinaPalmPay.Platform.RentCar.IDAL;
using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.BLL
{
    public class TerminalLiveHandler : ITerminalLiveHandler
    {
        private static readonly IIdleCarManager idle_manager = DataAccess.CreatIdleCarDbManager();
        public IList<RunRealTime> QueryLive()
        {
          //查询在线终端
           return TerminalRealTimeInspector.CreateInstance().currentActiveUsers();
        }

        //有空闲车租赁点地图显示
        public IList<Station> QueryIdle()
        {
           //返回空闲车辆所在租赁点坐标
            //1.查询车辆状态表，status=1的车为空闲
            IList<Station> lists=idle_manager.queryIdleStation();
            return lists;
        }
    }
}
