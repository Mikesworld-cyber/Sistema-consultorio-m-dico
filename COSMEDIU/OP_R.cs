using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
namespace COSMEDIU
{
    public partial class OP_R : Form
    {
        public OP_R()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            groupBox4.Visible = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = true;
            groupBox3.Visible = false;

        }

        private void OP_R_Load(object sender, EventArgs e)
        {
            
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

        private void button3_Click(object sender, EventArgs e)
        {
            //modificar cita
            if (MessageBox.Show("¿Los datos de la cita son correctos?", "Confirmar", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                // Guarda los datos
                MessageBox.Show("Su cita se módifico cerrectamente ", "Felicidades");

            }
            else
            {
                MessageBox.Show("Ocurrió un error al modificar su cita, intente de nuevo");
                // No guarda los datos
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = DateTime.Now.ToString("yyyyMMdd") + ".pdf";
           /// save.ShowDialog();
            string pagina = Properties.Resources.formatoRecetahtml.ToString();
            pagina = pagina.Replace("@nombre","miguel cauich");
            pagina = pagina.Replace("@consulta", "miguel cauichfffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff");
            if (save.ShowDialog() == DialogResult.OK)
            {
                using(FileStream stream = new FileStream(save.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase("holamundo"));
                    using (StringReader st = new StringReader(pagina))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer,pdfDoc,st);
                    }
                    pdfDoc.Close();
                    stream.Close();

                }



            }
            //pagar cita
            /*
            if (MessageBox.Show("¿El monto de la cita es correcto?", "Confirmar", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                //pagar cita
                if (MessageBox.Show("Imprimir el comprobante", "Confirmar", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    MessageBox.Show("Su tikect ya se puede imprimir ", "Correcto");
                    PrintDialog printDialog = new PrintDialog();
                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Imprime el documento
                        // ...
                    }

                }  

            }
            else
            {
                MessageBox.Show("Ocurrió un error al modificar su cita, intente de nuevo");
                // No guarda los datos
            }
            */
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Hide();

        }

        private void button9_Click(object sender, EventArgs e)
        {
        

            if (MessageBox.Show("Al regresar estaria cerrando sesión", "Alerta", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                if (label7.Text == "Recepcionista  ")
                {
                    V_LOGIN options = new V_LOGIN();

                    

                    options.Show();

                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error verifique su correo");
                // No guarda los datos
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
