using Com.Chinapalmpay.Component.Log;
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
    public class RealTimeManager : IRealTimeManager
    {
        public RunRealTime AddRunRealTime(RunRealTime run)
        {
            if (run != null)
            {
                using (DataContext db = new SqlserverContext())
                {
                    Table<RunRealTime> T_order = db.GetTable<RunRealTime>();
                    T_order.InsertOnSubmit(run);
                    db.SubmitChanges();
                    return run;
                }

            }

            return null;
        }

        public StopRealTime AddStopRealTime(StopRealTime run)
        {
            if (run != null)
            {
                using (DataContext db = new SqlserverContext())
                {
                    Table<StopRealTime> T_order = db.GetTable<StopRealTime>();
                    T_order.InsertOnSubmit(run);
                    db.SubmitChanges();
                    return run;
                }

            }

            return null;
        }

        public AuthorizationRequest AddAuthorizationRealTime(AuthorizationRequest run)
        {
            if (run != null)
            {
                using (DataContext db = new SqlserverContext())
                {
                    Table<AuthorizationRequest> T_order = db.GetTable<AuthorizationRequest>();
                    T_order.InsertOnSubmit(run);
                    db.SubmitChanges();
                    return run;
                }

            }

            return null;
        }

        public OpenOrCloseGateRequest AddOpenOrCloseGate(OpenOrCloseGateRequest open)
        {
            if (open != null)
            {
                using (DataContext db = new SqlserverContext())
                {
                    Table<OpenOrCloseGateRequest> T_order = db.GetTable<OpenOrCloseGateRequest>();
                    T_order.InsertOnSubmit(open);
                    db.SubmitChanges();
                    return open;
                }

            }

            return null;
        }

        //只有订单在预约和已经使用状态才能下发
        public string[] queryTelByTermiId(string termiId)
        {
            OrderEx order = null;
            if (termiId != null)
            {
                using (DataContext db = new SqlserverContext())
                {
                    Table<Car> T_car = db.GetTable<Car>();
                    Table<Order> T_order = db.GetTable<Order>();
                    Table<CarStat> T_Stat = db.GetTable<CarStat>();
                    Car car = T_car.FirstOrDefault<Car>(o => o.TermID.Equals(termiId));
                    if (car != null)
                    {
                        order = (from m in T_order
                                 join n in T_Stat on m.CarID equals n.CarID
                                 where m.CarID == car.id && (n.stat == (int)Commons.CatStatus.book
                                 || n.stat == (int)Commons.CatStatus.run) && (m.State == (int)Commons.Type.BOOK || m.State == (int)Commons.Type.USING)
                                 orderby n.CreateTime descending
                                 select new OrderEx
                                 {
                                     CarID = m.CarID,
                                     ID = m.ID,
                                     State = m.State,
                                     UserID = m.UserID,
                                 }).FirstOrDefault();
                        if (order != null)
                        {
                            return new string[] { order.UserID, order.CarID };
                        }


                    }
                }
            }
            return null;
        }


        public IList<RunRealTime> queryAllLocation(string TermId, string begin, string end)
        {
            IList<RunRealTime> lists = new List<RunRealTime>();
            if (!String.IsNullOrWhiteSpace(TermId) && !String.IsNullOrWhiteSpace(begin) && !String.IsNullOrWhiteSpace(end))
            {
                using (DataContext db = new SqlserverContext())
                {
                    Table<RunRealTime> T_Run = db.GetTable<RunRealTime>();
                    lists = (from c in T_Run
                             where c.TerminalId == TermId && ((int.Parse(c.sampleTime) > int.Parse(begin)) && (int.Parse(c.sampleTime) < int.Parse(end)))
                             select c).ToList() as IList<RunRealTime>;
                }
            }
            return lists;
        }
    }
}
