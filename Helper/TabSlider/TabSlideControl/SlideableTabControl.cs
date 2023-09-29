/*
 * /////////////////////////////////////////////////////////////////////
 * Program   : TabSlider（标签滑动器）
 * Author    : hwenycocodq520（智商余额不足）
 * E-mail    : hwenycocodq520#163.com（#替换为@）
 * Date      : 2013/10/27
 * Resume    : 可滑动TabControl标签页类
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
    public class SlideableTabControl:TabSlider
    {
        protected TabControl tabControl;
        private int lastIndex;

        public TabSlideEffectDirection PageUpDirection { get; set; }
        public TabSlideEffectDirection PageDownDirection { get; set; }

        public bool SyncSlidePage { get; set; }

        public SlideableTabControl(TabControl tabControl)
            : base()
        {
            Initialize(tabControl);
        }

        private void Initialize(TabControl tabControl)
        {
            if (tabControl == null) return;
            this.tabControl = tabControl;
            foreach (TabPage page in this.tabControl.TabPages)
            {
                AddTabSlidePage(page);
            }

            PageUpDirection = TabSlideEffectDirection.RIGHT_TO_LEFT;
            PageDownDirection = TabSlideEffectDirection.LEFT_TO_RIGHT;
            TabSliderHelper.CreateControls(this.tabControl);
            this.tabControl.Selecting += new TabControlCancelEventHandler(tabControl_Selecting);
            this.tabControl.Selected += new TabControlEventHandler(tabControl_Selected);
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (SyncSlidePage)
            {
                if (Enabled) e.Cancel = true;
            }
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            EffectDirection = (e.TabPageIndex - lastIndex > 0) ? PageUpDirection : PageDownDirection;
            Slide(e.TabPageIndex);
            lastIndex = e.TabPageIndex;
        }
    }
}
