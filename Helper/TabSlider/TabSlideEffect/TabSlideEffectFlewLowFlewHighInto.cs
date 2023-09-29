/*
 * /////////////////////////////////////////////////////////////////////
 * Program   : TabSlider（标签滑动器）
 * Author    : hwenycocodq520（智商余额不足）
 * E-mail    : hwenycocodq520#163.com（#替换为@）
 * Date      : 2013/10/27
 * Resume    : 先减速后加速飞入效果
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
    internal class TabSlideEffectFlewLowFlewHighInto : TabSlideEffectTranslation
    {
        private int MIN_LOW_DISTANCE = 10;
        private float MIN_LOW_SPEED = 0.5f;

        private float hypotenuse;

        public TabSlideEffectFlewLowFlewHighInto(TabSlider slider)
            : base(slider)
        {
            Duration = 300;
        }

        public override void Init()
        {
            base.Init();
            hypotenuse = (float)Math.Sqrt(Math.Pow(TargetBounds.Width, 2) + Math.Pow(TargetBounds.Height, 2));
        }

        protected override void PlayEffect(double sliderTime, double elapsedTime)
        {
            float dx = TargetBounds.X - slider.SlidePage.Position.X;
            float dy = TargetBounds.Y - slider.SlidePage.Position.Y;
            float dd = (float)Math.Sqrt(dx * dx + dy * dy);
            if (dd > MIN_DISTANCE)
            {
                float vx = 0f;
                float vy = 0f;
                switch (slider.EffectDirection)
                {
                    case TabSlideEffectDirection.UP_TO_DOWN:
                    case TabSlideEffectDirection.DOWN_TO_UP:
                        {
                            if (TargetBounds.Height - dd < MIN_LOW_DISTANCE)
                                vy = dy < 0 ? -MIN_LOW_SPEED : MIN_LOW_SPEED;
                            else
                                vy = dy * slider.SmoothingFactor;
                        }
                        break;
                    case TabSlideEffectDirection.LEFT_TO_RIGHT:
                    case TabSlideEffectDirection.RIGHT_TO_LEFT:
                        {
                            if (TargetBounds.Width - dd < MIN_LOW_DISTANCE)
                                vx = dx < 0 ? -MIN_LOW_SPEED : MIN_LOW_SPEED;
                            else
                                vx = dx * slider.SmoothingFactor;
                        }
                        break;
                    case TabSlideEffectDirection.LEFT_UP_TO_RIGHT_DOWN:
                    case TabSlideEffectDirection.RIGHT_DOWN_TO_LEFT_UP:
                    case TabSlideEffectDirection.LEFT_DOWN_TO_RIGHT_UP:
                    case TabSlideEffectDirection.RIGHT_UP_TO_LEFT_DOWN:
                        {
                            if (hypotenuse - dd < MIN_LOW_DISTANCE)
                            {
                                vx = dx < 0 ? -MIN_LOW_SPEED : MIN_LOW_SPEED;
                                vy = dy < 0 ? -MIN_LOW_SPEED : MIN_LOW_SPEED;
                            }
                            else
                            {
                                vx = dx * slider.SmoothingFactor;
                                vy = dy * slider.SmoothingFactor;
                            }
                        }
                        break;
                    default:        
                        break;
                }
                slider.SlidePage.Velocity.X = vx;
                slider.SlidePage.Velocity.Y = vy;
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
