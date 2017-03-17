using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.IDAL
{
  public  interface IOrderManager
    {
        Order Create(Order order);
        //增加授权履历
        UserAuthorization Add(UserAuthorization auth);
        IList<Order> Select(string userid);
        int SelectNum(string userid);
        bool cancelOrder(string orderid);
        Order QueryOrder(string orderId);
      //视图查询余额
        double QueryMoney(string id);
      //增加订单消息
        Messages AddMsg(Messages msg);
        Order SelectOrder(string userId,string orderId);
      //查询扣款履历
        IList<Recharge> queryRecharge(string userId, string orderId);
      //修改订单状态为已经使用
        Order updateStatus(Order order);
      //根据用户id查询当前是否存在有效订单
        bool queryValidOrderById(string userId);
      //判断当前订单是否已经授权
        bool AuthorizeOrNot(string orderId);
      //撤销授权
        bool cancelAuth(string userId,string Order);
      //修改订单状态为开门状态
        bool updateToOpenDoor(string userId);
        
      
        
    }
}
