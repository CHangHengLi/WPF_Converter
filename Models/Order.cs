namespace WpfConverterDemo.Models
{
    /// <summary>
    /// 订单模型类
    /// </summary>
    public class Order
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber { get; set; } = string.Empty;
        
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;
        
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal Amount { get; set; }
        
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus Status { get; set; }
        
        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime OrderDate { get; set; }
    }
} 