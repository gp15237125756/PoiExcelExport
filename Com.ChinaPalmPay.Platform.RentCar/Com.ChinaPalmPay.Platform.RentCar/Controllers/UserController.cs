
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using Com.ChinaPalmPay.Platform.RentCar.Model;
namespace RentCars.Controllers.UserControllers
{
    public class UserController 
    {
        public ActionResult Regist(string ReturnUrl)
        {
            ViewBag.returnurl = ReturnUrl;
            return ViewResult();
        }
        [HttpPost]
        public JsonResult Regist(UserLogin infos)
        {
            var json = new JsonResult();
            try
            {
                //判断是普通用户
                if (String.IsNullOrWhiteSpace(infos.LoginID) || String.IsNullOrWhiteSpace(infos.LoginPwd))
                {
                    //注册信息不全,返回json字符串{‘’：‘’}
                    json.Data = new UserRegResult() { Code = "00", Response = "00", Data = "00", Message = "输入参数不全" };
                    //账号：11位数字
                    //密码：以字母开头，长度在6~18之间，只能包含字符、数字和下划线。
                }
                //else if (!(Regex.IsMatch(info.Telephone,@"^[0-9]{11}$")&&Regex.IsMatch(info.Password,@"^[0-9a-zA-Z]{32}$")))
                //{
                //    json.Data = new UserRegResult() { Code = "00", Response = "00", Data = "00", Message = "输入参数格式不对" };
                //}
                else
                {   //UserGroup
                    UserGroup userbase = USER_MANAGER.getUserGroup();
                    //User
                    User user = USER_MANAGER.getUser();
                    UserRegister userregister = USER_MANAGER.getUserRegister();
                    //创建普通用户并增加权限
                    UserLogin current = USER_MANAGER.Create(userbase, infos, user, userregister);
                    if (current != null)
                    {//账号不存在
                        USER_MANAGER.addPrivilege(current);
                        json.Data = new UserRegResult() { Code = "01", Response = "01", Data = "01", Message = "注册成功" };
                    }
                    else
                    {//账号存在
                        json.Data = new UserRegResult() { Code = "00", Response = "01", Data = "00", Message = "账号已经存在" };
                    }
                }
                json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return json;
            }
            catch
            {
                json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                json.Data = new UserRegResult() { Code = "00", Response = "00", Data = "00", Message = "服务器出现异常" };
                return json;
                //注册出现异常
            }
        }

        public ActionResult Login(string Returnurl)
        {
            ViewBag.returnurl = Returnurl;
            return View();
        }
        [HttpPost]
        public JsonResult Login(User info, string Returnurl)
        {
            var json = new JsonResult();
            try
            {//信息缺少
                if (String.IsNullOrWhiteSpace(info.PhoneNumber) || String.IsNullOrWhiteSpace(info.CardPath))
                {
                    json.Data = new UserLoginResult() { Code = "00", Response = "00", Data = "00", Message = "输入参数不全" };
                }
                //else if (!(Regex.IsMatch(info.Telephone, @"^[0-9]{11}$") && Regex.IsMatch(info.Password, @"^[0-9a-zA-Z]{32}$")))
                //{
                //    json.Data = new UserRegResult() { Code = "00", Response = "00", Data = "00", Message = "输入参数格式不对" };
                //}
                else
                {
                    if (USER_MANAGER.selectUser(info) != null)
                    {
                        //登陆成功
                        json.Data = new UserLoginResult() { Code = "01", Response = "01", Data = "01", Message = "登陆成功" };
                        Session["user"] = USER_MANAGER.selectUser(info);
                    }
                    else
                    {
                        json.Data = new UserLoginResult() { Code = "00", Response = "01", Data = "00", Message = "账号或密码错误" };
                    }
                }
                json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return json;
            }
            catch
            {
                json.Data = new UserLoginResult() { Code = "00", Response = "00", Data = "00", Message = "00" };
                return json;
                //登陆出现异常
            }
        }
        //修改用户密码
        public JsonResult update(User info)
        {
            var json = new JsonResult();
            try
            {//空值
                if (String.IsNullOrWhiteSpace(info.CardPath))
                {
                    json.Data = new UserUpdateResult() { Code = "00", Response = "00", Data = "00", Message = "00" };
                }
                else
                {
                    USER_MANAGER.updateUser(info);
                    json.Data = new UserUpdateResult() { Code = "00", Response = "00", Data = "00", Message = "00" };

                }
            }
            catch (Exception e)
            {

                json.Data = new UserUpdateResult() { Code = "00", Response = "00", Data = "00", Message = "00" };

            }
            return null;
        }
        [NonAction]
        public ActionResult RedirectToLocal(string ReturnUrl)
        {
            if (Url.IsLocalUrl(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
