using GraphicsCanvas.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsCanvas.Images
{
    public abstract class BasicImage
    {
        /// <summary>
        /// 绘图方法
        /// </summary>
        /// <param name="layer"></param>
        public abstract void DrawImage(BasicsLayer layer);


        #region MouseEvent

        public virtual void OnMouseLeftButtonDown(System.Windows.IInputElement sender, System.Windows.Input.MouseButtonEventArgs args)
        {
           
        }

        public virtual void OnMouseLeftButtonUp(System.Windows.IInputElement sender, System.Windows.Input.MouseButtonEventArgs args)
        {

        }

        public virtual void OnMouseMove(System.Windows.IInputElement sender, System.Windows.Input.MouseButtonEventArgs args)
        {

        }

        #endregion MouseEvent
    }
}
