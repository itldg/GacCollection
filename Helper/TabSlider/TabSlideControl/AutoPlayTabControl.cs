/*
 * /////////////////////////////////////////////////////////////////////
 * Program   : TabSlider（标签滑动器）
 * Author    : hwenycocodq520（智商余额不足）
 * E-mail    : hwenycocodq520#163.com（#替换为@）
 * Date      : 2013/10/27
 * Resume    : 自动滑动标签页类
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
using System.Windows.Forms;
namespace Hweny.TabSlider.TabSlideControl
{
    public class AutoPlayTabControl : SlideableTabControl
    {
        private System.Windows.Forms.Timer timer;
        private int index;
        private bool isLeft;
        private Random random;

        public AutoPlayMode Mode { get; set; }

        public int Interval { get { return timer.Interval; } set { timer.Interval = value; } }

        public AutoPlayTabControl(TabControl tabControl)
            : base(tabControl)
        {
            Initialize(tabControl, AutoPlayMode.WRAP);
        }

        public AutoPlayTabControl(TabControl tabControl, AutoPlayMode mode)
            : base(tabControl)
        {
            Initialize(tabControl, mode);
        }

        public void Play()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void Initialize(TabControl tabControl, AutoPlayMode mode)
        {
            SyncSlidePage = true;
            Mode = mode;
            isLeft = true;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);

            random = new Random(Environment.TickCount);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!Enabled)
            {
                switch (Mode)
                {
                    case AutoPlayMode.WRAP:
                            index = (index + 1) % SlidePageCount;
                        break;
                    case AutoPlayMode.REVERSE:
                            index = (isLeft ? index + 1 : index - 1) % SlidePageCount;
                            if (index == 0) isLeft = true;
                            else if (index == SlidePageCount - 1)  isLeft = false;
                        break;
                    case AutoPlayMode.RANDOM:
                            index = random.Next(0, SlidePageCount);
                        break;
                    default:
                        break;
                }
                tabControl.SelectedIndex = index;
            }
        }
    }
}
