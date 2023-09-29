using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GAC_Collection
{
    public partial class FrmInfo : Form
    {

        public FrmInfo()
        {
            InitializeComponent();
        }

        private void FrmInfo_Load(object sender, EventArgs e)
        {

        }
        public void SetMessage(string Message)
        {
            while (!this.IsHandleCreated)
            {

            }
            this.BeginInvoke(new MethodInvoker(delegate() {

                    lblMessage.Text = Message;
                    Application.DoEvents();
                }));
            
        }


        private void FrmInfo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.DarkOliveGreen, 0, 0, this.Width - 1, this.Height - 1);
        }


    }
}
