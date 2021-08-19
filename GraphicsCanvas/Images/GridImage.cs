using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using GraphicsCanvas.Canvas;

namespace GraphicsCanvas.Images
{
    public class GridImage : BasicImage
    {
        public GridImage()
        {

        }
        /// <summary>
        /// 网格画笔
        /// </summary>
        protected System.Drawing.Pen GridPen = new System.Drawing.Pen(System.Drawing.Color.DimGray);

        /// <summary>
        /// 网格分段
        /// </summary>
        private const int SegmentCount = 6;

        /// <summary>
        /// 绘制网格
        /// </summary>
        /// <param name="layer"></param>
        public override void DrawImage(BasicsLayer layer)
        {
            DrawGrid(layer);
        }

        /// <summary>
        /// 绘制网格
        /// </summary>
        /// <param name="layer"></param>
        private void DrawGrid(BasicsLayer layer)
        {
            if(layer!=null&&layer.graphics!=null&&layer.WriteableBitmap!=null)
            {
                float xOffset = 0;
                float yOffset = 0;

                float xInterval = (layer.WriteableBitmap.PixelWidth - xOffset) / SegmentCount;
                float yInterval = (layer.WriteableBitmap.PixelHeight - yOffset) / SegmentCount;
                float startX = xOffset;
                float startY = 0;

                #region Draw Horizontal Line

                for (int i = 0; i <= SegmentCount; i++)
                {
                    float x1 = startX;
                    float y1 = startY + (i * yInterval);
                    float x2 = (float)layer.WriteableBitmap.PixelWidth;
                    float y2 = y1;
                    if(SegmentCount==i)
                    {
                        layer.graphics.DrawLine(GridPen, x1, (y1 - 1), x2, (y2 - 1));
                    }
                    else
                    {
                        layer.graphics.DrawLine(GridPen, x1, y1, x2, y2);
                    }
                }

                #endregion

                #region Draw Vertical Line

                for (int i = 0; i <= SegmentCount; i++)
                {
                    float x1 = startX+(i * xInterval);
                    float y1 = startY;
                    float x2 = x1;
                    float y2 = layer.WriteableBitmap.PixelHeight - yOffset;
                    if (SegmentCount == i)
                    {
                        layer.graphics.DrawLine(GridPen, (x1 - 1), y1, (x2 - 1), y2);
                    }
                    else
                    {
                        layer.graphics.DrawLine(GridPen, x1, y1, x2, y2);
                    }
                }

                #endregion
            }
        }
    }
}
