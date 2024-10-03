using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COSMEDIU
{
    public partial class V_Recepcionista : Form
    {
        public V_Recepcionista()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            R_R R_r = new R_R();
            R_r.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OP_R options = new OP_R();
            options.Show();
        }

        private void V_Recepcionista_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
