using GraphicsCanvas.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace GraphicsCanvas.Canvas
{
    public class DrawingBoard:FrameworkElement
    {
        public DrawingBoard()
        {
            BottomLayer = new BottomLayer(new GridImage());
            TopLayer = new TopLayer(new LineIamge());
        }
        TopLayer TopLayer { get; set; }     
        BottomLayer BottomLayer { get; set; }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            BottomLayer.RegisterBitmap(drawingContext, this.RenderSize);
            TopLayer.RegisterBitmap(drawingContext, this.RenderSize);
            OnRefresh();
        }

        /// <summary>
        /// 刷新界面
        /// </summary>
        public void OnRefresh()
        {
            BottomLayer.OnRefresh();
            TopLayer.OnRefresh();
        }


        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            //TopLayer.OnMouseLeftButtonDown(this, e);
            //Mouse.Capture(this);
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            //TopLayer.OnMouseLeftButtonUp(this, e);
            //Mouse.Capture(this);
        }
    }
}
