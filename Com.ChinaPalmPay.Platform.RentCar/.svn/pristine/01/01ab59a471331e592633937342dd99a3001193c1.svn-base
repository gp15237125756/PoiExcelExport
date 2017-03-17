using Com.Chinapalmpay.Component.Log;
using Com.ChinaPalmPay.Platform.RentCar.Model.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace com.chinapalmpay.platform.RentCars.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
           
            base.Initialize(requestContext);
          
        }
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            string log = this.ToLog4Start();
            base.OnAuthorization(filterContext);
            LogerHelper.DefaultInfo(log);
        }
        protected override void EndExecute(IAsyncResult asyncResult)
        {
            if (asyncResult.IsCompleted)
            {
                
            }

            base.EndExecute(asyncResult);
        }


        protected override void OnException(ExceptionContext filterContext)
        {
            string log = this.ToLog4Start();
            base.OnException(filterContext);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

        public ActionResult Index(string id, string tt)
        {
            //int i = 0;
            //int p = 100 / i;
            return Content(this.ToLog4Start());
        }


        private string Test(UrlHelper url)
        {

            

            System.Text.StringBuilder log = new System.Text.StringBuilder();
            log.AppendFormat(@"{0}/{1}:", url.RequestContext.RouteData.Values["controller"], url.RequestContext.RouteData.Values["action"]);

            foreach (string key in url.RequestContext.HttpContext.Request.QueryString)
            {
                log.AppendFormat(@"[{0}:{1}]", key, url.RequestContext.HttpContext.Request.QueryString[key]);
            }
            foreach (string key in url.RequestContext.HttpContext.Request.Form)
            {
                log.AppendFormat(@"[{0}:{1}]", key, url.RequestContext.HttpContext.Request.Form[key]);
            }

            return log.ToString();
        }



    }
}
