using GraphicsCanvas.Images;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GraphicsCanvas.Canvas
{
    public abstract class BasicsLayer
    {
        public WriteableBitmap WriteableBitmap;

        protected Bitmap Bitmap;

        public Graphics graphics;

        public int XAxis;
        public int YAxis;

        /// <summary>
        /// 注册显示缓存区到UI
        /// </summary>
        /// <param name="drawingContext"></param>
        /// <param name="size"></param>
        public virtual void RegisterBitmap(DrawingContext drawingContext,System.Windows.Size size)
        {
            InitBitmap(size);
            drawingContext.DrawImage(WriteableBitmap, new System.Windows.Rect(size));
        }

        /// <summary>
        /// 初始化显示缓存区
        /// </summary>
        /// <param name="size"></param>
        private void InitBitmap(System.Windows.Size size)
        {
            WriteableBitmap = new WriteableBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Bgra32, null);
            Bitmap = new Bitmap(WriteableBitmap.PixelWidth, WriteableBitmap.PixelHeight, WriteableBitmap.BackBufferStride,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb, WriteableBitmap.BackBuffer);
            graphics = Graphics.FromImage(Bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.Clear(System.Drawing.Color.Transparent);
        }

        /// <summary>
        /// 开始更新显示缓存区
        /// </summary>
        protected void StartRender()
        {
            WriteableBitmap?.Lock();
            graphics?.Clear(System.Drawing.Color.Transparent);
        }

        /// <summary>
        /// 停止更新显示缓存区
        /// </summary>
        protected void EndRender()
        {
            graphics?.Flush();
            WriteableBitmap?.AddDirtyRect(new System.Windows.Int32Rect(0, 0, WriteableBitmap.PixelWidth, WriteableBitmap.PixelHeight));
            WriteableBitmap?.Unlock();
        }

        /// <summary>
        /// 刷新显示
        /// </summary>
        public abstract void OnRefresh();

        protected List<BasicImage> BasicImages { get; set; } = new List<BasicImage>();

        protected void InitBasicImage(List<BasicImage> images)
        {
            
        }

        #region MouseEvent

        public virtual void OnMouseLeftButtonDown(System.Windows.IInputElement inputElement, MouseButtonEventArgs e)
        {

        }

        public virtual void OnMouseLeftButtonUp(System.Windows.IInputElement inputElement, MouseButtonEventArgs e)
        {

        }

        #endregion MouseEvent
    }
}
