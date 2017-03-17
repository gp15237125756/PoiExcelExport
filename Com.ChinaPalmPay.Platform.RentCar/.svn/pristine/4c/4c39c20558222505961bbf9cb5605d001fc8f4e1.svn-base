using Com.ChinaPalmPay.Platform.RentCar.ICacheDependency;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace Com.ChinaPalmPay.Platform.RentCar.CacheDependency
{
    public abstract class TableDependency : IRentCarCacheDependency
    {
        protected char[] configurationSeparator = new char[] {','};
        protected AggregateCacheDependency dependency = new AggregateCacheDependency();

        protected TableDependency(string configKey)
        {
            string dbName = ConfigurationManager.AppSettings["CacheDatabaseName"];
            string tableConfig = ConfigurationManager.AppSettings[configKey];
            string[] tables = tableConfig.Split(configurationSeparator);
            foreach (string tableName in tables)
                dependency.Add(new SqlCacheDependency(dbName, tableName));
        }

        public AggregateCacheDependency GetDependency()
        {
            return dependency;
        }
    }
}
