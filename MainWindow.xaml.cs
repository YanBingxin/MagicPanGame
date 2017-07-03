using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MagicPan
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region 属性、成员

        /// <summary>
        /// 图片路径
        /// </summary>
        private string _fileName;
        /// <summary>
        /// 获取或设置图片路径
        /// </summary>
        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                if (_fileName == value)
                {
                    return;
                }
                _fileName = value;
                RaisePropertyChanged("FileName");
            }
        }

        /// <summary>
        /// 是否采用图像模式
        /// </summary>
        private bool _isImagePanKey = false;
        /// <summary>
        /// 获取或设置是否采用图像模式
        /// </summary>
        public bool IsImagePanKey
        {
            get
            {
                return _isImagePanKey;
            }
            set
            {
                _isImagePanKey = value;
                RaisePropertyChanged("IsImagePanKey");
            }
        }

        MagicBan Ban = new MagicBan();
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }
        /// <summary>
        /// 窗口位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Top = 0;
            this.Left = SystemParameters.FullPrimaryScreenWidth - this.ActualWidth;
            this.MouseEnter += delegate { this.Opacity = 1; };
            this.MouseLeave += delegate { this.Opacity = 0.1; };
            this.lbGo.MouseDown += InitializeMagicPan;
            this.lbPng.MouseDown += delegate { cmPng.IsOpen = true; };
            this.lbSetDown.MouseDown += delegate
            {
                if (Ban.Columns == 2 || Ban.Rows == 2)
                    return;
                Ban.Columns--;
                Ban.Rows--;
                InitializeMagicPan(null, null);
            };
            this.lbSetUp.MouseDown += delegate
            {
                if (Ban.Columns == 16 || Ban.Rows == 16)
                    return;
                Ban.Columns++;
                Ban.Rows++;
                InitializeMagicPan(null, null);
            };
            Ban.timer.Tick += (s, arg) => { lbTime.Content = Ban.Time; };
            Ban.FinishedEvent += Ban_FinishedEvent;
        }
        /// <summary>
        /// 初始化Grid创建新拼图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitializeMagicPan(object sender, MouseButtonEventArgs e)
        {
            gd.ColumnDefinitions.Clear();
            gd.RowDefinitions.Clear();
            for (int i = 0; i < Ban.Columns; i++)
            {
                gd.ColumnDefinitions.Add(new ColumnDefinition() { });
            }
            for (int i = 0; i < Ban.Rows; i++)
            {
                gd.RowDefinitions.Add(new RowDefinition() { });
            }

            Ban.CreatePan();
            ApplyBrushes(FileName);
            CreateTooltip();
        }

        /// <summary>
        /// 制作自定义背景模式
        /// </summary>
        private void ApplyBrushes(string path)
        {
            try
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(path);
                if (image.HorizontalResolution != 96 || image.VerticalResolution != 96)
                {
                    ShowTip tip = new ShowTip();
                    tip.Owner = this;
                    tip.lbTip.Content = "所选图片不是标准96dpi,将无法得到最佳体验";
                    tip.ShowDialog();
                }
                Ban.PBrushes = image.CutImageToBrushes(Ban.Rows, Ban.Columns);
                for (int i = 0; i < Ban.pans.Count; i++)
                {
                    Ban.pans[i].Background = Ban.PBrushes[i];
                }
            }
            catch (Exception) { }
        }
        /// <summary>
        /// 创建提示
        /// </summary>
        private void CreateTooltip()
        {
            gdTip.Children.Clear();
            gdTip.ColumnDefinitions.Clear();
            gdTip.RowDefinitions.Clear();
            for (int i = 0; i < Ban.Columns; i++)
            {
                gdTip.ColumnDefinitions.Add(new ColumnDefinition() { });
            }
            for (int i = 0; i < Ban.Rows; i++)
            {
                gdTip.RowDefinitions.Add(new RowDefinition() { });
            }
            for (int i = 0; i < Ban.Columns; i++)
            {
                for (int j = 0; j < Ban.Rows; j++)
                {
                    PanKey p = new PanKey();
                    p.Value = i + j * Ban.Columns + 1;
                    Grid.SetColumn(p, i);
                    Grid.SetRow(p, j);
                    gdTip.Children.Add(p);
                    if (Ban.PBrushes.Count > i * Ban.Columns + j)
                        p.Background = Ban.PBrushes[i * Ban.Columns + j];
                }
            }
        }

        /// <summary>
        /// 绘图UI界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (Ban.changed)
            {
                gd.Children.Clear();
                foreach (PanKey p in Ban.pans)
                {
                    Grid.SetRow(p, p.Y);
                    Grid.SetColumn(p, p.X);
                    gd.Children.Add(p);
                }
                Ban.changed = false;
            }
        }
        /// <summary>
        /// 结束提示
        /// </summary>
        /// <param name="time"></param>
        void Ban_FinishedEvent(string time)
        {
            ShowTip tip = new ShowTip();
            tip.Owner = this;
            tip.lbTip.Content = "恭喜你完成了！真棒，成绩：" + time;
            tip.ShowDialog();
        }

        #region INotifyPropertyChanged 成员

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 属性改变通知:属性名
        /// </summary>
        /// <param name="name"></param>
        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region 高级设置
        /// <summary>
        /// 切换图片数字模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FileName))
            {
                ShowTip tip = new ShowTip();
                tip.Owner = this;
                tip.lbTip.Content = "请先在☆设置里选择本地拼图路径";
                tip.ShowDialog();
                return;
            }
            IsImagePanKey = !IsImagePanKey;
        }

        /// <summary>
        /// 选择本地图片并开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dia = new System.Windows.Forms.OpenFileDialog();
            dia.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG)|*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG";
            if (dia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileName = dia.FileName;
                InitializeMagicPan(null, null);
                IsImagePanKey = true;
            }
        }
        #endregion
    }
}
