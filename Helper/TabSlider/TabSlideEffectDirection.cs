/*
 * /////////////////////////////////////////////////////////////////////
 * Program   : TabSlider（标签滑动器）
 * Author    : hwenycocodq520（智商余额不足）
 * E-mail    : hwenycocodq520#163.com（#替换为@）
 * Date      : 2013/10/27
 * Resume    : 标签页滑动效果方向枚举
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
namespace Hweny.TabSlider
{
    /// <summary>
    /// 标签页滑动方向
    /// </summary>
    public enum TabSlideEffectDirection
    {
        /// <summary>
        /// 无方向
        /// </summary>
        NONE,
        /// <summary>
        /// 从上往下
        /// </summary>
        UP_TO_DOWN,
        /// <summary>
        /// 从下往上
        /// </summary>
        DOWN_TO_UP,
        /// <summary>
        /// 从左往右
        /// </summary>
        LEFT_TO_RIGHT,
        /// <summary>
        /// 从右往左
        /// </summary>
        RIGHT_TO_LEFT,
        /// <summary>
        /// 从左上往右下
        /// </summary>
        LEFT_UP_TO_RIGHT_DOWN,
        /// <summary>
        /// 从右下往左上
        /// </summary>
        RIGHT_DOWN_TO_LEFT_UP,
        /// <summary>
        /// 从左下往右上
        /// </summary>
        LEFT_DOWN_TO_RIGHT_UP,
        /// <summary>
        /// 从右上往左下
        /// </summary>
        RIGHT_UP_TO_LEFT_DOWN
    }
}
