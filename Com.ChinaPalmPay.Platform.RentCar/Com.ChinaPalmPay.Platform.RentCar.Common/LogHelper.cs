using Com.Chinapalmpay.Component.Log;
using System.Web.Script.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Common
{
  public  class LogHelper
    {
      //记录输入参数日志 
     
      public static void Input(params object[] p)
      {
          foreach (object t in p)
          {
               //如果参数是对象,输出序列化后对象
      //如过参数是一个或多个字符串
              LogerHelper.debug(ObjectToJson(t));
          }
      }
      // 从一个对象信息生成Json串
      public static string ObjectToJson(object obj)
      {
          JavaScriptSerializer js = new JavaScriptSerializer();
          return js.Serialize(obj);
      }
      // 从一个Json串生成对象信息
      public static T JsonToObject<T>(string jsonString)
      {
          JavaScriptSerializer js = new JavaScriptSerializer();
          return js.Deserialize<T>(jsonString);
      }
      //出参方法
      public static void OutPut(System.Web.Routing.RequestContext requestContext, object obj)
      {
          LogerHelper.DefaultInfo(string.Format("输出:{0}/{1}  {2}", requestContext.RouteData.Values["controller"], requestContext.RouteData.Values["action"],"",ObjectToJson(obj)));
      }

      //异常
      public static void Exception(System.Web.Routing.RequestContext requestContext,Exception obj)
      {
          LogerHelper.exception(string.Format("异常说明:{0}/{1}  {2}  {3}", requestContext.RouteData.Values["controller"], requestContext.RouteData.Values["action"],obj.Source, obj.InnerException == null ? obj.Message : obj.InnerException.Message), obj);
      }
    }
}
