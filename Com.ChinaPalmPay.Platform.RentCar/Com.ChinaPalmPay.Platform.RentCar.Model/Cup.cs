using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.ChinaPalmPay.Platform.RentCar.Model
{
    [Table(Name = "T_Cup")]
    [Serializable]
    public class Cup
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public string id { get; set; }
        [Column]
        //交易类型
        public string txnType { get; set; }
        [Column]
        //产品类型
        public string bizType { get; set; }
        [Column]
        //商户代码
        public string merId { get; set; }
        [Column]
        //商户订单号
        public string orderId { get; set; }
        //订单发送时间
        [Column]
        public string txnTime { get; set; }
        [Column]
        //交易金额
        public int txnAmt { get; set; }
        [Column]
        //交易查询流水号
        public string queryId { get; set; }
        [Column]
        //响应吗
        public string respCode { get; set; }
        [Column]
        //响应信息
        public string respMsg { get; set; }
        //清算金额
        [Column]
        public int settleAmt { get; set; }
        //清算日期
        [Column]
        public string settleDate { get; set; }
        //账号
        [Column]
        public string accNo { get; set; }
        //支付卡类型
        [Column]
        public string payCardType { get; set; }
        //支付方式
        [Column]
        public string payType { get; set; }
        //支付卡标识
        [Column]
        public string payCardNo { get; set; }
        //支付卡名称
        [Column]
        public string payCardIssueName { get; set; }
        //绑定标识号
        [Column]
        public string bindId { get; set; }
        [Column]
        public string cupParams { get; set; }
    }
}
