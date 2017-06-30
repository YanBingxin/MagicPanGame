using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MagicPan
{
    public class PanKey : Button
    {
        public int X
        {
            get { return (int)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }

        public int Y
        {
            get { return (int)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(PanKey), new PropertyMetadata(10));


        // Using a DependencyProperty as the backing store for Y.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(int), typeof(PanKey), new PropertyMetadata(10));


        // Using a DependencyProperty as the backing store for X.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(int), typeof(PanKey), new PropertyMetadata(100));

        public bool CheckLocation(int columns)
        {
            return X + columns * Y + 1 == Value;
        }
    }
}
