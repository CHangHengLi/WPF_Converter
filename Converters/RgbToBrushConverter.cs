using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfConverterDemo.Converters
{
    /// <summary>
    /// 将RGB分量转换为SolidColorBrush的多值转换器
    /// </summary>
    public class RgbToBrushConverter : IMultiValueConverter
    {
        /// <summary>
        /// 将RGB分量转换为SolidColorBrush
        /// </summary>
        /// <param name="values">RGB值数组（应包含3个0-255之间的整数）</param>
        /// <param name="targetType">目标类型（应为SolidColorBrush）</param>
        /// <param name="parameter">可选参数，不使用</param>
        /// <param name="culture">当前区域性信息</param>
        /// <returns>包含指定RGB颜色的SolidColorBrush</returns>
        public object Convert(object[]? values, Type targetType, object? parameter, CultureInfo culture)
        {
            // 检查是否有足够的值
            if (values == null || values.Length < 3)
                return new SolidColorBrush(Colors.Black);
            
            // 尝试解析RGB值
            byte r = ParseColorComponent(values[0]);
            byte g = ParseColorComponent(values[1]);
            byte b = ParseColorComponent(values[2]);
            
            // 创建颜色对象
            Color color = Color.FromRgb(r, g, b);
            
            // 返回颜色画刷
            return new SolidColorBrush(color);
        }

        /// <summary>
        /// 将SolidColorBrush转换回RGB分量
        /// </summary>
        /// <param name="value">要转换的SolidColorBrush</param>
        /// <param name="targetTypes">目标类型数组</param>
        /// <param name="parameter">可选参数，不使用</param>
        /// <param name="culture">当前区域性信息</param>
        /// <returns>包含RGB分量的数组</returns>
        public object[]? ConvertBack(object? value, Type[]? targetTypes, object? parameter, CultureInfo culture)
        {
            // 检查输入是否为SolidColorBrush
            if (value is not SolidColorBrush brush)
                return new object[] { 0, 0, 0 };
            
            // 获取颜色
            Color color = brush.Color;
            
            // 返回RGB分量
            return new object[] { color.R, color.G, color.B };
        }
        
        /// <summary>
        /// 将对象解析为颜色分量（0-255的字节值）
        /// </summary>
        /// <param name="value">要解析的对象</param>
        /// <returns>颜色分量值</returns>
        private byte ParseColorComponent(object? value)
        {
            // 尝试转换为数值
            if (value is byte byteValue)
                return byteValue;
            
            if (int.TryParse(value?.ToString(), out int intValue))
                return (byte)Math.Clamp(intValue, 0, 255);
            
            if (double.TryParse(value?.ToString(), out double doubleValue))
                return (byte)Math.Clamp(doubleValue, 0, 255);
            
            // 默认返回0
            return 0;
        }
    }
} 