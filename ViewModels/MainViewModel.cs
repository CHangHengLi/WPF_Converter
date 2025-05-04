using System.Collections.ObjectModel;
using WpfConverterDemo.Commands;
using WpfConverterDemo.Models;

namespace WpfConverterDemo.ViewModels
{
    /// <summary>
    /// 主窗口的视图模型
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region 私有字段
        private bool _showDetails;
        private double _sliderValue;
        private decimal _numberValue;
        private Product? _selectedProduct;
        private Order? _selectedOrder;
        private byte _redValue;
        private byte _greenValue;
        private byte _blueValue;
        #endregion

        #region 公共属性
        /// <summary>
        /// 是否显示详细信息
        /// </summary>
        public bool ShowDetails
        {
            get => _showDetails;
            set => SetProperty(ref _showDetails, value);
        }

        /// <summary>
        /// 滑块值（0-1）
        /// </summary>
        public double SliderValue
        {
            get => _sliderValue;
            set => SetProperty(ref _sliderValue, value);
        }

        /// <summary>
        /// 数值示例
        /// </summary>
        public decimal NumberValue
        {
            get => _numberValue;
            set => SetProperty(ref _numberValue, value);
        }

        /// <summary>
        /// 产品列表
        /// </summary>
        public ObservableCollection<Product> Products { get; } = new();

        /// <summary>
        /// 选中的产品
        /// </summary>
        public Product? SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        /// <summary>
        /// 订单列表
        /// </summary>
        public ObservableCollection<Order> Orders { get; } = new();

        /// <summary>
        /// 选中的订单
        /// </summary>
        public Order? SelectedOrder
        {
            get => _selectedOrder;
            set => SetProperty(ref _selectedOrder, value);
        }

        /// <summary>
        /// 红色值（0-255）
        /// </summary>
        public byte RedValue
        {
            get => _redValue;
            set => SetProperty(ref _redValue, value);
        }

        /// <summary>
        /// 绿色值（0-255）
        /// </summary>
        public byte GreenValue
        {
            get => _greenValue;
            set => SetProperty(ref _greenValue, value);
        }

        /// <summary>
        /// 蓝色值（0-255）
        /// </summary>
        public byte BlueValue
        {
            get => _blueValue;
            set => SetProperty(ref _blueValue, value);
        }
        #endregion

        #region 命令
        /// <summary>
        /// 切换详情显示命令
        /// </summary>
        public RelayCommand ToggleDetailsCommand { get; }

        /// <summary>
        /// 切换产品可用性命令
        /// </summary>
        public RelayCommand ToggleProductAvailabilityCommand { get; }

        /// <summary>
        /// 切换订单状态命令
        /// </summary>
        public RelayCommand ChangeOrderStatusCommand { get; }
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public MainViewModel()
        {
            // 初始化命令
            ToggleDetailsCommand = new RelayCommand(_ => ShowDetails = !ShowDetails);
            ToggleProductAvailabilityCommand = new RelayCommand(_ =>
            {
                if (SelectedProduct != null)
                {
                    SelectedProduct.IsAvailable = !SelectedProduct.IsAvailable;
                    // 触发属性变更通知以刷新UI
                    OnPropertyChanged(nameof(SelectedProduct));
                }
            });
            ChangeOrderStatusCommand = new RelayCommand(_ =>
            {
                if (SelectedOrder != null)
                {
                    // 循环切换订单状态
                    SelectedOrder.Status = (OrderStatus)(((int)SelectedOrder.Status + 1) % 5);
                    // 触发属性变更通知以刷新UI
                    OnPropertyChanged(nameof(SelectedOrder));
                }
            });

            // 初始化默认值
            _showDetails = false;
            _sliderValue = 0.5;
            _numberValue = 100.0m;
            _redValue = 120;
            _greenValue = 180;
            _blueValue = 220;

            // 初始化产品列表
            Products.Add(new Product { Id = 1, Name = "笔记本电脑", Price = 5999.00m, IsAvailable = true, Description = "高性能笔记本电脑，适合办公和游戏。" });
            Products.Add(new Product { Id = 2, Name = "智能手机", Price = 3999.00m, IsAvailable = true, Description = "最新款智能手机，拍照性能出色。" });
            Products.Add(new Product { Id = 3, Name = "无线耳机", Price = 999.00m, IsAvailable = false, Description = "降噪无线耳机，音质清晰。" });
            Products.Add(new Product { Id = 4, Name = "平板电脑", Price = 2599.00m, IsAvailable = true, Description = "轻薄平板电脑，支持手写笔。" });
            
            // 设置默认选中产品
            SelectedProduct = Products[0];

            // 初始化订单列表
            Orders.Add(new Order
            {
                Id = 1,
                OrderNumber = "ORD-2023-0001",
                CustomerName = "张三",
                Amount = 5999.00m,
                Status = OrderStatus.WaitingForPayment,
                OrderDate = DateTime.Now.AddDays(-2)
            });
            Orders.Add(new Order
            {
                Id = 2,
                OrderNumber = "ORD-2023-0002",
                CustomerName = "李四",
                Amount = 4998.00m,
                Status = OrderStatus.Processing,
                OrderDate = DateTime.Now.AddDays(-1)
            });
            Orders.Add(new Order
            {
                Id = 3,
                OrderNumber = "ORD-2023-0003",
                CustomerName = "王五",
                Amount = 3598.00m,
                Status = OrderStatus.Shipped,
                OrderDate = DateTime.Now.AddHours(-12)
            });
            Orders.Add(new Order
            {
                Id = 4,
                OrderNumber = "ORD-2023-0004",
                CustomerName = "赵六",
                Amount = 999.00m,
                Status = OrderStatus.Completed,
                OrderDate = DateTime.Now.AddDays(-5)
            });
            Orders.Add(new Order
            {
                Id = 5,
                OrderNumber = "ORD-2023-0005",
                CustomerName = "钱七",
                Amount = 2599.00m,
                Status = OrderStatus.Canceled,
                OrderDate = DateTime.Now.AddDays(-3)
            });
            
            // 设置默认选中订单
            SelectedOrder = Orders[0];
        }
    }
} 