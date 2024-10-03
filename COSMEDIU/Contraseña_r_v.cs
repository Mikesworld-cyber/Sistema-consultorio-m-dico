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
    public partial class Contraseña_r_v : Form
    {
        public Contraseña_r_v()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("¿El correo que proporciono es correcto?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Guarda los datos
                MessageBox.Show("Se le envio el código a su correo");
            }
            else
            {
                MessageBox.Show("Ocurrió un error verifique su correo");
                // No guarda los datos
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("¿El código que proporciono que proporciono es correcto?", "Confirmar", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                // Guarda los datos
                MessageBox.Show("Puede cambiar su contraseña ");
                button7.Enabled = true;
            }
            else
            {
                MessageBox.Show("Ocurrió un error verifique su correo");
                // No guarda los datos
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

          groupBox1.Visible = false;
            groupBox3.Visible = true;

        }

        private void Contraseña_r_v_Load(object sender, EventArgs e)
        {
            button7.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Su contraseña ha sido cambiada exitosamente", "Felicidades", MessageBoxButtons.OK) == DialogResult.OK)
            {
                this.Close();

            }
        }
    }
}
