using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MagicPan
{
    public static class CutImageToBrushesHelper
    {
        /// <summary>  
        /// 将图片切割成小图片,图片顺序为先垂直后水平  
        /// </summary>  
        /// <param name="fromImage"></param>  
        /// <param name="cx">x方向切割数</param>  
        /// <param name="cy">y方向切割数</param>  
        /// <returns></returns>  
        public static List<System.Windows.Media.Brush> CutImageToBrushes(this Image fromImage, int cx, int cy)
        {
            List<System.Windows.Media.Brush> brushes = new List<System.Windows.Media.Brush>();
            int nWidth = fromImage.Width / cx;
            int nHeight = fromImage.Height / cy;
            Bitmap image = new Bitmap(nWidth, nHeight);
            Graphics graphics = Graphics.FromImage(image);
            for (int i = 0; i < cx; i++)
            {
                for (int j = 0; j < cy; j++)
                {
                    graphics.DrawImage(fromImage, 0, 0, new Rectangle(i * nWidth, j * nHeight, nWidth, nHeight), GraphicsUnit.Pixel);
                    System.Windows.Media.Imaging.BitmapSource bi = Imaging.CreateBitmapSourceFromHBitmap(image.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    System.Windows.Media.Brush brush = new ImageBrush(bi);
                    brushes.Add(brush);
                }
            }
            return brushes;
        }
    }
}
