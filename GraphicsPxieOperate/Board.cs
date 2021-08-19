using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GraphicsPxieOperate
{
    public class Board:FrameworkElement
    {
        DrawingContext DrawingContext;
        WriteableBitmap WriteableBitmap;
        Bitmap Bitmap;
        Graphics Graphics;
        System.Drawing.Size rect;
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            rect = new System.Drawing.Size((int)RenderSize.Width, (int)RenderSize.Height);
            DrawingContext = drawingContext;
            WriteableBitmap = new WriteableBitmap((int)RenderSize.Width, (int)RenderSize.Height, 96, 96, PixelFormats.Bgra32, null);
            Bitmap = new Bitmap(WriteableBitmap.PixelWidth, WriteableBitmap.PixelHeight, WriteableBitmap.BackBufferStride, 
                System.Drawing.Imaging.PixelFormat.Format32bppArgb, WriteableBitmap.BackBuffer);
            Graphics = Graphics.FromImage(Bitmap);
            DrawingContext.DrawImage(WriteableBitmap, new Rect(0, 0, (int)RenderSize.Width, (int)RenderSize.Height));
            Update();
        }

        private void BeginRender()
        {
            WriteableBitmap?.Lock();
            Graphics?.Clear(System.Drawing.Color.Transparent);
        }

        private void EndRender()
        {
            Graphics?.Flush();
            WriteableBitmap?.AddDirtyRect(new Int32Rect(0, 0, rect.Width, rect.Height));
            WriteableBitmap?.Unlock();
        }

        private unsafe void Update()
        {
            //开始
            BeginRender();

            //画图逻辑
            Graphics.DrawLine(Pens.Red, 0, 400, 400, 0);
            PointF[] ps = new PointF[400];
            for (int i = 0; i < ps.Length; i++)
            {
                ps[i] = new PointF(i, i);
            }
            Graphics.DrawLines(Pens.Green, ps);

            //结束
            EndRender();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //像素操作
            BitmapData data = Bitmap.LockBits(new Rectangle(0, 0, rect.Width, rect.Height), 
                ImageLockMode.ReadWrite,System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            IntPtr ptr = data.Scan0;
            int* srcPtr = (int*)ptr.ToPointer();
            int sourceColor = System.Drawing.Color.Red.ToArgb();
            int targetColor = System.Drawing.Color.Blue.ToArgb();
            //int stride = data.Stride;
            int stride = rect.Width;
            int drc = 0;
            for (int column = 0; column < rect.Height; column++)
            {
                for (int row = 0; row < rect.Width; row++)
                {
                    if (row < ps.Length && column >= ps[row].Y)
                    {
                        drc = column * stride + row;
                        int clr = *(srcPtr + drc);
                        if (clr == sourceColor)
                        {
                            *(srcPtr + drc) = targetColor;
                        }
                    }
                }
            }

            Bitmap.UnlockBits(data);

            stopwatch.Stop();
            Console.WriteLine("Time={0}", stopwatch.ElapsedMilliseconds);
        }
    }
}
