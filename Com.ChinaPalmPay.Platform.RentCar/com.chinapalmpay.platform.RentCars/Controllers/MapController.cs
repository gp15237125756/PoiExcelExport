using Com.ChinaPalmPay.Platform.RentCar.BLLFacs;
using Com.ChinaPalmPay.Platform.RentCar.Common;
using Com.ChinaPalmPay.Platform.RentCar.DALFactory;
using Com.ChinaPalmPay.Platform.RentCar.IBLLS;
using Com.ChinaPalmPay.Platform.RentCar.IDAL;
using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace com.chinapalmpay.platform.RentCars.Controllers
{
    public class MapController : BaseController
    {
        IRealTimeHandler hand = BllAccess.CreateRealTimeService();
        //

        // GET: /Map/ 
        //查询最新车电量的数据，在地图显示
        public ActionResult Map(string TermId)
        {
            if (!String.IsNullOrWhiteSpace(TermId))
            {
                ViewData["TermId"] = TermId;
            }
            return View();
        }
        [HttpGet]
        public ActionResult MapDisplay(string TermId)
        {
            if (TermId != null)
            {
                ViewData["TermId"] = TermId;
                if (RealTimeThread.dic.ContainsKey(TermId))
                {
                    CarInfo info = RealTimeThread.dic[TermId] as CarInfo;
                    CarInfo c = new CarInfo();
                    //经纬度转化为百度地图经纬度 long->float
                    if (info!=null&& info.Latitude!=0&&info.Longitude!=0)
                    {
                        string str = info.Latitude.ToString();
                        int i = int.Parse(str.Substring(0, 2));
                        double j = double.Parse(Convert.ToDouble((double.Parse(str.Substring(2, 2) + "." + str.Substring(4, str.Length - 4)) / 60)).ToString("f7"));
                        c.Latitude = (long)((i + j) * Math.Pow(10, 7));

                        string str2 = info.Longitude.ToString();
                        int m = int.Parse(str2.Substring(0, 3));
                        double n = double.Parse(Convert.ToDouble((double.Parse(str2.Substring(3, 2) + "." + str2.Substring(5, str2.Length - 5)) / 60)).ToString("f7"));
                        c.Longitude = (long)((m + n) * Math.Pow(10, 7));
                    }
                    c.Current = info.Current;
                    c.Mile = info.Mile;
                    c.Power = info.Power;
                    c.Speed = info.Speed;
                    c.Temperature = info.Temperature;
                    c.Voltage = info.Voltage;
                    LogHelper.OutPut(this.Url.RequestContext, c);
                    return Json(c, JsonRequestBehavior.AllowGet);
                }
            }
            LogHelper.OutPut(this.Url.RequestContext, "c为空");
            return Json(null);
        }
        //历史轨迹显示
        public ActionResult history()
        {
            return View();
        }
        [HttpPost]
        public ActionResult history(string TermId,string begin,string end)
        {
            //根据时间和id查询
            if (!String.IsNullOrWhiteSpace(TermId) && !String.IsNullOrWhiteSpace(begin) && !String.IsNullOrWhiteSpace(end))
            {
                ViewData["Id"] = TermId;
                ViewData["begin"] = begin;
                ViewData["end"] = end;
                IList<RunRealTime> l = hand.selectAll(TermId, begin, end);
                if (l.Count() > 0)
                {
                    return Json(l, JsonRequestBehavior.AllowGet);
                }

            }

            return Json(null);
        }
        //有空闲车租赁点查询
        public ActionResult idleStation()
        {

            return View();

        }
    }
}
