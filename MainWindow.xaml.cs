using System;
using System.Collections.Generic;
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
    public partial class MainWindow : Window
    {
        MagicBan Ban = new MagicBan();

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

            CreateTooltip();

            Ban.CreatePan();
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
            for (int i = 0; i < Ban.Rows; i++)
            {
                for (int j = 0; j < Ban.Columns; j++)
                {
                    PanKey p = new PanKey();
                    p.Value = j + i * Ban.Columns + 1;
                    Grid.SetColumn(p, j);
                    Grid.SetRow(p, i);
                    gdTip.Children.Add(p);
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
    }
}
