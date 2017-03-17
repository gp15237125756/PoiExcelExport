using Com.Chinapalmpay.Component.Log;
using Com.ChinaPalmPay.Platform.RentCar.BLLFacs;
using Com.ChinaPalmPay.Platform.RentCar.Common;
using Com.ChinaPalmPay.Platform.RentCar.IBLLS;
using Com.ChinaPalmPay.Platform.RentCar.Model;
using Com.ChinaPalmPay.Platform.RentCar.Model.OperationResult;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace com.chinapalmpay.platform.RentCars.Controllers
{
    public class PayController : BaseController
    {
        private static readonly IPayHandler orderbll = BllAccess.CreatePayService();
        private static readonly IPaymentHandler paymentbll = BllAccess.CreatePaymentService();
        private static readonly string Mch_Id = ConfigurationManager.AppSettings["mch_id"];

        // GET: /Pay/
        /**充值或消费或付款**/
        //IOS侧微信支付回调
        //192.168.0.5:8787/Pay/Recharge
        public ActionResult Charge(string UserID, int? Amount, string PayOrderID, int? Type)
        {

            string response = Request.Params.ToString();
            LogerHelper.DefaultInfo("微信回调");
            LogerHelper.DefaultInfo(response);
            string rrr = Request.Form.ToString();
            LogerHelper.DefaultInfo("POST:" + rrr);
            if (paymentbll.chargePayment(UserID, Amount, PayOrderID, Type))
            {
                LogerHelper.debug("微信支付成功！");

            }
            return Content("cccc");

            //if (!String.IsNullOrWhiteSpace(UserID) && !String.IsNullOrWhiteSpace(UserID)
            //    &&!String.IsNullOrWhiteSpace(UserID) && !String.IsNullOrWhiteSpace(UserID))
            //{

            //}
            //return null;

        }
        public ActionResult PayNotifyUrl()
        {
            try
            {
                string[] strs = Request.RawUrl.ToString().Split("/".ToCharArray());
                string userID = strs[strs.Length - 1];
                LogerHelper.DefaultInfo(strs[strs.Length - 1]);
                NotifyHandler resHandler = new NotifyHandler(Request.InputStream);
                Hashtable table = resHandler.Parameters;
                ArrayList akeys = new ArrayList(table.Keys);
                akeys.Sort();
                foreach (string k in akeys)
                {
                    string v = (string)table[k];
                    LogerHelper.DefaultInfo(v);
                }
                string openid = resHandler.GetParameter("openid");
                string total_fee = resHandler.GetParameter("total_fee");
                string out_trade_no = resHandler.GetParameter("out_trade_no");
                LogerHelper.DefaultInfo("total_fee:    " + total_fee);
                LogerHelper.DefaultInfo("out_trade_no:    " + out_trade_no);
                resHandler.SetKey(Mch_Id);
                //验证请求是否从微信发过来（安全）
              //  if (resHandler.IsTenpaySign())
               // {
                    //正确的订单处理
                    LogerHelper.DefaultInfo("nofify     ok");
                    //此处userid是回调url最后一个参数
                    if (paymentbll.chargePayment(userID, Convert.ToInt32(total_fee), out_trade_no, (int)Commons.PayType.RECHARGE))
                    {
                        LogerHelper.debug("微信支付成功！");

                    }
                    // WebHelper.Post(LocalContext.platformUrl + "/Pay/Recharge", "UserID=" + (Common.GlobalMap[openid] as UserInformation).userid + "Amount=" + total_fee + "PayOrderID=" + out_trade_no + "Type=1");
              //  }
               // else
               // {
                    //错误的订单处理
                   // LogerHelper.DefaultInfo("nofify     no");
              //  }
            }
            catch (Exception ex)
            {
                LogerHelper.DefaultInfo("ex:    " + ex.ToString());
            }

            return Content("success");
        }

        //查询余额
        public ActionResult Remaining(string UserId)
        {

            DefaultResult res = new DefaultResult();
            try
            {
                double Sum = paymentbll.queryRemainSum(UserId);
                res.Code = "0000";
                res.Data = Sum;
                res.Message = "查询余额成功";
            }
            catch (Exception e)
            {
                res.Code = "0201";
                res.Data = "";
                res.Message = e.InnerException == null ? e.Message : e.InnerException.Message;
            }

            return Json(res,JsonRequestBehavior.AllowGet);

        }
        public ActionResult Recharge()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Recharge(Recharge charge)
        {
            DefaultResult def = new DefaultResult();
            try
            {

                if (!String.IsNullOrWhiteSpace(charge.UserID) && charge.Amount != 0 && !String.IsNullOrWhiteSpace(charge.PayOrderID) && charge.Type != 0)
                {
                    //如果是充值或其他消费业务
                    Recharge Charge = orderbll.pay(charge);
                    if (Charge != null)
                    {
                        if (Charge.Type == (int)Commons.PayType.RECHARGE)
                        {
                            def.Code = "0000";
                            def.Data = Charge;
                            def.Message = "充值成功";
                        }
                        else if (Charge.Type == (int)Commons.PayType.OTHERCONSUME)
                        {
                            def.Code = "0000";
                            def.Data = Charge;
                            def.Message = "其他消费成功";
                        }
                        else if (Charge.Type == (int)Commons.PayType.CONSUME)
                        {
                            def.Code = "0000";
                            def.Data = Charge;
                            def.Message = "消费成功";
                        }
                        else if (Charge.Type == (int)Commons.PayType.PAYMENT)
                        {
                            def.Code = "0000";
                            def.Data = Charge;
                            def.Message = "付款成功";
                        }
                    }
                    else
                    {
                        def.Code = "0001";
                        def.Data = Charge;
                        def.Message = "操作失败";

                    }
                }
                else
                {
                    //参数不全
                    def.Code = "0101";
                    def.Data = "";
                    def.Message = "服务端收到参数缺失";
                }
            }
            catch (Exception e)
            {
                def.Code = "0201";
                def.Data = "";
                def.Message = e.InnerException == null ? e.Message : e.InnerException.Message;

            }
            return Json(def);
        }
        //public ActionResult AlipayComplete()
        //{
        //    return View();
        //}
        //支付宝支付结果回调接口
        //[HttpPost]
      /*  public ActionResult AlipayComplete()
        {
            string response = Request.Params.ToString();
            LogerHelper.DefaultInfo(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "支付宝回调");
            LogerHelper.DefaultInfo(response);
            if (Request.HttpMethod == "POST")
            {
                // 使用Dictionary保存参数
                Dictionary<string, string> resData = new Dictionary<string, string>();

                NameValueCollection coll = Request.Form;

                string[] requestItem = coll.AllKeys;
                if (requestItem.Count() > 0)
                {
                    for (int i = 0; i < requestItem.Length; i++)
                    {
                        resData.Add(requestItem[i], Request.Form[requestItem[i]]);
                    }
                    Alipay alipay = new Alipay();
                    alipay.alipayParams = response;
                    alipay.gmt_create = resData["gmt_create"];
                    alipay.gmt_payment = resData["gmt_payment"];
                    alipay.notify_id = resData["notify_id"];
                    alipay.notify_time = resData["notify_time"];
                    alipay.out_trade_no = resData["out_trade_no"];
                    alipay.payment_type = resData["payment_type"];
                    alipay.subject = resData["subject"];
                    alipay.total_fee = Convert.ToInt32(resData["total_fee"]);
                    alipay.trade_no = resData["trade_no"];
                    alipay.trade_status = resData["trade_status"];
                    alipay.id = Guid.NewGuid().ToString().Replace("-", "");
                    if (paymentbll.alipayPayment(alipay))
                    {
                        LogerHelper.DefaultInfo("支付宝支付成功");
                        return Content("success");
                    }
                }
            }
            return Content("fail11111");
        }*/
        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }

            return sArray;
        }
        [HttpPost,ValidateInput(false)]
        public ActionResult AlipayComplete()
        {
            LogerHelper.DefaultInfo("支付宝回调");
            //SortedDictionary<string, string> sPara = GetRequestPost();
            //LogerHelper.DefaultInfo("" + sPara.Count());
            //if (sPara.Count > 0)//判断是否有带返回参数
            //{
            //    Notify aliNotify = new Notify();
            //    bool verifyResult = aliNotify.Verify(sPara, Request.Form["notify_id"], Request.Form["sign"]);
            //    LogerHelper.DefaultInfo(""+verifyResult);
            //    if (verifyResult)//验证成功
            //    {
            //        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //        //请在这里加上商户的业务逻辑程序代码


            //        //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
            //        //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表

            //        //商户订单号

            //        string out_trade_no = Request.Form["out_trade_no"];

            //        //支付宝交易号

            //        string trade_no = Request.Form["trade_no"];

            //        //交易状态
            //        string trade_status = Request.Form["trade_status"];


            //        if (Request.Form["trade_status"] == "TRADE_FINISHED")
            //        {
            //            LogerHelper.DefaultInfo("TRADE_FINISHED");
            //            //判断该笔订单是否在商户网站中已经做过处理
            //            //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
            //            //如果有做过处理，不执行商户的业务程序

            //            //注意：
            //            //该种交易状态只在两种情况下出现
            //            //1、开通了普通即时到账，买家付款成功后。
            //            //2、开通了高级即时到账，从该笔交易成功时间算起，过了签约时的可退款时限（如：三个月以内可退款、一年以内可退款等）后。
            //        }
            //        else if (Request.Form["trade_status"] == "TRADE_SUCCESS")
            //        {
            //            LogerHelper.DefaultInfo("TRADE_SUCCESS");
            //            //判断该笔订单是否在商户网站中已经做过处理
            //            //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
            //            //如果有做过处理，不执行商户的业务程序

            //            //注意：
            //            //该种交易状态只在一种情况下出现——开通了高级即时到账，买家付款成功后。
            //        }
            //        else
            //        {
            //        }

            //        //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

            //        Response.Write("success");  //请不要修改或删除

            //        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //    }
            //    else//验证失败
            //    {
            //        Response.Write("fail");
            //    }
            //}
            //else
            //{
            //    Response.Write("无通知参数");
            //}
            return Content("success");
        }
        //银联支付结果回调接口
        public ActionResult CupComplete(Cup cup)
        {
            LogerHelper.DefaultInfo(Request.ToString());
            if (Request.HttpMethod == "POST")
            {
                // 使用Dictionary保存参数
                Dictionary<string, string> resData = new Dictionary<string, string>();

                NameValueCollection coll = Request.Form;

                string[] requestItem = coll.AllKeys;

                for (int i = 0; i < requestItem.Length; i++)
                {
                    resData.Add(requestItem[i], Request.Form[requestItem[i]]);
                }
                // 返回报文中不包含UPOG,表示Server端正确接收交易请求,则需要验证Server端返回报文的签名
                if (SDKUtil.Validate(resData, Encoding.UTF8))
                {
                    cup.accNo = resData["accNo"];
                    cup.bindId = resData["bindId"];
                    cup.bizType = resData["bizType"];
                    cup.cupParams = coll.ToString();
                    cup.id = resData["id"];
                    cup.merId = resData["merId"];
                    cup.orderId = resData["orderId"];
                    cup.payCardIssueName = resData["payCardIssueName"];
                    cup.payCardNo = resData["payCardNo"];
                    cup.payCardType = resData["payCardType"];
                    cup.payType = resData["payType"];
                    cup.queryId = resData["queryId"];
                    cup.respCode = resData["respCode"];
                    cup.respMsg = resData["respMsg"];
                    cup.settleAmt = Convert.ToInt32(resData["settleAmt"]);
                    cup.settleDate = resData["settleDate"];
                    cup.txnAmt = Convert.ToInt32(resData["txnAmt"]);
                    cup.txnTime = resData["txnTime"];
                    cup.txnType = resData["txnType"];
                    string respcode = resData["respCode"];
                    //Response.Write("商户端验证返回报文签名成功\n");

                    //商户端根据返回报文内容处理自己的业务逻辑 ,DEMO此处只输出报文结果
                    //StringBuilder builder = new StringBuilder();

                    //builder.Append("<tr><td align=\"center\" colspan=\"2\"><b>商户端接收银联返回报文并按照表格形式输出结果</b></td></tr>");

                    //for (int i = 0; i < requestItem.Length; i++)
                    //{
                    //    builder.Append("<tr><td width=\"30%\" align=\"right\">" + requestItem[i] + "</td><td style='word-break:break-all'>" + Request.Form[requestItem[i]] + "</td></tr>");
                    //}

                    //builder.Append("<tr><td width=\"30%\" align=\"right\">商户端验证银联返回报文结果</td><td>验证签名成功.</td></tr>");
                    //Response.Write(builder.ToString());
                    cup.cupParams = coll.ToString();
                    cup.id = Guid.NewGuid().ToString().Replace("-", "");
                    if (paymentbll.cupPayment(cup))
                    {
                        LogerHelper.debug("银联支付成功");
                        return Content("success");

                    }
                }
                else
                {
                    LogerHelper.debug("银联支付失败");
                    // Response.Write("<tr><td width=\"30%\" align=\"right\">商户端验证银联返回报文结果</td><td>验证签名失败.</td></tr>");
                }

            }
            return Content("fail");
        }
        /* public ActionResult CupComplete(Cup cup)
         {
             string response = Request.Form.ToString();
             LogerHelper.debug(response);
             if (!String.IsNullOrWhiteSpace(response))
             {
                 cup.cupParams = response;
                 cup.id = Guid.NewGuid().ToString().Replace("-", "");
                 if (paymentbll.cupPayment(cup))
                 {
                     LogerHelper.debug("银联支付成功");
                     return Content("success");

                 }
             }
                 return Content("fail");
         }*/

        //银联控件获取tn交易的请求
        [HttpPost]
        public ActionResult AppConsume(string txnAmt, string orderDesc)
        {
            LogerHelper.DefaultInfo(Request.ToString());
            Dictionary<string, string> param = new Dictionary<string, string>();
            // 随机构造一个订单号（演示用）
            Random rnd = new Random();
            string orderID = DateTime.Now.ToString("yyyyMMddHHmmss") + (rnd.Next(900) + 100).ToString().Trim();

            //填写参数

            param["version"] = "5.0.0";//版本号
            param["encoding"] = "UTF-8";//编码方式
             param["certId"] = CertUtil.GetSignCertId();      //证书ID
            param["txnType"] = "01";//交易类型
            param["txnSubType"] = "01";//交易子类
            param["bizType"] = "000201";//业务类型
            param["frontUrl"] = "http://localhost:8080/demo/utf8/FrontRcvResponse.aspx";    //前台通知地址 ，控件接入方式无作用     
            param["backUrl"] = "http://weixin.mandelaauto.com/Pay/CupComplete";  //后台通知地址	
            param["signMethod"] = "01";//签名方法
            param["channelType"] = "08";//渠道类型，07-PC，08-手机
            param["accessType"] = "0";//接入类型
            param["merId"] = Properties.getHost();//商户号，请改成自己的商户号
            param["orderId"] = orderID;//商户订单号
            param["txnTime"] = DateTime.Now.ToString("yyyyMMddHHmmss");//订单发送时间
            param["txnAmt"] = txnAmt;//交易金额，单位分
            param["currencyCode"] = "156";//交易币种
            param["orderDesc"] = orderDesc;//订单描述，可不上送，上送时控件中会显示该信息
            param["reqReserved"] = "透传信息";//请求方保留域，透传字段，查询、通知、对账文件中均会原样出现
            SDKUtil.Sign(param, Encoding.UTF8);  // 签名
            Response.Write("\n" + "请求报文=[" + SDKUtil.PrintDictionaryToString(param) + "]\n");

            // 初始化通信处理类
            HttpClient hc = new HttpClient(SDKConfig.AppRequestUrl);
            //// 发送请求获取通信应答
            int status = hc.Send(param, Encoding.UTF8);
            // 返回结果
            string result = hc.Result;
            if (status == 200)
            {
                Response.Write("返回报文=[" + result + "]\n");
                LogerHelper.DefaultInfo(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ")+result);
                Dictionary<string, string> resData = SDKUtil.CoverstringToDictionary(result);
                foreach (var x in resData.Keys)
                {
                    LogerHelper.DefaultInfo(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + x);
                }
                string respcode = resData["respCode"];
                if (SDKUtil.Validate(resData, Encoding.UTF8))
                {
                    Response.Write("商户端验证返回报文签名成功\n");
                }
                else
                {
                    Response.Write("商户端验证返回报文签名失败\n");
                }
            }
            else
            {
                Response.Write("请求失败\n");
                Response.Write("返回报文=[" + result + "]\n");
            }
            return Content("success");
        }
        //还车付款
        [HttpPost]
        //true-----成功  false-----失败
        public ActionResult returnPay(string userId, string orderId)
        {
            DefaultResult def = new DefaultResult();
            string msg = "";
            try
            {
                if (!String.IsNullOrWhiteSpace(userId) && !String.IsNullOrWhiteSpace(orderId))
                {
                    Recharge recharge = paymentbll.returnCar(userId, orderId,out msg);
                    if (recharge != null)
                    {
                        def.Code = "0000";
                        def.Data = recharge;
                        def.Message = msg;

                    }
                    else
                    {
                        def.Code = "0001";
                        def.Data = "";
                        def.Message = msg;

                    }
                }
                else
                {
                    def.Code = "0001";
                    def.Data = "";
                    def.Message = "扣款参数有空值";
                }
            }
            catch (Exception e)
            {
                def.Code = "0001";
                def.Data = "";
                def.Message = e.InnerException == null ? e.Message : e.InnerException.Message;

            }
            return Json(def);
        }

    }
}
