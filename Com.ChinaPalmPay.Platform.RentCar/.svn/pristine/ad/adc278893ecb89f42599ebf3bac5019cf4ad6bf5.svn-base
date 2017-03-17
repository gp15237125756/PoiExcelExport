using Com.ChinaPalmPay.Platform.RentCar.Common;
using Com.ChinaPalmPay.Platform.RentCar.IDAL;
using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.SQLServer
{
    public class IdleCarManager : IIdleCarManager
    {
        public IList<Station> queryIdleStation()
        {
            IList<Station> stations = new List<Station>();
            //查询有空闲车的租赁点
                using (DataContext db = new SqlserverContext())
                {
                    Table<Station> T_Station = db.GetTable<Station>();
                    Table<Car> T_Car = db.GetTable<Car>();
                    Table<Piles> T_Piles = db.GetTable<Piles>();
                    Table<CarStat> T_CarStat = db.GetTable<CarStat>();
                    IList<Station> allStation = T_Station.ToList<Station>();
                    if (allStation != null && allStation.Count() > 0)
                    {
                        foreach (var i in allStation)
                        {
                            IList<Piles> allPiles = T_Piles.Where<Piles>(o => o.StationID == i.id).ToList<Piles>();
                            if (allPiles != null && allPiles.Count() > 0)
                            {
                                foreach (var m in allPiles)
                                {
                                    CarStat stat = T_CarStat.Where<CarStat>(o => o.PilesID == m.id).OrderByDescending(x => x.CreateTime).First();
                                    if (stat != null && stat.stat == (int)Commons.CatStatus.idle)
                                    {
                                        stations.Add(i);
                                        break;
                                    }
                                }

                            }
                        }
                    }
                }
             
            return stations;
        }
    }
}
