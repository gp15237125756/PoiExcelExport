using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.ChinaPalmPay.Platform.RentCar.Model;

namespace Com.ChinaPalmPay.Platform.RentCar.IDAL
{
    public interface IZSCManager
    {
        //根据地区查询租赁点
        IList<Station> findStation(long id);
        //根据租赁点查询车
        IList<Car> findCar(int id);
        //获取地区列表
        IList<District> findDistrict(string Name);
        //根据CarId查询车
        Car findCarByCarId(string id);
        //查询carStat
        CarStat findCarStat(string userId,string carId);
        //根据充电桩id查询租赁点Station
        Station findStaByPileId(string pile);
        //修改carstat
        CarStat updateCarStat(Order order);
        //还车后增加车状态履历
        CarStat addCarStat(OrderLog order);

    }
}
