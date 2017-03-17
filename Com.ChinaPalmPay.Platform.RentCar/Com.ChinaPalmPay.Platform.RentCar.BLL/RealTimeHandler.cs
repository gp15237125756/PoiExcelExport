using Com.ChinaPalmPay.Platform.RentCar.Common;
using Com.ChinaPalmPay.Platform.RentCar.DALFactory;
using Com.ChinaPalmPay.Platform.RentCar.IBLLS;
using Com.ChinaPalmPay.Platform.RentCar.IDAL;
using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.BLL
{
  public  class RealTimeHandler:IRealTimeHandler
    {
      private static readonly IRealTimeManager db_realtime = DataAccess.CreateRealTimeDbManager();
      private static readonly IOrderManager dbOrd_realtime = DataAccess.CreateOrderDbManager();
      //终端运行时上传实时位置数据
        public RunRealTime uploadRunRealTime(RunRealTime input)
        {
            //1.将终端数据加入计时器线程，更新为时间，判断是否超时
            // to do
          //  TerminalSession session=TerminalRealTimeInspector.CreateInstance().getSession(input);
            //2.判断updateTime时间差是否大于5S，如果超过则下发查分数，否则下发周边数据
            // todo
            //3.保存终端上传数据
            RunRealTime real=db_realtime.AddRunRealTime(input);
            if (real!= null)
            {
                return real;
            }
            return null;
        }

        public StopRealTime uploadStopRealTime(StopRealTime input)
        {
            StopRealTime real = db_realtime.AddStopRealTime(input);
            if (real != null)
            {
                return real;
            }
            return null;
        }

        public byte[] uploadAuthorization(AuthorizationRequest input)
        {
            AuthorizationRequest real = db_realtime.AddAuthorizationRealTime(input);
            if (real != null)
            {
                //终端id
                string termiId=input.TerminalId;
                //返回终端id对应用户手机号
                string[] result=db_realtime.queryTelByTermiId(termiId);
                if (result!=null)
                {
                AuthorizationResponse resp = new AuthorizationResponse();
                resp.UserId=result[0];
                resp.CarId = result[1];
                resp.SampleTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
               return RealTimeAnalysis.encodeAuthorizationResponse(resp);
                //to do
                
                }
            }
            return null;
        }

        public OpenOrCloseGateRequest uploadOpenOrCloseGate(OpenOrCloseGateRequest input)
        {
          OpenOrCloseGateRequest open=db_realtime.AddOpenOrCloseGate(input);
          if (open != null)
          {

              //开门开始计费
              //修改订单状态为开门状态
              //dbOrd_realtime.updateToOpenDoor(open.UserId);
              return open;
          }
          return null;
        }


        public RunRealTime selectRunReal()
        {

            throw new NotImplementedException();
        }

        public StopRealTime selectStopReal()
        {
            throw new NotImplementedException();
        }

        public AuthorizationRequest selectAuthorizationReal()
        {
            throw new NotImplementedException();
        }


        public IList<RunRealTime> selectAll()
        {
            throw new NotImplementedException();
        }


        public IList<RunRealTime> selectAll(string TermId, string begin, string end)
        {
            IList<RunRealTime> list=db_realtime.queryAllLocation(TermId,begin, end);
            if(list.Count()>0){
                return list;
            }
            return null;
        }
    }
}
