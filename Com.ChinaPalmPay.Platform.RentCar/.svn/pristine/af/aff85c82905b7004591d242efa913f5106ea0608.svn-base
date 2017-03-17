using Com.ChinaPalmPay.Platform.RentCar.BLLFacs;
using Com.ChinaPalmPay.Platform.RentCar.IBLLS;
using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace com.chinapalmpay.platform.RentCars.Controllers
{
    public class ActiveMapController : BaseController
    {
        //
        // GET: /ActiveMap/
        private static readonly ITerminalLiveHandler orderbll = BllAccess.CreateTerminalLiveService();
        public IList<RunRealTime> Live()
        {
            //返回当前所有在线终端
            return orderbll.QueryLive();
        }
        public IList<Station> Idle()
        {
            //返回当前所有在线终端
            return orderbll.QueryIdle();
        }
    }
}
