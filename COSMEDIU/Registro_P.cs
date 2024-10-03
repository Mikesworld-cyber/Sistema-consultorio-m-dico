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
    public partial class Registro_P : Form
    {
        public Registro_P()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Registro_P_Load(object sender, EventArgs e)
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
    }
}
