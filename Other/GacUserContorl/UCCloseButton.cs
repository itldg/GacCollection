using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GAC_Collection.UserContorl
{
    public partial class UCCloseButton :PictureBox
    {
        public UCCloseButton()
        {
            InitializeComponent();
            
            
            this.Image = Normal;

        }

        private Image _normal, _enter,_click = null;
        //[Browsable(true)]
        [Description("滑过图片"), Category("GAC_Collection")]
        public new Image Enter
        {

            //this.Normal = ((System.Drawing.Image)(resources.GetObject("Normal")));
            //this.Enter = 
            //this.Click = ((System.Drawing.Image)(resources.GetObject("Click")));
            set { _enter = value; }
            get
            {

                if (_enter == null)
                {
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCCloseButton)); _enter = ((System.Drawing.Image)(resources.GetObject("Enter")));
                }
                return _enter;

            }
        }
        //[Browsable(true)]
        [Description("点击图片"), Category("GAC_Collection")]
        public Image ClickImage
        {
            set { _click = value; }
            get
            {

                if (_click == null)
                {
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCCloseButton)); _click = ((System.Drawing.Image)(resources.GetObject("Click")));
                }
                return _click;

            }
        }
        //[Browsable(true)]
        [Description("正常图片"), Category("GAC_Collection")]
        public Image Normal
        {
            set { _normal = value; }
            get
            {

                if (_normal == null)
                {
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCCloseButton)); _normal = ((System.Drawing.Image)(resources.GetObject("Normal")));
                }
                return _normal;

            }
        }

        private void UCCloseButton_MouseEnter(object sender, EventArgs e)
        {
            this.Image = Enter;
        }

        private void UCCloseButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.Image = ClickImage;
        }

        private void UCCloseButton_MouseLeave(object sender, EventArgs e)
        {
            this.Image =Normal;
        }

        private void UCCloseButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.Image = Normal;
        }
    }
}
