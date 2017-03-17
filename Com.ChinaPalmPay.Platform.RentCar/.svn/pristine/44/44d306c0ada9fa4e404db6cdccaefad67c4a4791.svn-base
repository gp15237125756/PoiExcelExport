using Com.ChinaPalmPay.Platform.RentCar.Model.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace com.chinapalmpay.platform.RentCars.Controllers
{
    public class PilesController : Controller
    {
        //
        // GET: /Pile/

        public ActionResult Run()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Run(PilesRun Run)
        {
            ViewData["id"] = Run.id;
            ViewData["tarid"] = Run.tarid;
            ViewData["type"] = Run.type;
            return View();
        }

        public ActionResult State()
        {
            return View();
        }
        [HttpPost]
        public ActionResult State(PilesState Run)
        {
            ViewData["id"] = Run.id;
            ViewData["state"] = Run.state;
            return View();
        }
    }
}
