using System.Globalization;
using System.Windows.Data;

namespace WpfConverterDemo.Converters
{
    /// <summary>
    /// 处理数值转换的转换器
    /// 可以将数值乘以指定系数，或者添加偏移量
    /// </summary>
    public class NumberConverter : IValueConverter
    {
        /// <summary>
        /// 将数值按照指定方式转换
        /// </summary>
        /// <param name="value">要转换的数值</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="parameter">转换参数，格式为"operation:value"，如"multiply:2"或"add:10"</param>
        /// <param name="culture">当前区域性信息</param>
        /// <returns>转换后的数值</returns>
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // 确保值是数字
            if (value is not double and not int and not float and not decimal)
                return 0;
            
            // 将值转换为double
            double doubleValue = System.Convert.ToDouble(value);
            
            // 如果没有参数，直接返回值
            if (parameter == null)
                return doubleValue;
            
            string paramStr = parameter.ToString() ?? string.Empty;
            
            // 解析参数
            if (paramStr.StartsWith("multiply:"))
            {
                string multiplierStr = paramStr["multiply:".Length..];
                if (double.TryParse(multiplierStr, out double multiplier))
                {
                    return doubleValue * multiplier;
                }
            }
            else if (paramStr.StartsWith("add:"))
            {
                string addendStr = paramStr["add:".Length..];
                if (double.TryParse(addendStr, out double addend))
                {
                    return doubleValue + addend;
                }
            }
            
            // 默认返回原值
            return doubleValue;
        }

        /// <summary>
        /// 将转换后的数值转换回原始数值
        /// </summary>
        /// <param name="value">转换后的数值</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="parameter">转换参数，格式为"operation:value"，如"multiply:2"或"add:10"</param>
        /// <param name="culture">当前区域性信息</param>
        /// <returns>原始数值</returns>
        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // 确保值是数字
            if (value is not double and not int and not float and not decimal)
                return 0;
            
            // 将值转换为double
            double doubleValue = System.Convert.ToDouble(value);
            
            // 如果没有参数，直接返回值
            if (parameter == null)
                return doubleValue;
            
            string paramStr = parameter.ToString() ?? string.Empty;
            
            // 解析参数并执行反向操作
            if (paramStr.StartsWith("multiply:"))
            {
                string multiplierStr = paramStr["multiply:".Length..];
                if (double.TryParse(multiplierStr, out double multiplier) && multiplier != 0)
                {
                    return doubleValue / multiplier;
                }
            }
            else if (paramStr.StartsWith("add:"))
            {
                string addendStr = paramStr["add:".Length..];
                if (double.TryParse(addendStr, out double addend))
                {
                    return doubleValue - addend;
                }
            }
            
            // 默认返回原值
            return doubleValue;
        }
    }
} 