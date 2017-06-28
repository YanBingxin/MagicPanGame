﻿using System;
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
        bool changed = false;
        /// <summary>
        /// 空盘
        /// </summary>
        private PanKey panNull = new PanKey() { Template = null, Value = 16, Content = 16, IsEnabled = false, X = 3, Y = 3 };
        /// <summary>
        /// 全键盘
        /// </summary>
        private List<PanKey> pans = new List<PanKey>();
        /// <summary>
        /// 计时器
        /// </summary>
        DispatcherTimer timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
        /// <summary>
        /// 随机生成器
        /// </summary>
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += timer_Tick;
            this.Loaded += MainWindow_Loaded;
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Top = 0;
            this.Left = SystemParameters.FullPrimaryScreenWidth - this.ActualWidth;
        }
        /// <summary>
        /// 绘图UI界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (!changed)
                return;
            gd.Children.Clear();
            foreach (PanKey p in pans)
            {
                p.Content = p.Value.ToString();
                Grid.SetRow(p, p.Y);
                Grid.SetColumn(p, p.X);
                gd.Children.Add(p);
            }
            changed = false;
        }
        /// <summary>
        /// 创建新盘
        /// </summary>
        public void CreatePan()
        {
            count = 0;
            pans.Clear();

            #region 生成对象
            //生成对象
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3 || (j < 4 && i < 3); j++)
                {
                    PanKey pk = new PanKey();
                    pk.X = i;
                    pk.Y = j;
                    pk.Value = i + 4 * j + 1;
                    pans.Add(pk);
                }
            }
            panNull = new PanKey() { Template = null, Value = 16, Content = 16, IsEnabled = false, X = 3, Y = 3 };
            pans.Add(panNull);
            #endregion

            #region 打乱棋盘
            //打乱
            for (int s = 0; s < 10000; s++)
            {
                int i = random.Next(0, 4);
                PanKey p = new PanKey();
                switch (i)
                {
                    case 1://上
                        p = pans.FirstOrDefault(o => (o.X == panNull.X && o.Y == panNull.Y - 1));
                        break;
                    case 0://下
                        p = pans.FirstOrDefault(o => (o.X == panNull.X && o.Y == panNull.Y + 1));
                        break;
                    case 2://左
                        p = pans.FirstOrDefault(o => (o.X == panNull.X - 1 && o.Y == panNull.Y));
                        break;
                    case 3://右
                        p = pans.FirstOrDefault(o => (o.X == panNull.X + 1 && o.Y == panNull.Y));
                        break;
                    default:
                        break;
                }
                if (p != null)
                    TryMoveToNull(p);

            }
            #endregion

            changed = true;
            timer.Start();
        }

        int count = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            count++;
            time.Content = TimeSpan.FromSeconds(count);
        }
        /// <summary>
        /// 点击棋子
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gd_Click(object sender, RoutedEventArgs e)
        {
            PanKey pan = e.Source as PanKey;
            //交换空块
            TryMoveToNull(pan);
            //验证是否完成魔板
            VertifyFinished();
        }
        /// <summary>
        /// 尝试向空格移动
        /// </summary>
        /// <param name="pan"></param>
        private void TryMoveToNull(PanKey pan)
        {
            if (Math.Abs(pan.X - panNull.X) + Math.Abs(pan.Y - panNull.Y) == 1)
            {
                int x = pan.X;
                int y = pan.Y;
                pan.X = panNull.X;
                pan.Y = panNull.Y;
                panNull.X = x;
                panNull.Y = y;
                changed = true;
            }
        }
        /// <summary>
        /// 检查是否全部完成
        /// </summary>
        /// <param name="pan"></param>
        private void VertifyFinished()
        {
            foreach (PanKey p in pans)
            {
                if (!p.CheckLocation())
                {
                    return;
                }
            }

            timer.Stop();
            panNull.Template = pans[1].Template;
            ShowTip tip = new ShowTip();
            tip.Owner = this;
            tip.lbTip.Content = "恭喜你完成了！真棒，成绩：" + time.Content;
            tip.ShowDialog();
        }
        /// <summary>
        /// 重新开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreatePan();
        }
        #region 隐蔽性
        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Opacity = 1;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Opacity = 0.1;
        }
        #endregion
    }
}
