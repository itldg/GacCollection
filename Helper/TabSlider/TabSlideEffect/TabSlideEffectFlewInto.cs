/*
 * /////////////////////////////////////////////////////////////////////
 * Program   : TabSlider（标签滑动器）
 * Author    : hwenycocodq520（智商余额不足）
 * E-mail    : hwenycocodq520#163.com（#替换为@）
 * Date      : 2013/10/27
 * Resume    : 飞入效果
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
    internal class TabSlideEffectFlewInto : TabSlideEffectTranslation
    {
        public TabSlideEffectFlewInto(TabSlider slider)
            : base(slider)
        {

        }

        protected override void PlayEffect(double sliderTime, double elapsedTime)
        {
            float dx = TargetBounds.X - slider.SlidePage.Position.X;
            float dy = TargetBounds.Y - slider.SlidePage.Position.Y;
            float dd = (float)Math.Sqrt(dx * dx + dy * dy);
            if (dd > MIN_DISTANCE)
            {
                slider.SlidePage.Velocity.X = dx * slider.SmoothingFactor;
                slider.SlidePage.Velocity.Y = dy * slider.SmoothingFactor;
                slider.LastSlidePage.Velocity.X = slider.SlidePage.Velocity.X;
                slider.LastSlidePage.Velocity.Y = slider.SlidePage.Velocity.Y;
                base.PlayEffect(sliderTime, elapsedTime);
            }
            else
            {
                OnEffectCompleted();
            }
        }
    }
}
