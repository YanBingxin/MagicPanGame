using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Threading;

namespace MagicPan
{
    public class MagicBan : DependencyObject
    {
        public int Rows = 4;
        public int Columns = 4;
        int count = 0;
        /// <summary>
        /// 消耗时间
        /// </summary>
        public object Time { set; get; }
        /// <summary>
        /// 是否刷新UI界面
        /// </summary>
        public bool changed = false;
        /// <summary>
        /// 空盘
        /// </summary>
        private PanKey panNull = new PanKey();
        /// <summary>
        /// 全键盘
        /// </summary>
        public List<PanKey> pans = new List<PanKey>();
        /// <summary>
        /// 计时器
        /// </summary>
        public DispatcherTimer timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
        /// <summary>
        /// 随机生成器
        /// </summary>
        private Random random = new Random();
        /// <summary>
        /// 棋子图像画刷
        /// </summary>
        public List<Brush> PBrushes = new List<Brush>();
        public MagicBan()
        {
            timer.Tick += timer_Tick;
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
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows - 1 || (j < Rows && i < Columns - 1); j++)
                {
                    PanKey pk = new PanKey();
                    pk.X = i;
                    pk.Y = j;
                    pk.Value = i + Columns * j + 1;
                    pk.Click += pk_Click;
                    pans.Add(pk);
                }
            }
            panNull = new PanKey() { Template = null, Value = this.Rows * this.Columns, IsEnabled = false, X = Columns - 1, Y = Rows - 1 };
            pans.Add(panNull);
            #endregion

            #region 打乱棋盘
            //打乱
            for (int s = 0; s < 10000; s++)
            {
                int i = random.Next(0, 4);
                MovePanNull(i);
            }
            #endregion

            changed = true;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            count++;
            Time = TimeSpan.FromSeconds(count);
        }
        /// <summary>
        /// 点击棋子
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pk_Click(object sender, RoutedEventArgs e)
        {
            PanKey pan = sender as PanKey;
            //交换空块
            if (TrySwapToNull(pan))
                //验证是否完成魔板
                VertifyFinished();
        }

        /// <summary>
        /// 向xxx方向移动空键
        /// </summary>
        /// <param name="i"></param>
        private void MovePanNull(int i)
        {
            PanKey p = new PanKey();
            switch (i)
            {
                case 0://下
                    p = pans.FirstOrDefault(o => (o.X == panNull.X && o.Y == panNull.Y + 1));
                    break;
                case 1://上
                    p = pans.FirstOrDefault(o => (o.X == panNull.X && o.Y == panNull.Y - 1));
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
                TrySwapWithNull(p);
        }
        /// <summary>
        /// 单键与空键交换位置
        /// </summary>
        /// <param name="pan"></param>
        private void TrySwapWithNull(PanKey pan)
        {
            if (Math.Abs(pan.X - panNull.X) + Math.Abs(pan.Y - panNull.Y) == 1 && panNull.Template == null)
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
        /// 尝试向空格移动
        /// </summary>
        /// <param name="pan"></param>
        private bool TrySwapToNull(PanKey pan)
        {
            if (panNull.Template != null)
                return false;
            if (pan.X - panNull.X != 0 && pan.Y - panNull.Y != 0)
                return false;
            int a = pan.X - panNull.X;
            int b = pan.Y - panNull.Y;
            if (a > 0)
            {
                for (int i = 0; i < a; i++)
                {
                    MovePanNull(3);
                }
            }
            else if (a < 0)
            {
                for (int i = a; i < 0; i++)
                {
                    MovePanNull(2);
                }
            }
            else if (b > 0)
            {
                for (int i = 0; i < b; i++)
                {
                    MovePanNull(0);
                }
            }
            else if (b < 0)
            {
                for (int i = b; i < 0; i++)
                {
                    MovePanNull(1);
                }
            }
            changed = true;
            return true;
        }
        /// <summary>
        /// 检查是否全部完成
        /// </summary>
        /// <param name="pan"></param>
        private void VertifyFinished()
        {
            foreach (PanKey p in pans)
            {
                if (!p.CheckLocation(Columns))
                {
                    return;
                }
            }

            timer.Stop();

            //恢复空白格子模板
            Binding binding = new Binding("Template");
            binding.Source = pans[1];
            panNull.SetBinding(PanKey.TemplateProperty, binding);

            FinishedEvent.Invoke(Time.ToString());
        }

        public delegate void MagicBanFinishedHandler(string time);
        public event MagicBanFinishedHandler FinishedEvent;
    }
}
