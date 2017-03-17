using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.ChinaPalmPay.Platform.RentCar.IBLLS;
using Com.ChinaPalmPay.Platform.RentCar.Model;
using Com.ChinaPalmPay.Platform.RentCar.IDAL;
using Com.ChinaPalmPay.Platform.RentCar.DALFactory;

namespace Com.ChinaPalmPay.Platform.RentCar.BLL
{
    //本接口负责管理租赁点，地区，车辆查询
    public class ZSCHandlers : IZSCHandler
    {
        IZSCManager zscManager = DataAccess.CreateZSCCacheManager();
        //根据地区查询租赁点
        //根据租赁点查询车

        public IList<Station> findStationHandler(long zoneid)
        {
                return zscManager.findStation(zoneid);
        }

        public IList<Car> findCarHandler(int id)
        {
            if (!String.IsNullOrWhiteSpace(id.ToString()))
            {
                return zscManager.findCar(id);
            }
            return null;
        }
        public IList<District> findZoneHandler(string CityName)
        {
            if (!String.IsNullOrWhiteSpace(CityName))
            {
                return zscManager.findDistrict(CityName);
            }
            return null;
        }



        public Car findCarByIdHandler(string id)
        {
           if(!String.IsNullOrWhiteSpace(id)){
              return zscManager.findCarByCarId(id);
           }
               return null;
        }


    }
}
