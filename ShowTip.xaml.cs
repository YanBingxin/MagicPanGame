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
using System.Windows.Shapes;

namespace MagicPan
{
    /// <summary>
    /// ShowTip.xaml 的交互逻辑
    /// </summary>
    public partial class ShowTip : Window
    {
        public ShowTip()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
