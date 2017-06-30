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
            this.lbGo.MouseDown += delegate { Ban.CreatePan(); };
            Ban.timer.Tick += (s, arg) => { lbTime.Content = Ban.Time; };
            Ban.FinishedEvent += Ban_FinishedEvent;
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
