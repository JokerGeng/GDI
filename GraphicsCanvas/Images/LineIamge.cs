using GraphicsCanvas.Canvas;
using System.Drawing.Drawing2D;

namespace GraphicsCanvas.Images
{
    public class LineIamge : BasicImage
    {
        public LineIamge()
        {

        }
        /// <summary>
        /// 网格画笔
        /// </summary>
        protected System.Drawing.Pen LinePen = new System.Drawing.Pen(System.Drawing.Color.Red);
        public override void DrawImage(BasicsLayer layer)
        {
            DrawLine(layer);
        }

        private void DrawLine(BasicsLayer layer)
        {
            if (layer != null && layer.graphics != null && layer.WriteableBitmap != null)
            {
                //GraphicsPath path = new GraphicsPath();
                //DrawPath(ref path, layer);
                layer.graphics.DrawLine(LinePen, 0, 0, 400, 400);
            }
        }

        protected void DrawPath(ref GraphicsPath path, BasicsLayer layer)
        {
            //=============创建绘图路径=================================         

            path.FillMode = FillMode.Winding;

            ////===============绘制网格线=========================

            DrawBackLines(path, layer);

            ////===============绘制多边形=========================

            AddPolyLines(path, 100, 100);
            AddPolyLines(path, 150, 150);
            AddPolyLines(path, 200, 200);
            layer.graphics.DrawPath(new System.Drawing.Pen(System.Drawing.Color.Red, 0.5f), path);
        }

        protected void DrawBackLines(GraphicsPath gPath, BasicsLayer layer)
        {
            int pixelWidth = layer.WriteableBitmap.PixelWidth;
            int pixelHeight = layer.WriteableBitmap.PixelHeight;
            int interval = 3;
            int lines = pixelWidth / interval;
            if ((pixelWidth % interval) != 0)
                lines += 1;

            for (int i = 0; i <= lines; i++)
            {
                System.Drawing.Point tmp;
                tmp = new System.Drawing.Point((i) * interval, 0);
                if (tmp.X > pixelWidth)
                    tmp.X = pixelWidth;
                System.Drawing.Point StartPoint = tmp;
                tmp = new System.Drawing.Point((i) * interval, pixelHeight);
                if (tmp.X > pixelWidth)
                    tmp.X = pixelWidth;
                System.Drawing.Point EndPoint = tmp;
                gPath.AddLine(StartPoint, EndPoint);

                //=============关闭线段否则会和新绘制线段首尾相连===================================

                gPath.CloseFigure();

            }

            lines = (int)pixelHeight / interval;
            for (int i = 0; i <= lines; i++)
            {
                System.Drawing.Point tmp = new System.Drawing.Point(0, (i) * interval);
                if (tmp.Y > pixelHeight)
                    tmp.Y = pixelHeight;
                System.Drawing.Point StartPoint = tmp;
                tmp = new System.Drawing.Point(pixelWidth, (i) * interval);
                System.Drawing.Point EndPoint = tmp;
                gPath.AddLine(StartPoint, EndPoint);
                gPath.CloseFigure();
            }
        }

        protected void AddPolyLines(GraphicsPath gPath, int X, int Y)
        {
            //gPath.AddPolygon
            for (int i = 0; i < 3000; i++)
            {
                int x = X + i * 2;
                int y = Y + i * 2;
                gPath.AddPolygon(new System.Drawing.Point[] { new System.Drawing.Point(x + 20, y), new System.Drawing.Point(x, y + 20), new System.Drawing.Point(x + 20, y + 20) });
                gPath.CloseFigure();
            }
        }
    }
}
