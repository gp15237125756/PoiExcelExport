using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
  public  class TerminalSession
    {
        // 5s下发一次差分数最新时间
        private long updateTime;
        private bool flag;
        // 使用状态
        private bool Using;
        // 创建时间
        private long createTime;
        // 最后使用时间
        private long lastTime;
        // 使用次数
        private int usedCount;

        public bool isFlag()
        {
            return flag;
        }

        public void setFlag(bool flag)
        {
            this.flag = flag;
        }

        public long getUpdateTime()
        {
            return updateTime;
        }

        public void setUpdateTime(long updateTime)
        {
            this.updateTime = updateTime;
        }

        private RunRealTime status;
      //先继承父类构造，再继承自己构造器
        public TerminalSession(RunRealTime status):base()
        {
            this.status = status;
        }

        public TerminalSession()
        {
            this.createTime = Convert.ToInt64(DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
            this.Using = true;
            this.usedCount = 1;
            this.lastTime = Convert.ToInt64(DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
            this.updateTime = Convert.ToInt64(DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
            this.flag = true;
        }

        public int getUsedCount()
        {
            return usedCount;
        }

        public void setUsedCount(int usedCount)
        {
            this.usedCount = usedCount;
        }

        public bool isUsing()
        {
            return Using;
        }

        public void setUsing(bool Using)
        {
            this.Using = Using;
        }

        public long getCreateTime()
        {
            return createTime;
        }

        public void setCreateTime(long createTime)
        {
            this.createTime = createTime;
        }

        public long getLastTime()
        {
            return lastTime;
        }

        public void setLastTime(long lastTime)
        {
            this.lastTime = lastTime;
        }

        public void close()
        {
            this.Using = false;
            this.usedCount = 0;
            this.createTime = 0;
            this.status = null;
        }

        public RunRealTime getStatus()
        {
            return status;
        }

        public void setStatus(RunRealTime status)
        {
            this.status = status;
        }

    }
}
