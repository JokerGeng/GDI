using GraphicsCanvas.Images;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GraphicsCanvas.Canvas
{
    public class TopLayer : BasicsLayer
    {
        
        public TopLayer()
        {

        }
        public TopLayer(BasicImage image)
        {
            BasicImages.Add(image);
        }

        public TopLayer(List<BasicImage> images )
        {
            BasicImages.AddRange(images);
        }

        /// <summary>
        /// 刷新界面
        /// </summary>
        public override void OnRefresh()
        {
            StartRender();
            //绘图逻辑
            foreach (var image in BasicImages)
            {
                image?.DrawImage(this);
            }
            EndRender();
        }

        public override void OnMouseLeftButtonDown(IInputElement inputElement, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(inputElement, e);
        }
        public override void OnMouseLeftButtonUp(IInputElement inputElement, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(inputElement, e);
        }
    }
}
