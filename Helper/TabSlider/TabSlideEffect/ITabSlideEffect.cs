/*
 * /////////////////////////////////////////////////////////////////////
 * Program   : TabSlider（标签滑动器）
 * Author    : hwenycocodq520（智商余额不足）
 * E-mail    : hwenycocodq520#163.com（#替换为@）
 * Date      : 2013/10/27
 * Resume    : 效果接口
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
namespace Hweny.TabSlider.TabSlideEffect
{
    internal interface ITabSlideEffect
    {
        int Duration { get; set; }
        int Fps { get; set; }
        void Init();
        void Play(double sliderTime, double elapsedTime);

        event EventHandler EffectCompleted;
        event EventHandler EffectTimeOut;
    }
}
