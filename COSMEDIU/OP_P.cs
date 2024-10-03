using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
///////using System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace COSMEDIU
{
    public partial class OP_P : Form
    {
        private object label7;

        public OP_P()
        {
            InitializeComponent();
        }

        private void OP_P_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Los datos de la cita son correctos?", "Confirmar", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                // Guarda los datos
                MessageBox.Show("Su cita se agendó cerrectamente ", "Felicidades");

            }
            else
            {
                MessageBox.Show("Puede que la cita ya esté ocupada elija otra");
                // No guarda los datos
            }

            if (MessageBox.Show("") == DialogResult.No)
            {
                MessageBox.Show("Ocurrió un error al modificar su cita, intente de nuevo");
                // No guarda los datos
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            

            if (MessageBox.Show("Al regresar estaria cerrando sesión", "Alerta", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                    Form1 options = new Form1();
                    options.Show();
                    this.Hide();
            }
            else
            {
                MessageBox.Show("Ocurrió un error verifique su correo");
                // No guarda los datos
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
