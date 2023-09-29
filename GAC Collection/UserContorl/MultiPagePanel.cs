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
    public partial class MultiPagePanel : Panel
    {
        public MultiPagePanel()
        {
            InitializeComponent();
        }

        private int _currentPageIndex;
        public int CurrentPageIndex
        {
            get { return _currentPageIndex; }
            set
            {
                if (value >= 0 && value < Controls.Count)
                {
                    Controls[value].BringToFront();
                    _currentPageIndex = value;
                }
            }
        }
       
  public void AddPage(Control page)
        {
            Controls.Add(page);
            page.Dock = DockStyle.Fill;
        }
    }
}
