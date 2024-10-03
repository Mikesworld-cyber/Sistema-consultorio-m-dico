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
    public partial class V_Médico : Form
    {
        public V_Médico()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro_M R_paciente = new Registro_M();
            R_paciente.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Form1 home = new Form1();
            home.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OP_ME options = new OP_ME();
            options.Show();
        }

        private void V_Médico_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
