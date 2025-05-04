using System.ComponentModel;

namespace WpfConverterDemo.Models
{
    /// <summary>
    /// 订单状态枚举
    /// </summary>
    public enum OrderStatus
    {
        [Description("等待支付")]
        WaitingForPayment,
        
        [Description("处理中")]
        Processing,
        
        [Description("已发货")]
        Shipped,
        
        [Description("已完成")]
        Completed,
        
        [Description("已取消")]
        Canceled
    }
} 