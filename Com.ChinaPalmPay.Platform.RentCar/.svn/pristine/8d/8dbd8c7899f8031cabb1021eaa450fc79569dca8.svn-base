using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.ChinaPalmPay.Platform.RentCar.Model;

namespace Com.ChinaPalmPay.Platform.RentCar.IBLLS
{
   public interface IZSCHandler
    {
        //根据地区查询租赁点
        IList<Station> findStationHandler(long zone);
        //根据租赁点查询车
        IList<Car> findCarHandler(int id);
        //获取地区列表
        IList<District> findZoneHandler(string cityName);
        //根据车id查询车
        Car findCarByIdHandler(string id);
    }
}
