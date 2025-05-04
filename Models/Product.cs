namespace WpfConverterDemo.Models
{
    /// <summary>
    /// 产品模型类
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// 产品价格
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool IsAvailable { get; set; }
        
        /// <summary>
        /// 产品描述
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
} 