using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.IDAL
{
  public  interface IRealTimeManager
    {
      RunRealTime AddRunRealTime(RunRealTime run);
      StopRealTime AddStopRealTime(StopRealTime run);
      AuthorizationRequest AddAuthorizationRealTime(AuthorizationRequest run);
      OpenOrCloseGateRequest AddOpenOrCloseGate(OpenOrCloseGateRequest open);
      string[] queryTelByTermiId(string termiId);
      IList<RunRealTime> queryAllLocation(string TermId, string begin, string end);
    }
}
