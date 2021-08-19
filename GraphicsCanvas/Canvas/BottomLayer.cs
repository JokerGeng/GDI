using GraphicsCanvas.Images;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GraphicsCanvas.Canvas
{
    public class BottomLayer:BasicsLayer
    {
        public BottomLayer()
        {

        }

        public BottomLayer(BasicImage image)
        {
            BasicImages.Add(image);
        }

        public BottomLayer(List<BasicImage> images )
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
    }
}
