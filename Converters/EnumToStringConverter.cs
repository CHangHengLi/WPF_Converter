using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;

namespace WpfConverterDemo.Converters
{
    /// <summary>
    /// 将枚举值转换为友好显示文本的转换器
    /// 支持使用Description特性来自定义显示文本
    /// </summary>
    public class EnumToStringConverter : IValueConverter
    {
        /// <summary>
        /// 将枚举值转换为字符串
        /// </summary>
        /// <param name="value">要转换的枚举值</param>
        /// <param name="targetType">目标类型（通常是string）</param>
        /// <param name="parameter">可选参数，不使用</param>
        /// <param name="culture">当前区域性信息</param>
        /// <returns>枚举值的友好显示文本</returns>
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // 如果值为null，返回空字符串
            if (value == null)
                return string.Empty;
            
            // 确保值是枚举
            if (!value.GetType().IsEnum)
                return value.ToString() ?? string.Empty;
            
            // 获取枚举值
            Enum enumValue = (Enum)value;
            
            // 尝试获取Description特性
            string? description = GetEnumDescription(enumValue);
            
            // 如果有Description特性，返回其值，否则返回枚举名称
            return !string.IsNullOrEmpty(description) ? description : enumValue.ToString();
        }

        /// <summary>
        /// 将字符串转换回枚举值
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <param name="targetType">目标枚举类型</param>
        /// <param name="parameter">可选参数，不使用</param>
        /// <param name="culture">当前区域性信息</param>
        /// <returns>对应的枚举值</returns>
        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // 如果值为null或不是字符串，返回默认枚举值
            if (value == null || value is not string stringValue)
                return Enum.GetValues(targetType).GetValue(0)!;
            
            // 尝试通过枚举名称解析
            if (Enum.IsDefined(targetType, stringValue))
                return Enum.Parse(targetType, stringValue);
            
            // 尝试通过Description特性查找
            foreach (var enumValue in Enum.GetValues(targetType))
            {
                if (GetEnumDescription((Enum)enumValue) == stringValue)
                    return enumValue;
            }
            
            // 如果找不到匹配，返回默认枚举值
            return Enum.GetValues(targetType).GetValue(0)!;
        }
        
        /// <summary>
        /// 获取枚举值的Description特性值
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns>Description特性值，如果不存在则返回null</returns>
        private string? GetEnumDescription(Enum value)
        {
            // 获取字段信息
            FieldInfo? field = value.GetType().GetField(value.ToString());
            
            if (field == null) return null;
            
            // 获取Description特性
            DescriptionAttribute? attribute = Attribute.GetCustomAttribute(
                field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            
            // 返回Description值，如果没有特性则返回null
            return attribute?.Description;
        }
    }
} 