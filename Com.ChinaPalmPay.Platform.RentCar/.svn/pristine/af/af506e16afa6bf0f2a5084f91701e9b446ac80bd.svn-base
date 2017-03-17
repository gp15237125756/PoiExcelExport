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
   public class PayOperations:IPayManager
    {
       public Recharge Addpay(Recharge charge)
        {
                if (charge!=null)
                {
                    using (DataContext db = new SqlserverContext())
                    {
                       
                        Table<Recharge> T_order = db.GetTable<Recharge>();
                        T_order.InsertOnSubmit(charge);
                        db.SubmitChanges();
                        return charge;
                    }
                }
                return null;
        }


       public Com.ChinaPalmPay.Platform.RentCar.Model.Alipay Addalipay(Com.ChinaPalmPay.Platform.RentCar.Model.Alipay ali)
       {
               if (ali != null)
               {
                   using (DataContext db = new SqlserverContext())
                   {

                       Table<Com.ChinaPalmPay.Platform.RentCar.Model.Alipay> T_order = db.GetTable<Com.ChinaPalmPay.Platform.RentCar.Model.Alipay>();
                       T_order.InsertOnSubmit(ali);
                       db.SubmitChanges();
                       return ali;
                   }
               }
               return null;
       }

       public OrderLog Addlog(OrderLog log)
       {
               if (log != null)
               {
                   using (DataContext db = new SqlserverContext())
                   {

                       Table<OrderLog> T_order = db.GetTable<OrderLog>();
                       T_order.InsertOnSubmit(log);
                       db.SubmitChanges();
                       return log;
                   }
               }
               return null;
       }


       public Cup AddCup(Cup charge)
       {
               if (charge != null)
               {
                   using (DataContext db = new SqlserverContext())
                   {

                       Table<Cup> T_order = db.GetTable<Cup>();
                       T_order.InsertOnSubmit(charge);
                       db.SubmitChanges();
                       return charge;
                   }
               }
           return null;
       }
    }
}
