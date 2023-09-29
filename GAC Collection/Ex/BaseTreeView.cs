using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GAC_Collection.Ex
{
    public partial class BaseTreeView : TreeView
    {
        public BaseTreeView()
        {
            InitializeComponent();
        }

        private void BaseTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            ////如果按照默认实现来绘制，就这样做
            //if (e.Node.Level > 0)
            //{
            //    e.DrawDefault = true;
            //    return;
            //}
            ////绘制的工作就完全是GDI+的那一套了
            //LinearGradientMode mode = LinearGradientMode.Vertical;
            //Rectangle rect = e.Bounds;
            ////绘制渐变背景
            //using (LinearGradientBrush brush = new LinearGradientBrush(rect, _startColor, _endColor, mode))
            //{
            //    e.Graphics.FillRectangle(brush, rect);
            //}
            //Font nodeFont = new Font("宋体",12);
            //////绘制加减号，做了一些硬编码
            ////e.Graphics.DrawImage((e.Node.IsExpanded ? _minusImage : _plusImage), e.Bounds.Location.X + 5, e.Bounds.Location.Y + 3);
            ////绘制文字
            //e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.Black, (e.Bounds.Location.X + 20), (e.Bounds.Location.Y));
        }
    }
}
