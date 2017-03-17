using Com.ChinaPalmPay.Platform.RentCar.IProfileDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.ProfileFactory
{
    public sealed class DataAccess
    {

        private static readonly string profilePath = ConfigurationManager.AppSettings["ProfileDAL"];

        public static IRentCarProfileProvider CreateRentCarProfileProvider()
        {
            string className = profilePath + ".RentCarProfileProvider";
            return (IRentCarProfileProvider)Assembly.Load(profilePath).CreateInstance(className);
        }
    }
}
