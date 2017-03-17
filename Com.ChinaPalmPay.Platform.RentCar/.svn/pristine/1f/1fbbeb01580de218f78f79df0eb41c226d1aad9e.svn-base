using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.IBLLS
{
  public  interface IRealTimeHandler
    {
      RunRealTime uploadRunRealTime(RunRealTime input);
      StopRealTime uploadStopRealTime(StopRealTime input);
      byte[] uploadAuthorization(AuthorizationRequest input);
      OpenOrCloseGateRequest uploadOpenOrCloseGate(OpenOrCloseGateRequest input);
      RunRealTime selectRunReal();
      StopRealTime selectStopReal();
      AuthorizationRequest selectAuthorizationReal();
      //查询车历史轨迹
      IList<RunRealTime> selectAll(string TermId, string begin, string end);
    }
}
