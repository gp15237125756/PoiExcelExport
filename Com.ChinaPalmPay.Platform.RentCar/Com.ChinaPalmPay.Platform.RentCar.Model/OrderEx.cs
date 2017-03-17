using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
    [Serializable]
    public class OrderEx
    {
        public string ID { get; set; }

        public string UserID { get; set; }

        public string CarID { get; set; }

        public string Time { get; set; }

        public int State { get; set; }

        public string Pubkey { get; set; }

        public string SecKey { get; set; }

        public string CreateTime { get; set; }

        public string Creater { get; set; }
        public string CarType { get; set; }
        public string CarNo { get; set; }
        public string TerminalId { get; set; }
        public string AuthStatus { get; set; }
        public string AuthUserID { get; set; }
        public string AuthDate { get; set; }
        public bool CanAuth { get; set; }
    }
}
