using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.ChinaPalmPay.Platform.RentCar.ICacheDependency;
using System.Configuration;
using System.Reflection;

namespace Com.ChinaPalmPay.Platform.RentCar.CacheDependencyFactory
{
    class DependencyAccess
    {
        /// <summary>
        /// Method to create an instance of Category dependency implementation
        /// </summary>
        /// <returns>Category Dependency Implementation</returns>
        public static IRentCarCacheDependency CreateUserRegDependency()
        {
            return LoadInstance("UserRegist");
        }
        public static IRentCarCacheDependency CreateStationSelDependency()
        {
            return LoadInstance("SelectStation");
        }
        public static IRentCarCacheDependency CreateCarSelDependency()
        {
            return LoadInstance("SelectCar");
        }
        public static IRentCarCacheDependency CreateDistrictSelDependency()
        {
            return LoadInstance("SelectDistrict");
        }
        public static IRentCarCacheDependency CreateOrderCreateDependency()
        {
            return LoadInstance("CreateOrder");
        }

        public static IRentCarCacheDependency CreateOrderSelectDependency()
        {
            return LoadInstance("SelectOrder");
        }
        public static IRentCarCacheDependency CreateSelectUserInfoDependency()
        {
            return LoadInstance("SelectUserInfo");
        }
        public static IRentCarCacheDependency CreateSelectCarByIdDependency()
        {
            return LoadInstance("SelectCarById");
        }
        public static IRentCarCacheDependency CreateSelectOpenIdDependency()
        {
            return LoadInstance("SelectOpenId");
        }

        /// <summary>
        /// Common method to load dependency class from information provided from configuration file 
        /// </summary>
        /// <param name="className">Type of dependency</param>
        /// <returns>Concrete Dependency Implementation instance</returns>
        private static IRentCarCacheDependency LoadInstance(string className)
        {

            string path = ConfigurationManager.AppSettings["CacheDependencyAssembly"];
            string fullyQualifiedClass = path + "." + className;
            // Using the evidence given in the config file load the appropriate assembly and class
            return (IRentCarCacheDependency)Assembly.Load(path).CreateInstance(fullyQualifiedClass);
        }
    }
}
