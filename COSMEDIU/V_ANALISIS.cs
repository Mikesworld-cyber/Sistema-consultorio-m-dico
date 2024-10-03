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
    public partial class V_ANALISIS : Form
    {
        public V_ANALISIS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Crea un objeto PrintDialog
            PrintDialog printDialog = new PrintDialog();

            // Muestra el cuadro de diálogo de impresión
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Imprime el documento
                // ...
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea agregar esos análisis al paciente", "Confirmar", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                // Guarda los datos
                MessageBox.Show("Puede imprimir los análisis ");
                button1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Ocurrió un error verifique su correo");
                // No guarda los datos
            }
        }

        private void V_ANALISIS_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Otro")
            {
                textBox1.Visible = true;
                label3.Visible = true;
            }
            else
            {
                label3.Visible = false;
                textBox1.Visible = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea regresar puede que los análisis no se guarden", "Alerta", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                OP_ME opt = new OP_ME();
                opt.ShowDialog();
                this.Close();
            }

        }
    }
}
