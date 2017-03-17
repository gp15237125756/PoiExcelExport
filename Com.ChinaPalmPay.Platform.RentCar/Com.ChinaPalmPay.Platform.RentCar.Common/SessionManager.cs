using Com.ChinaPalmPay.Platform.RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Com.ChinaPalmPay.Platform.RentCar.Common
{
    /**
     * 定时器线程
     * /
      
     *   /** 高精准的单例 */
    public class SessionManager
    {
        private static SessionManager instanceNicety = null;

        private static long sessionTimeOutMills = 500;
        /** 是否运行 */
        protected static bool isRunning = true;
        //线程安全的同步锁
        private static readonly object lockHelper = new object();
        private static readonly object locks = new object();
        public static System.Timers.Timer timer;
        public static bool flag = true;
        public static object mylock = new object();
        /**
         * 构造函数
         */
        private SessionManager() { }

        /**
         * 获得高精准的Timer管理器的实例
         */
        public SessionManager getNicetyInstance()
        {
            if (instanceNicety == null)
            {
                lock (lockHelper)
                {

                    if (instanceNicety == null)
                    {
                        instanceNicety = new SessionManager();
                    }
                }
            }
            return instanceNicety;
        }

        public void Init()
        {
            timer = new System.Timers.Timer(10);
            timer.Elapsed += new ElapsedEventHandler(run);
            timer.Start();
        }

        public void run(object sender, ElapsedEventArgs e)
        {
            Thread.CurrentThread.IsBackground = false;
            lock (mylock)
            {
                while (isRunning)
                {
                    Thread.Sleep(5);
                    Dictionary<String, TerminalSession> users = TerminalRealTimeInspector.CreateInstance().currentUser;
                    if (users != null && users.Count() > 0)
                    {
                        lock (users)
                        {
                            long currTime = Convert.ToInt64(DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds);
                            foreach (string x in users.Keys)
                            {
                                //定时器任务,每100ms遍历执行一次
                                TerminalSession session = users[x];
                                long current = Convert.ToInt64(DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds);
                                //超时
                                if ((current - session.getLastTime()) >= sessionTimeOutMills)
                                {
                                    TerminalRealTimeInspector.CreateInstance().closeSession(x);
                                }
                                //间隔100ms
                                Thread.Sleep(100);
                            }
                        }
                    }
                    Thread.Sleep(1000);
                }
            }
        }

    }
}