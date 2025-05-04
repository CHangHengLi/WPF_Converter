# WPF 值转换器示例程序

这是一个基于.NET Core 8.0的WPF应用程序，使用MVVM设计模式展示了值转换器的各种应用场景。
![image](https://github.com/user-attachments/assets/28d701c0-787f-4952-b9d1-1401cbb91517)


## 技术栈

- .NET Core 8.0
- WPF (Windows Presentation Foundation)
- MVVM (Model-View-ViewModel)设计模式

## 项目结构

- **Models**: 包含应用程序的数据模型
- **ViewModels**: 包含应用程序的视图模型
- **Views**: 包含应用程序的视图
- **Converters**: 包含各种数据转换器
- **Commands**: 包含命令类

## 值转换器示例

本项目展示了以下值转换器的使用：

1. **BoolToVisibilityConverter**: 将布尔值转换为可见性枚举
2. **NumberConverter**: 进行数值转换操作（乘法、加法等）
3. **StringFormatConverter**: 高级字符串格式化
4. **EnumToStringConverter**: 将枚举值转换为友好显示文本
5. **RgbToBrushConverter**: 多值转换器，将RGB分量转换为颜色画刷

## 运行说明

1. 确保安装了.NET Core 8.0 SDK
2. 克隆或下载此仓库
3. 打开解决方案文件
4. 按F5运行项目

## 学习要点

- 如何创建和使用值转换器
- 如何在数据绑定中应用转换器
- 如何使用转换器参数
- 多值转换器的实现和使用
- 基于MVVM的WPF应用程序结构

## 界面预览

应用程序包含多个选项卡，每个选项卡展示了不同类型的值转换器：

1. **布尔值转可见性**: 展示如何基于布尔值控制UI元素的可见性
2. **数值转换**: 展示如何对数值进行转换操作
3. **字符串格式化**: 展示如何格式化数据为具有特定格式的字符串
4. **枚举转文本**: 展示如何将枚举值转换为友好的显示文本
5. **多值转换器**: 展示如何使用多值转换器创建RGB颜色混合器

## 代码示例

```csharp
// 在XAML中使用转换器
<TextBlock Text="{Binding SelectedProduct.Price, 
           Converter={StaticResource StringFormatConverter}, 
           ConverterParameter=¥{0:N2}}"/>

// 定义转换器类
public class BoolToVisibilityConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        // 实现从布尔值到Visibility的转换
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        // 实现从Visibility到布尔值的转换
    }
}
``` 
