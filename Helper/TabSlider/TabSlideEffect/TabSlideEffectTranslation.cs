/*
 * /////////////////////////////////////////////////////////////////////
 * Program   : TabSlider（标签滑动器）
 * Author    : hwenycocodq520（智商余额不足）
 * E-mail    : hwenycocodq520#163.com（#替换为@）
 * Date      : 2013/10/27
 * Resume    : 平移效果抽象类，所有类平移效果都继承它
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
namespace Hweny.TabSlider.TabSlideEffect
{
    /// <summary>
    /// 平移效果
    /// </summary>
    internal abstract class TabSlideEffectTranslation : ITabSlideEffect
    {
        protected static float MIN_DISTANCE = 1f;
        private int ticks;
        private int framePeriod;
        private double frameTicker;

        protected TabSlider slider;
        protected int duration;     
        protected int fps;
        protected Rectangle TargetBounds { get { return slider.SlidePage.Owner.ClientRectangle; } }

        public int Duration { get { return duration; } set { duration = value; } }
        public int Fps { get { return fps; } set { fps = value; framePeriod = 1000 / fps; } }

        protected TabSlideEffectTranslation(TabSlider slider) 
        {
            this.slider = slider;
            fps = 60;
            duration = 100;
            ticks = 0;
            frameTicker = 0;
            framePeriod = 1000 / fps;
        }

        /// <summary>
        /// 根据滑动方向初始化滑动标签页初始位置
        /// </summary>
        /// <param name="slider"></param>
        public virtual void Init()
        {
            ticks = 0;
            frameTicker = 0;
            switch (slider.EffectDirection)
            {
                case TabSlideEffectDirection.NONE:
                    SetPosition(TargetBounds.X, TargetBounds.Y);
                    break;
                case TabSlideEffectDirection.UP_TO_DOWN:
                    SetPosition(TargetBounds.X, TargetBounds.Height * (-1));
                    break;
                case TabSlideEffectDirection.DOWN_TO_UP:
                    SetPosition(TargetBounds.X, TargetBounds.Height);
                    break;
                case TabSlideEffectDirection.LEFT_TO_RIGHT:
                    SetPosition(TargetBounds.Width * (-1), TargetBounds.Y);
                    break;
                case TabSlideEffectDirection.RIGHT_TO_LEFT:
                    SetPosition(TargetBounds.Width, TargetBounds.Y);
                    break;
                case TabSlideEffectDirection.LEFT_UP_TO_RIGHT_DOWN:
                    SetPosition(TargetBounds.Width * (-1), TargetBounds.Height * (-1));
                    break;
                case TabSlideEffectDirection.RIGHT_DOWN_TO_LEFT_UP:
                    SetPosition(TargetBounds.Width, TargetBounds.Height);
                    break;
                case TabSlideEffectDirection.LEFT_DOWN_TO_RIGHT_UP:
                    SetPosition(TargetBounds.Width * (-1), TargetBounds.Height);
                    break;
                case TabSlideEffectDirection.RIGHT_UP_TO_LEFT_DOWN:
                    SetPosition(TargetBounds.Width, TargetBounds.Height * (-1));
                    break;
                default:
                    SetPosition(TargetBounds.X, TargetBounds.Y);
                    break;
            }
        }

        /// <summary>
        /// 播放效果
        /// </summary>
        /// <param name="sliderTime"></param>
        /// <param name="elapsedTime"></param>
        public void Play(double sliderTime, double elapsedTime)
        {
            if (ticks < duration)
            {
                if (sliderTime > frameTicker + framePeriod)
                {
                    frameTicker = sliderTime;
                    PlayEffect(sliderTime, elapsedTime);
                }
                ticks++;
            }
            else
            {
                OnEffectTimeOut();
            }
        }

        protected virtual void PlayEffect(double sliderTime, double elapsedTime)
        {
            slider.LastSlidePage.Move();
            slider.SlidePage.Move();
        }

        protected void AdjustTabPosition()
        {
            slider.LastSlidePage.Init();
            slider.SlidePage.Init();
        }

        protected virtual void OnEffectTimeOut(EventArgs e = null)
        {
            EventHandler temp = EffectTimeOut;
            if (temp != null)
            {              
                temp(this, e);
            }
        }

        protected virtual void OnEffectCompleted(EventArgs e = null)
        {
            EventHandler temp = EffectCompleted;
            if (temp != null)
            {
                AdjustTabPosition();
                temp(this, e);
            }
        }

        private void SetPosition(float x, float y)
        {
            this.slider.LastSlidePage.Init();
            this.slider.SlidePage.Position = new System.Drawing.PointF(x, y);
        }

        /// <summary>
        /// 效果时间片已用完事件
        /// </summary>
        public event EventHandler EffectTimeOut;
        /// <summary>
        /// 效果已完成事件
        /// </summary>
        public event EventHandler EffectCompleted;
    }
}
