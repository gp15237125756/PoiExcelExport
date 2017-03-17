using RentCars.com.chinapalmpay.LogService;
using RentCars.com.chinapalmpay.UserManager;
using RentCars.com.chinapalmpay.utils;
using RentCars.Common;
using RentCars.Constrols;
using RentCars.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentCars.Controllers
{
    public class RentCarController : BaseController
    {
        //
        // GET: /RentCar/
        //注入租车接口
        IUser user;
        IUserManager User_Manager;
        ILogService _logService;
        public RentCarController(IUser user, IUserManager User_Manager, ILogService _logService)
        {
            this.user = user;
            this.User_Manager=User_Manager;
            this._logService = _logService;
        }
        public ActionResult Rent(string userId,string carId,string orderTime)
        {
            try
            {
                //生成租车订单
                if (!(String.IsNullOrWhiteSpace(userId)) && !(String.IsNullOrWhiteSpace(carId)))
                {
                    User info = new User();
                    User userbase = User_Manager.selectUser(info);
                    //判断是否有租车权限，没有则跳转到其他页面
                    if (Commons.NORMAL_USER.Equals(userbase.PhoneNumber) || Commons.COMPANY_USER.Equals(userbase.CardPath))
                    {
                   // user.rentCar(userbase, carId, orderTime);
                        //输出订单记录
                    Log order = new Log();
                    _logService.AddLog(order);
                     }
                }

            }
            catch { 
            
            
            }
            return View();
        }

    }
}
