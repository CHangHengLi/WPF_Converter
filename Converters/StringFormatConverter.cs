using System.Globalization;
using System.Windows.Data;

namespace WpfConverterDemo.Converters
{
    /// <summary>
    /// 用于高级字符串格式化的转换器
    /// </summary>
    public class StringFormatConverter : IValueConverter
    {
        /// <summary>
        /// 将值格式化为字符串
        /// </summary>
        /// <param name="value">要格式化的值</param>
        /// <param name="targetType">目标类型（通常是string）</param>
        /// <param name="parameter">格式字符串，例如"¥{0:N2}"</param>
        /// <param name="culture">当前区域性信息</param>
        /// <returns>格式化后的字符串</returns>
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // 如果值为null，返回空字符串
            if (value == null)
                return string.Empty;
            
            // 如果没有提供格式参数，返回值的字符串表示
            if (parameter == null)
                return value.ToString() ?? string.Empty;
            
            // 使用提供的格式字符串格式化值
            try
            {
                return string.Format(culture, parameter.ToString() ?? "{0}", value);
            }
            catch (Exception)
            {
                // 如果格式化失败，返回原始值的字符串表示
                return value.ToString() ?? string.Empty;
            }
        }

        /// <summary>
        /// 不支持从字符串转换回原始值
        /// </summary>
        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // 字符串格式化通常是单向的，不支持反向转换
            throw new NotSupportedException("StringFormatConverter不支持反向转换");
        }
    }
} 