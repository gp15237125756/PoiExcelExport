using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
  public  class NFCAccept
    {
      public string TerminalId { get; set; }
      public string FirstTelephone { get; set; }
      public string RewardTelephone { get; set; }
      public string Key1 { get; set; }
      public string Key2 { get; set; }
      public string AuthorizationStatus { get; set; }
      public string SampleTime { get; set; }
    }
}
