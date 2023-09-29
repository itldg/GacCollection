/*
 * /////////////////////////////////////////////////////////////////////
 * Program   : TabSlider（标签滑动器）
 * Author    : hwenycocodq520（智商余额不足）
 * E-mail    : hwenycocodq520#163.com（#替换为@）
 * Date      : 2013/10/27
 * Resume    : 滑动标签页画布类
 *
 * Statement : Open Source
 * 
 * /////////////////////////////////////////////////////////////////////
 * Modifiy History
 * 
 * Date    :
 * Resume  :
 * 
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace Hweny.TabSlider
{
    /// <summary>
    /// 滑动标签页绘制画布
    /// </summary>
    [ToolboxItem(false)]
    internal class TabSlideCanvas : DoubleBufferCanvas
    {
        private TabSlider slider;
        /// <summary>
        /// 滑动标签页快照
        /// </summary>
        private Bitmap slidePageSnapshoot;
        private Bitmap lastSlidePageSnapshoot;

        public TabSlideCanvas(TabSlider slider)
        {
            Initialize(slider);
        }

        private void Initialize(TabSlider slider)
        {
            if (slider == null) return;
            this.slider = slider;
            this.slider.SlidePageChanged += new EventHandler(slider_SlidePageChanged);
            this.Disposed += new EventHandler(TabSlideCanvas_Disposed);
        }

        private void UpdateCanvas()
        {
            if (slidePageSnapshoot == null)
            {
                Size pageSize = slider.SlidePage.Owner.ClientSize;
                slidePageSnapshoot = new Bitmap(pageSize.Width, pageSize.Height);
                lastSlidePageSnapshoot = new Bitmap(pageSize.Width, pageSize.Height);
            }
            DrawSlidePageSnapshoot(slider.SlidePage.Owner, slidePageSnapshoot);
            if (slider.SlidePageEamless)
            {
                if (slider.LastSlidePage != null)
                {
                    DrawSlidePageSnapshoot(slider.LastSlidePage.Owner, lastSlidePageSnapshoot);
                }
            }
        }

        private void DrawSlidePageSnapshoot(Control target, Bitmap snapshoot)
        {
            Graphics g = Graphics.FromImage(snapshoot);
            g.Clear(target.BackColor);
            g.Dispose();
            target.DrawToBitmap(snapshoot, target.ClientRectangle);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (slider.Enabled)
            {
                Graphics g = e.Graphics;
                Color bgColor = slider.SlidePage.Owner.BackColor ==
                    Color.Transparent ?Color.White : slider.SlidePage.Owner.BackColor;
                g.Clear(bgColor);
                if (slider.SlidePageEamless && lastSlidePageSnapshoot != null)
                {
                    g.DrawImage(lastSlidePageSnapshoot, slider.LastSlidePage.Position);
                }
                if (slidePageSnapshoot != null)
                {
                    g.DrawImage(slidePageSnapshoot, slider.SlidePage.Position);
                }
            }
        }

        private void slider_SlidePageChanged(object sender, EventArgs e)
        {
            UpdateCanvas();
        }

        private void TabSlideCanvas_Disposed(object sender, EventArgs e)
        {
            lastSlidePageSnapshoot.Dispose();
            lastSlidePageSnapshoot = null;
            slidePageSnapshoot.Dispose();
            slidePageSnapshoot = null;
        }
    }
}
