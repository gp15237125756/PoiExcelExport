using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Com.ChinaPalmPay.Platform.RentCar.DataProx;
namespace com.chinapalmpay.platform.RentCars
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            string path = Server.MapPath("~/log4net.config");
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(path);
            log4net.Config.XmlConfigurator.Configure(fileInfo);
            //new Program().Work();
        }
    }
}