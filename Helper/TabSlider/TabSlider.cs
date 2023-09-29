/*
 * /////////////////////////////////////////////////////////////////////
 * Program   : TabSlider（标签滑动器）
 * Author    : hwenycocodq520（智商余额不足）
 * E-mail    : hwenycocodq520#163.com（#替换为@）
 * Date      : 2013/10/27
 * Resume    : 标签滑动器类
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
using System.Windows.Forms;
using System.Drawing;
using Hweny.TabSlider.TabSlideEffect;
namespace Hweny.TabSlider
{
    public class TabSlider
    {
        #region Fields
        private float smoothingFactor = 0.16f;
        /// <summary>
        /// 上次滑动时间
        /// </summary>
        private double lastSlideTime;
        /// <summary>
        /// 定时器
        /// </summary>
        private System.Windows.Forms.Timer timer;
        /// <summary>
        /// 标签页集合
        /// </summary>
        private List<TabSlidePage> slidePages;
        /// <summary>
        /// 当前滑动标签页索引
        /// </summary>
        private int slidePageIndex;
        /// <summary>
        /// 上一次滑动标签页索引
        /// </summary>
        private int lastSlidePageIndex;
        /// <summary>
        /// 标签滑动画布
        /// </summary>
        private TabSlideCanvas slideCanvas;
        /// <summary>
        /// 滑动效果列表
        /// </summary>
        private TabSlideEffectList effectList;
        /// <summary>
        /// 当前使用的滑动效果
        /// </summary>
        private ITabSlideEffect effect;

        #endregion

        #region Properties

        /// <summary>
        ///平滑滑动系数
        /// </summary>
        public float SmoothingFactor
        { 
            get 
            { 
                return smoothingFactor; 
            }
            set
            {
                if (value <= 0 || value > 1) throw new ArgumentOutOfRangeException();
                this.smoothingFactor = value;
            }
        }
        /// <summary>
        /// 无缝切换标签页
        /// </summary>
        public bool SlidePageEamless { get; set; }
        /// <summary>
        /// 效果出现方向
        /// </summary>
        public TabSlideEffectDirection EffectDirection { get; set; }
        /// <summary>
        /// 当前标签页
        /// </summary>
        internal TabSlidePage SlidePage { get { return slidePages[slidePageIndex]; } }
        /// <summary>
        /// 上一张标签页
        /// </summary>
        internal TabSlidePage LastSlidePage { get { return slidePages[lastSlidePageIndex]; } }
        /// <summary>
        /// 标签滑动器是否在工作
        /// </summary>
        public bool Enabled { get { return timer.Enabled; } }

        public int SlidePageCount { get { return slidePages.Count; } }

        #endregion

        #region Constructor

        /// <summary>
        /// 标签滑动器构造函数
        /// </summary>
        public TabSlider()
        {
            Initialize();
        }

        #endregion

        #region Private members

        /// <summary>
        /// 初始化标签滑动器
        /// </summary>
        private void Initialize()
        {
            slidePages = new List<TabSlidePage>();
            slideCanvas = new TabSlideCanvas(this);
            slideCanvas.Visible = false;
            lastSlidePageIndex = 0;

            SlidePageEamless = false;
            EffectDirection = TabSlideEffectDirection.RIGHT_TO_LEFT;

            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += new EventHandler(timer_Tick);

            effectList = new TabSlideEffectList(this);
            effectList.EffectCompleted += new EventHandler(effect_EffectCompleted);
            effectList.EffectTimeOut += new EventHandler(effect_EffectTimeOut);
            SetEffect(TabSlideEffectStyle.FLEW_INTO);
        }

        /// <summary>
        /// 更新滑动画布
        /// </summary>
        private void UpdateSlideCanvas()
        {
            Rectangle bounds = SlidePage.Owner.ClientRectangle;
            slideCanvas.Location = new Point(bounds.X, bounds.Y);
            slideCanvas.Size = new Size(bounds.Width, bounds.Height);
            slideCanvas.Visible = true;
            SlidePage.Owner.Controls.Add(slideCanvas);
            slideCanvas.BringToFront();
        }

        #endregion

        #region Public members

        /// <summary>
        /// 添加滑动标签
        /// </summary>
        /// <param name="owner"></param>
        public void AddTabSlidePage(Control owner)
        {
            TabSlidePage page = new TabSlidePage(owner);
            slidePages.Add(page);
        }

        /// <summary>
        /// 滑动标签
        /// </summary>
        /// <param name="index">标签索引</param>
        public void Slide(int index)
        {
            if (slidePages.Count == 0) return;
            if (index < 0 || index > slidePages.Count - 1) return;

            lastSlidePageIndex = slidePageIndex;
            slidePageIndex = index;

            LastSlidePage.Owner.Controls.Remove(slideCanvas);

            OnSlidePageChanged();
            UpdateSlideCanvas();

            effect.Init();
            timer.Start();
        }

        /// <summary>
        /// 设置标签滑动效果
        /// </summary>
        /// <param name="style">效果类型</param>
        /// <param name="duration">持续时间</param>
        /// <param name="fps">每秒帧数</param>
        public void SetEffect(TabSlideEffectStyle style, int duration = 200, int fps = 60)
        {
            effect = effectList[style];
            effect.Duration = duration;
            effect.Fps = fps;
        }

        #endregion

        #region Events

        /// <summary>
        /// 定时器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            double slideTime = Environment.TickCount;
            double elapsedTime = slideTime - lastSlideTime;
            lastSlideTime = slideTime;
            effect.Play(slideTime, elapsedTime);
            slideCanvas.Invalidate();
        }

        /// <summary>
        /// 效果时间片已用完
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void effect_EffectTimeOut(object sender, EventArgs e)
        {
            timer.Stop();
            slideCanvas.Visible = false;
        }

        /// <summary>
        /// 效果已完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void effect_EffectCompleted(object sender, EventArgs e)
        {
            slideCanvas.Visible = false;
        }

        /// <summary>
        /// 当滑动标签改变时响应该事件
        /// </summary>
        /// <param name="e"></param>
        private void OnSlidePageChanged(EventArgs e = null)
        {
            EventHandler temp = SlidePageChanged;
            if (temp != null)
                temp(this,e);
        }

        /// <summary>
        /// 滑动标签改变事件
        /// </summary>
        public event EventHandler SlidePageChanged;

        #endregion
    }
}
