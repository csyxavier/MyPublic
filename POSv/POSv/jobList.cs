using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSv
{
    public partial class jobList : Form
    {
        private System.Windows.Forms.Timer tmr;

        public jobList()
        {
            InitializeComponent();
            tmr = new System.Windows.Forms.Timer();
            tmr.Tick += delegate {
                this.Close();
            };
            tmr.Interval = (int)TimeSpan.FromMinutes(2).TotalMilliseconds;
            tmr.Start();
        }
    }
}
