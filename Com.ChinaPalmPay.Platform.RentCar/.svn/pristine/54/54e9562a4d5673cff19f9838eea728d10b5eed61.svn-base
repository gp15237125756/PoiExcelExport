using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace Com.ChinaPalmPay.Platform.RentCar.CacheDependencyFactory
{
    //**得到全部用户注册缓存数据表**
  public  class DependencyFacade
    {
        private static readonly string path = ConfigurationManager.AppSettings["CacheDependencyAssembly"];

        public static AggregateCacheDependency GetUserRegistDependency()
        {
            if (!string.IsNullOrEmpty(path))
                return DependencyAccess.CreateUserRegDependency().GetDependency();
            else
                return null;
        }

        public static AggregateCacheDependency GetStationSelDependency()
        {
            if (!string.IsNullOrEmpty(path))
                return DependencyAccess.CreateStationSelDependency().GetDependency();
            else
                return null;
        }

        public static AggregateCacheDependency GetCarSelDependency()
        {
            if (!string.IsNullOrEmpty(path))
                return DependencyAccess.CreateCarSelDependency().GetDependency();
            else
                return null;
        }
        public static AggregateCacheDependency GetDistrictSelDependency()
        {
            if (!string.IsNullOrEmpty(path))
                return DependencyAccess.CreateDistrictSelDependency().GetDependency();
            else
                return null;
        }

        public static AggregateCacheDependency GetOrderCreateDependency()
        {
            if (!string.IsNullOrEmpty(path))
                return DependencyAccess.CreateOrderCreateDependency().GetDependency();
            else
                return null;
        }
        public static AggregateCacheDependency GetOrderSelDependency()
        {
            if (!string.IsNullOrEmpty(path))
                return DependencyAccess.CreateOrderSelectDependency().GetDependency();
            else
                return null;
        }
        public static AggregateCacheDependency GetUserInfoSelDependency()
        {
            if (!string.IsNullOrEmpty(path))
                return DependencyAccess.CreateSelectUserInfoDependency().GetDependency();
            else
                return null;
        }
        public static AggregateCacheDependency GetSelCarByIdDependency()
        {
            if (!string.IsNullOrEmpty(path))
                return DependencyAccess.CreateSelectCarByIdDependency().GetDependency();
            else
                return null;
        }
        public static AggregateCacheDependency GetSelOpenIdDependency()
        {
            if (!string.IsNullOrEmpty(path))
                return DependencyAccess.CreateSelectOpenIdDependency().GetDependency();
            else
                return null;
        }
    }
}
