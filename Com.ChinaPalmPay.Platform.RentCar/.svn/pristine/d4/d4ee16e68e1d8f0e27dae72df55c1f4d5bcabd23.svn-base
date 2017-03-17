using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace com.chinapalmpay.platform.RentCars
{
    public static class ObjectHelper
    {
        public static string ToJsonString(this object obj) {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

            return jsonSerializer.Serialize(obj);
        }

        public static string ToLog4Start(this Controller controller) {

            UrlHelper url = controller.Url;
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