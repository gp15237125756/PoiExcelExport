using RentCars.com.chinapalmpay.StationManager;
using RentCars.Constrols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCars.Controllers
{
    public class StationController : BaseController
    {
         IStationManager    STATION_MANAGER;
         public StationController(IStationManager STATION_MANAGER)
        {
            this.STATION_MANAGER = STATION_MANAGER;
        }
        //
        // GET: /Location/

        public ActionResult AddStation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStation(Station station)
        {
            Station Station=STATION_MANAGER.createStation(station);
            ViewData["STATIONS"] = Station;
            return View();
        }
        public ContentResult SelectStation()
        {
            var Content=new ContentResult(); 
            IEnumerable<Station> stations=STATION_MANAGER.selectStation();
            Content.Content = stations.ToString();
            return Content;
        }
    }
}
