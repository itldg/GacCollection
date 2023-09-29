/*
 * /////////////////////////////////////////////////////////////////////
 * Program   : TabSlider（标签滑动器）
 * Author    : hwenycocodq520（智商余额不足）
 * E-mail    : hwenycocodq520#163.com（#替换为@）
 * Date      : 2013/10/27
 * Resume    : 滑动器标签页类
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
using System.Drawing;
using System.Windows.Forms;
namespace Hweny.TabSlider
{
    /// <summary>
    /// 滑动标签页
    /// </summary>
    internal class TabSlidePage
    {
        /// <summary>
        /// 所关联的标签控件
        /// </summary>
        public Control Owner { get; private set; }
        /// <summary>
        /// 滑动标签页位置
        /// </summary>
        public PointF Position;
        /// <summary>
        /// 滑动标签页速度
        /// </summary>
        public PointF Velocity;

        public TabSlidePage(Control owner)
        {
            Owner = owner;
        }

        /// <summary>
        /// 初始滑动标签页
        /// </summary>
        public void Init()
        {
            Velocity = new PointF(0f, 0f);
            Position = new PointF(Owner.ClientRectangle.X, Owner.ClientRectangle.Y);
        }
        /// <summary>
        /// 移动滑动标签页
        /// </summary>
        public void Move()
        {
            Position.X += Velocity.X;
            Position.Y += Velocity.Y;
        }
    }
}