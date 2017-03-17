using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Common
{
    /**定时器任务*/
    public class TerminalRealTimeInspector
    {
        public Dictionary<String, TerminalSession> currentUser = new Dictionary<String, TerminalSession>();
        private static TerminalRealTimeInspector _instance = null;
        private static readonly object locks = new object();
        private static readonly object lockHelper = new object();
        private static readonly object loc = new object();
        private bool TimerIsRunning = false;
        private Boolean isInit = false;
        private TerminalRealTimeInspector()
        {

        }
        //线程安全的同步锁
        public static TerminalRealTimeInspector CreateInstance()
        {
            if (_instance == null)
            {
                lock (locks)
                {
                    if (_instance == null)
                        _instance = new TerminalRealTimeInspector();
                }
            }
            return _instance;
        }

        public void Init()
        {
            isInit = true;
            if (!TimerIsRunning)
            {
                TimerIsRunning = true;
            }
        }
        //删除全部session
        public void close()
        {
            currentUser.Clear();
        }

        /**
         * 
         * @param terminalID
         * @return user
         */
        public RunRealTime getRunRealTime(String terminalID)
        {
            return currentUser[terminalID] == null ? null : currentUser[terminalID].getStatus();
        }

        public IList<RunRealTime> currentActiveUsers()
        {
            IList<RunRealTime> runs = new List<RunRealTime>();
           IList<TerminalSession> terms=currentUser.Values.ToList();
           if (terms.Count() > 0)
           {
               foreach (var i in terms)
               {
                   runs.Add(i.getStatus());
               }
           }
            return runs;
        }

        /**
         * 
         * @param terminalID
         * @param longitudel
         * @param latitude
         * @return
         */
        public TerminalSession getSession(RunRealTime status)
        {
            lock (loc)
            {
                if (!isInit)
                {
                    Init();
                }
            }
            TerminalSession session = currentUser[status.TerminalId];
            if (session != null && session.isUsing())
            {
                session.setStatus(status);
                session.setLastTime(Convert.ToInt64(DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds));
                //session.setUsedCount(session.getUsedCount() + 1);
                return session;
            }
            else
            {
                session = new TerminalSession(status);
                currentUser[status.TerminalId] = session;
                return session;
            }
        }

        /**
         * 
         * @param terminalID
         */
        public void closeSession(String terminalID)
        {
            lock (currentUser)
            {
                currentUser.Remove(terminalID);
            }
        }
    }
}
