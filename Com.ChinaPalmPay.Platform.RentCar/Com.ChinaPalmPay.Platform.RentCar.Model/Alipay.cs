using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
    [Table(Name = "T_Alipay")]
    [Serializable]
    public class Alipay
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public  string id{ get; set; }
        [Column]
        //通知时间
        public string notify_time { get; set; }
        [Column]
        public string notify_id { get; set; }

        [Column]
        //商户网站唯一订单号
        public string out_trade_no { get; set; }
        [Column]
        //商品名称
        public string subject { get; set; }
        [Column]
        //支付类型
        public string payment_type { get; set; }
        [Column]
        //支付宝交易号
        public string trade_no { get; set; }
        [Column]
        //交易状态
        public string trade_status { get; set; }
        [Column]
        //交易金额
        public int total_fee { get; set; }
        [Column]
        //交易创建时间
        public string gmt_create { get; set; }
        [Column]
        //交易付款时间
        public string gmt_payment { get; set; }
        [Column]
        //异步通知全部参数
        public string alipayParams { get; set; }


    }
}
