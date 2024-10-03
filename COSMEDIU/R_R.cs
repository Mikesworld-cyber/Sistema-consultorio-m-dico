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
    public partial class R_R : Form
    {
        public R_R()
        {
            InitializeComponent();
        }

        private void R_R_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Están tus datos correctos?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Guarda los datos
                MessageBox.Show("Felicidades te has registrado en cosmed");

            }
            else
            {
                // No guarda los datos
                MessageBox.Show("Ocurrio un error por favor verifica");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Close();
        }

    }
}
