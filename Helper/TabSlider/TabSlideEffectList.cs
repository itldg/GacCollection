/*
 * /////////////////////////////////////////////////////////////////////
 * Program   : TabSlider（标签滑动器）
 * Author    : hwenycocodq520（智商余额不足）
 * E-mail    : hwenycocodq520#163.com（#替换为@）
 * Date      : 2013/10/27
 * Resume    : 滑动标签页效果列表
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
using System.Collections.Generic;
using Hweny.TabSlider.TabSlideEffect;
namespace Hweny.TabSlider
{
    /// <summary>
    /// 滑动标签页滑动效果列表
    /// </summary>
    internal class TabSlideEffectList
    {
        private TabSlider slider;
        private Dictionary<TabSlideEffectStyle, ITabSlideEffect> effects;

        public ITabSlideEffect this[TabSlideEffectStyle index]
        {
            get { return effects[index]; }
        }

        public TabSlideEffectList(TabSlider slider)
        {
            InitializeTabSlideEffects(slider);
        }

        private void InitializeTabSlideEffects(TabSlider slider)
        {
            this.slider = slider;
            effects = new Dictionary<TabSlideEffectStyle, ITabSlideEffect>();
            effects.Add(TabSlideEffectStyle.FLEW_INTO, new TabSlideEffectFlewInto(slider));
            effects.Add(TabSlideEffectStyle.FLEW_LOW_FLEW_HIGH_INTO, new TabSlideEffectFlewLowFlewHighInto(slider));
            //添加更多的效果
            //比如透明度、旋转、缩放等，该版本未实现这些效果

            foreach (ITabSlideEffect effect in effects.Values)
            {
                effect.EffectCompleted += new EventHandler(effect_EffectCompleted);
                effect.EffectTimeOut += new EventHandler(effect_EffectTimeOut);
            }
        }

        private void effect_EffectTimeOut(object sender, EventArgs e)
        {
            OnEffectTimeOut(sender,e);
        }

        private void effect_EffectCompleted(object sender, EventArgs e)
        {
            OnEffectCompleted(sender,e);
        }

        private void OnEffectTimeOut(object sender, EventArgs e)
        {
            EventHandler temp = EffectTimeOut;
            if (temp != null)
                temp(sender, e);
        }

        private void OnEffectCompleted(object sender,EventArgs e)
        {
            EventHandler temp = EffectCompleted;
            if (temp != null)
                temp(sender, e);
        }

        public event EventHandler EffectCompleted;
        public event EventHandler EffectTimeOut;
    }
}
