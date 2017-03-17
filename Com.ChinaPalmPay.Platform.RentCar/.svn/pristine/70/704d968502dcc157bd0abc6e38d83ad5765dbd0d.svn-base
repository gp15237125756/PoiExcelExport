using Com.Chinapalmpay.Component.Log;
using Com.ChinaPalmPay.Platform.RentCar.Common;
using Com.ChinaPalmPay.Platform.RentCar.DALFactory;
using Com.ChinaPalmPay.Platform.RentCar.IBLLS;
using Com.ChinaPalmPay.Platform.RentCar.IDAL;
using Com.ChinaPalmPay.Platform.RentCar.IMessaging;
using Com.ChinaPalmPay.Platform.RentCar.MessagingFactory;
using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.BLL
{
    public class OrderHandler : IOrderHandler
    {
        private static readonly int Amounts = int.Parse(ConfigurationManager.AppSettings["UserAmount"]);
        private static readonly IOrderManager cache_manager = DataAccess.CreateOrderCacheManager();
        private static readonly IOrderManager db_manager = DataAccess.CreateOrderDbManager();
        private static readonly IZSCManager zsc_manager = DataAccess.CreateZSCDbManager();
        private static readonly IOrderMsmq msmq_manager = QueueAccess.CreateOrder();
        private static readonly IUserManager UserDb_manager = DataAccess.CreateUserDbManager();
        public Order createOrder(Order order, out string Msg)
        {
            if (order.UserID != null && order.Time != null && !String.IsNullOrWhiteSpace(order.CarID))
            {

                //用户是否审核
                User user=UserDb_manager.findUserId(order.UserID);
                if(user!=null){
                    if (!user.UserStatus.Equals(((int)(Commons.Authentication.APPLY)).ToString()))
                    {
                        //用户未审核
                        Msg = "用户审核中，不能预约";
                        return null;
                    }

                }
                //如果有预约订单，不能再次创建
                IList<Order> ORDER = db_manager.Select(order.UserID);
                if (ORDER.Count() > 0)
                {
                    foreach (var x in ORDER)
                    {
                        if (x.State == (int)Commons.Type.BOOK)
                        {
                            Msg = "存在已预约订单,不能重复预约";
                            return null;
                        }
                    }
                }

                //如果用户账户余额低于500，不能租车
                if (db_manager.QueryMoney(order.UserID) < 1)
                {
                    Msg = "账户余额不足,请充值";
                    return null;
                }

                order.ID = OrderIdUtil.create();
                order.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                order.State = (int)Commons.Type.BOOK;
                //生成公私钥
                //RSAHelper.RSAKey(secKey, pubKey);
                string pubKey = null, secKey = null;
                RSAHelper.GenerateRSAKey(out secKey, out pubKey);
                order.Pubkey = pubKey;
                order.SecKey = secKey;
                order.Creater = Commons.orderHandler.USER.ToString();
                Car c = zsc_manager.findCarByCarId(order.CarID);
                if (c != null)
                {
                    order.TerminalId = c.TermID;
                    order.CarType = c.CarType;
                    order.CarNo = c.CarNo;
                }
                UserAuthorization auth = new UserAuthorization();
                auth.Id = Guid.NewGuid().ToString().Replace("-", "");
                auth.OrderId = order.ID;
                auth.UserId = order.UserID;
                auth.Status = (int)Commons.Authorized.BASED;
                auth.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //1.发送到消息队列 2.存入缓存
                // cache_manager.Create(order);
                msmq_manager.Send(order);
                msmq_manager.SendUserAuth(auth);
                string type = null;
                string carNo = null;
                Car CAR = zsc_manager.findCarByCarId(order.CarID);
                if (c != null)
                {
                    type = CAR.CarType;
                    carNo = CAR.CarNo;
                }
                Messages msg = new Messages()
                {
                    userid = order.UserID,
                    content = new StringBuilder().
                        Append(Commons.orderMsg1)
                        .Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).
                        Append(Commons.orderMsg2).
                        Append(type).
                        Append(Commons.orderMsg3).Append(carNo).Append(Commons.orderMsg4).ToString(),
                    time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    type = Convert.ToInt32(Commons.MessagesType.serviceType).ToString()
                };
                db_manager.AddMsg(msg);
                //修改车状态
                Msg = "预约成功";
                return order;
            }
            Msg = "预约失败";
            return null;
        }


        public IList<Order> selectOrder(string userId)
        {
            if (!String.IsNullOrWhiteSpace(userId))
            {
                return cache_manager.Select(userId);
            }
            return null;
        }

        public bool cancelOrder(string orderId)
        {
            if (!String.IsNullOrWhiteSpace(orderId))
            {
                bool result = db_manager.cancelOrder(orderId);
                if (result)
                {
                    return true;
                }
                return false;
            }
            return false;
        }


        public int selectOrderNum(string userId)
        {
            if (!String.IsNullOrWhiteSpace(userId))
            {
                int result = db_manager.SelectNum(userId);
                return result;
            }
            return 0;
        }


        public Station queryLocation(string carId, string userId)
        {
            //根据车id查询租赁点位置
            //1.找到充电桩
            //2.找到租赁点
            CarStat carstat = zsc_manager.findCarStat(carId, userId);
            if (carstat != null)
            {
                return zsc_manager.findStaByPileId(carstat.PilesID.ToString()); ;
            }

            return null;
        }

        public bool OrderAuthorization(string UserId, string OrderId, string Telphone, out string msg)
        {
            //1.判断当前用户能否给别人授权
            User user = UserDb_manager.queryBeAutho(Telphone);
            if (user == null)
            {
                msg = "被授权用户没有通过审核,授权失败";
                return false;
            }
            if (UserId.Equals(user.UserId))
            {
                msg = "被授权用户不能是自己,授权失败";
                return false;
            }
            //根据用户id查询当前是否存在有效订单
            if (db_manager.queryValidOrderById(user.UserId))
            {
                msg = "被授权用户已经存在有效订单,授权失败";
                return false;
            }
            if (!db_manager.queryValidOrderById(UserId))
            {
                msg = "授权用户当前不存在有效订单,授权失败";
                return false;
            }
            //是否已经授权过
            if (!db_manager.AuthorizeOrNot(OrderId))
            {
                msg = "授权用户已经授权,授权失败";
                return false;
            }
            //----------可以执行授权-----------
            UserAuthorization userAuth = new UserAuthorization();
            userAuth.Id = Guid.NewGuid().ToString().Replace("-", "");
            userAuth.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            userAuth.OrderId = OrderId;
            //此处是被授权用户Id
            userAuth.UserId = user.UserId;
            userAuth.Status = (int)Commons.Authorized.AUTHORIZE;
            //2.增加授权履历
            db_manager.Add(userAuth);
            msg = "用户授权成功";
            return true;
        }


        public bool cancelAuthorization(string UserId, string OrderId)
        {
            //2.验证该订单是否已经使用
            return db_manager.cancelAuth(UserId, OrderId);
        }
    }
}
