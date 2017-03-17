using Com.Chinapalmpay.Component.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace com.chinapalmpay.platform.RentCars.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            LogerHelper.DefaultInfo(this.ToLog4Start());

        }
        public ActionResult Index()
        {
            return View();
        }

    }
}
