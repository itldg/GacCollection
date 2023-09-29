/*
 * /////////////////////////////////////////////////////////////////////
 * Program   : TabSlider（标签滑动器）
 * Author    : hwenycocodq520（智商余额不足）
 * E-mail    : hwenycocodq520#163.com（#替换为@）
 * Date      : 2013/10/27
 * Resume    : 具有双缓冲效果的控件
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
using System.Windows.Forms;
namespace Hweny.TabSlider
{
    /// <summary>
    /// 双缓冲控件
    /// </summary>
    [ToolboxItem(false)]
    internal class DoubleBufferCanvas : Control
    {
        public DoubleBufferCanvas()
        {
            SetStyle
            (
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.CacheText,
                true
            );
            UpdateStyles();
        }
    }
}
