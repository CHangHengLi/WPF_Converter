using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfConverterDemo.Converters
{
    /// <summary>
    /// 将布尔值转换为Visibility枚举的转换器
    /// 当值为true时返回Visible，否则返回Collapsed
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// 将布尔值转换为Visibility值
        /// </summary>
        /// <param name="value">要转换的布尔值</param>
        /// <param name="targetType">目标类型（应为Visibility）</param>
        /// <param name="parameter">如果不为null且等于"Invert"，则反转逻辑</param>
        /// <param name="culture">当前区域性信息</param>
        /// <returns>Visibility.Visible或Visibility.Collapsed</returns>
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // 检查value是否为布尔类型
            if (value is not bool boolValue)
                return Visibility.Collapsed; // 默认为隐藏
            
            // 检查是否需要反转逻辑
            if (parameter != null && parameter.ToString() == "Invert")
                boolValue = !boolValue;
            
            // 如果true则显示，否则隐藏
            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// 将Visibility值转换回布尔值
        /// </summary>
        /// <param name="value">要转换的Visibility值</param>
        /// <param name="targetType">目标类型（应为bool）</param>
        /// <param name="parameter">如果不为null且等于"Invert"，则反转逻辑</param>
        /// <param name="culture">当前区域性信息</param>
        /// <returns>true或false</returns>
        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // 检查value是否为Visibility类型
            if (value is not Visibility visibilityValue)
                return false; // 默认为false
            
            // 判断是否为Visible
            bool result = (visibilityValue == Visibility.Visible);
            
            // 检查是否需要反转逻辑
            if (parameter != null && parameter.ToString() == "Invert")
                result = !result;
            
            return result;
        }
    }
} 