using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
////////////using System.Windows.Forms.VisualStyles.VisualStyleElement;
using Org.BouncyCastle.Asn1.Cms;
using MySqlX.XDevAPI;


namespace COSMEDIU
{
    public partial class OP_ME : Form
    {
        public OP_ME()
        {
            InitializeComponent();
            llenadohoras();

        }
        string[] fechahora;
        //public void verfechas(string fecha)

        //{ MySQL_CONECCION my = new MySQL_CONECCION();

        //    fechahora = my.fechashoras("select hora from citas where fecha='"+fecha+"'");
        //    foreach (var item in comboBox1.Items)
        //    {
        //        if (arreglo.Contains(item.ToString()))
        //        {
        //            Console.WriteLine("El elemento " + item.ToString() + " está en el arreglo y en el ComboBox.");
        //            // Puedes hacer lo que desees con los elementos iguales
        //        }
        //    }

        //}
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            groupBox3.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            //flowLayoutPanel1.Visible = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //flowLayoutPanel1.Visible = false;
            groupBox4.Visible = false;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox2.Visible = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            groupBox2.Visible = false;
            groupBox1.Visible = false;
            groupBox3.Visible = true;
            //flowLayoutPanel1.Visible = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            groupBox1.Visible = false;
            //flowLayoutPanel1.Visible = false;
        }
        public string paciente;
        private void OP_ME_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            button7.Enabled = false;
          
            MySQL_CONECCION mys = new MySQL_CONECCION();
            dataGridView1.DataSource=mys.ListarRegistros(textBox3.Text);
            //--dara valor a receta medica (id)
            DateTime horaActual = DateTime.Now;

            // Formatear para mostrar solo la hora sin minutos ni segundos
            string horaFormateada = horaActual.ToString("HH:00:00");
            DateTime fechaActual = DateTime.Now;
            string fechaFormateada = fechaActual.ToString("yyyy-MM-dd");
            label30.Text = mys.sentenciarecibir("select idc from citas where fecha='" + fechaFormateada + "' and hora='" + horaFormateada + "'" +"and curp='"+textBox3.Text+"' and estatus='pendiente'","sin cita");

        }
        string[] horas = { "07:00:00", "08:00:00", "09:00:00", "10:00:00","11:00:00", "12:00:00", "13:00:00", "16:00:00", "17:00:00", "18:00:00", "19:00:00", "20:00:00", "21:00:00" };
        public void llenadohoras() 
        {
            int i = 0;
            while(i<13)
            {
                comboBoxhora.Items.Add(horas[i]);
                comboBoxhora2.Items.Add(horas[i]);
                i++;

            }
        
        }
        private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
        {
            

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //botón solicitar analisis

        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            
            if (MessageBox.Show("Al regresar estaria cerrando sesión", "Alerta", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                MED_PRINCIPAL usu = new MED_PRINCIPAL();
                usu.label28.Text = label28.Text;
                usu.Show();
                this.Close();
            }
       

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Hide();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            //analisis
            V_ANALISIS options = new V_ANALISIS();
            options.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = label30.Text+"_"+ DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".pdf";
            /// save.ShowDialog();
            string pagina = Properties.Resources.formatoRecetahtml.ToString();
            pagina = pagina.Replace("@cita", label30.Text);
            pagina = pagina.Replace("@fecha",DateTime.Now.ToString("yyyy-MM-dd"));
            pagina = pagina.Replace("@hora",DateTime.Now.ToString("HH:00:00"));
            pagina = pagina.Replace("@nombre", textBox5.Text);
            pagina = pagina.Replace("@curp", textBox6.Text);
            pagina = pagina.Replace("@altura", textBox7.Text);
            pagina = pagina.Replace("@peso", textBox8.Text);
            pagina = pagina.Replace("@presion", textBox9.Text);
            pagina = pagina.Replace("@consulta", richTextBox3.Text);
            pagina = pagina.Replace("@doctor",textBomed1.Text);


        
            if (save.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    //pdfDoc.Add(new Phrase("holamundo"));
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.iconomed, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(80,60);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;
                    img.SetAbsolutePosition(pdfDoc.LeftMargin,pdfDoc.Top-60);
                    pdfDoc.Add(img);
                    using (StringReader st = new StringReader(pagina))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, st);
                    }
                    pdfDoc.Close();
                    stream.Close();

                }



            }
            MySQL_CONECCION my = new MySQL_CONECCION();
            bool v = my.sentenciaenviar("update citas set estatus='finalizada' where idc='" + label30.Text + "'");

        }
        private void Imprimir(object sender, PrintPageEventArgs e)
        {


        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dateTimePicker3.Value;
            // Formatear la fecha al formato de MySQL (YYYY-MM-DD)   
            string fechaFormateada = fechaSeleccionada.ToString("yyyy-MM-dd");
            DateTime horaActual = DateTime.Now;

            // Formatear para mostrar solo la hora sin minutos ni segundos
            string horaFormateada = horaActual.ToString("HH:mm:00");
            
            /*

            printDocument1 = new System.Drawing.Printing.PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += Imprimir;
            printDocument1.Print();
            */



            errorProvider1.Clear();
            // Verificar receta
            if (textBox6.Text == "")
            {
                errorProvider1.SetError(textBox6, "Error de ingreso");
                textBox6.Focus();
                return;
            }
            if (textBox5.Text == "")
            {
                errorProvider1.SetError(textBox5, "Error de ingreso");
                textBox5.Focus();
                return;
            }
            if (textBox7.Text == "")
            {
                errorProvider1.SetError(textBox7, "Error de ingreso");
                textBox7.Focus();
                return;
            }
            if (textBox8.Text == "")
            {
                errorProvider1.SetError(textBox8, "Error de ingreso");
                textBox8.Focus();
                return;
            }
            if (textBox9.Text == "")
            {
                errorProvider1.SetError(textBox9, "Error de ingreso");
                textBox9.Focus();
                return;
            }

            MySQL_CONECCION mys = new MySQL_CONECCION();
            bool v=mys.sentenciaenviar("insert into consultas values(0,'"+textBox5.Text+"','"+textBox7.Text+"', '"+textBox8.Text+"'," +
                "'"+textBox9.Text+"', '"+fechaFormateada+"', '"+horaFormateada+"', '"+textBomed1.Text+"','"+richTextBox2.Text+"', " +
                "'"+richTextBox1.Text+"', '"+richTextBox3.Text+"', '"+textBox6.Text+"', '"+label30.Text+"')");
            if (v == false) { MessageBox.Show("error"); }
            else if (v == true) { MessageBox.Show("Datos guardados correctamente, la receta este lista"); button7.Enabled = true; }

           /* if (comboBox3.Text == "")
            {
                errorProvider1.SetError(comboBox3, "Error de ingreso");
                comboBox3.Focus();
                return;
            }*/
            /// errorProvider1.SetError(textBox7, "");
            /*
            if (MessageBox.Show("¿Los datos qué proporcionó son correctos?", "Confirmar", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                // Guarda los datos
                MessageBox.Show("Puede imprimir su receta ");
                button7.Enabled = true;
            }
            else
            {
                MessageBox.Show("Ocurrió un error verifique sus datos");
                // No guarda los datos
            }*/
        }
        private void horass()
        { 
        
        
        }
        private void button3_Click(object sender, EventArgs e)
        {MySQL_CONECCION mys = new MySQL_CONECCION();
            DateTime fechaSeleccionada = dateTimePicker2.Value;
            // Formatear la fecha al formato de MySQL (YYYY-MM-DD)   
            string fechaFormateada = fechaSeleccionada.ToString("yyyy-MM-dd");
            string time = comboBoxhora2.Text;
            
   

            if (MessageBox.Show("¿Los datos de la cita son correctos?", "Confirmar", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {   string d = mys.verificarfecha(fechaFormateada, comboBoxhora2.Text);
                if (d != "0") { MessageBox.Show("Por favor elija otra fecha y hora, esa ya ha sido reservada"); }
                else { 
                    button11.Visible = true;
                    if (fecha == null && hora == null) { MessageBox.Show("Debe seleccionar un registro"); }
                    else
                    {
                        button11.Enabled = true;
                    }
                }
               
            }
            else
            {
        
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dateTimePicker1.Value;
            // Formatear la fecha al formato de MySQL (YYYY-MM-DD)
            string fechaFormateada = fechaSeleccionada.ToString("yyyy-MM-dd");

            
            // Verificar ag citas
            MySQL_CONECCION g = new MySQL_CONECCION();
            string d = g.verificarfecha(fechaFormateada, comboBoxhora.Text);

            if (d != "0") { MessageBox.Show("Por favor elija otra fecha y hora, esa ya ha sido reservada"); }
            else { button10.Enabled = true; }
         
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dateTimePicker1.Value;
            // Formatear la fecha al formato de MySQL (YYYY-MM-DD)
            string fechaFormateada = fechaSeleccionada.ToString("yyyy-MM-dd");
            MySQL_CONECCION mys = new MySQL_CONECCION();
           bool v = mys.guardarcita(textBox1.Text,textBox4.Text,fechaFormateada,comboBoxhora.Text,textBoxmedi1.Text);
            if (v == true) { MessageBox.Show("se guardo correctamente, listo para descargarla"); dataGridView1.DataSource = mys.ListarRegistros(textBox3.Text); button10.Enabled = false; }
        }
        string fecha;
        string hora;
        private void button11_Click(object sender, EventArgs e)
        {

            MySQL_CONECCION mys = new MySQL_CONECCION();

            DateTime fechaSeleccionada = dateTimePicker2.Value;
            // Formatear la fecha al formato de MySQL (YYYY-MM-DD)   
            string fechaFormateada = fechaSeleccionada.ToString("yyyy-MM-dd");
            string time = comboBoxhora2.Text;



                        bool b = mys.editarcita(fecha, hora, fechaFormateada, time);
                        if (b == true)
                        {
                            MessageBox.Show("Registro actualizado");
                            button11.Enabled = false;
                            dataGridView1.DataSource = mys.ListarRegistros(textBox3.Text);
                        }
     

            
            
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener el valor de la celda de la columna 0 en la fila clicada
                var value0= dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                var valuefecha = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                var valuehora = dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                // Hacer algo con el valor, por ejemplo, mostrarlo en un Label (asumiendo que es un Label llamado label1)

                fecha=Convert.ToDateTime(valuefecha).ToString("yyyy-MM-dd");
                
                hora = valuehora.ToString();
            }
            /*
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtiene la fila seleccionada
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Selecciona las dos primeras celdas de la fila
                 selectedRow.Cells[0].Selected = true;
                comboBoxhora2.Text = selectedRow.Cells[0].Value.ToString();
                selectedRow.Cells[1].Selected = true;
            }/*

            /*

            if (e.RowIndex >= 0 && e.ColumnIndex < 0)
            {
                // Desselecciona la celda actual (fila)
                //comboBoxhora2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                comboBoxhora2.Text = dataGridView1.SelectedRows[e.RowIndex].Cells[0].Value.ToString(); 
                // Deselecciona todas las celdas de las columnas
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.Selected = false;
                }
                 dataGridView1.Rows[e.RowIndex].Selected = true;
            }*////
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + ("_FACTURA") + ".pdf";
            //guardar.ShowDialog();

            string paginahtml_texto = "<table><tr><td>HOLAMUNDO</td></tr></table>";
            //paginahtml_texto = paginahtml_texto.Replace("@CURP", textBox4.Text);
            //paginahtml_texto = paginahtml_texto.Replace("@NOMBRE", textBox1.Text);
            //paginahtml_texto = paginahtml_texto.Replace("@FECHACITA", textBox4.Text);
            //paginahtml_texto = paginahtml_texto.Replace("@HORACITA", textBox4.Text);
            //paginahtml_texto = paginahtml_texto.Replace("@MEDICOIMP", textBox4.Text);

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
               
                    pdfdoc.Add(new Paragraph("COSMED"));
                    pdfdoc.Add(new Paragraph("CURP:" + (textBox4.Text) + "\n"));
                    pdfdoc.Add(new Paragraph("NOMBRE: " + (textBox1.Text) + "\n"));
                    pdfdoc.Add(new Paragraph("HORA:  " + (comboBoxhora.Text) + "\n"));
                    pdfdoc.Add(new Paragraph("FECHA:" + (dateTimePicker1.Text) + "\n"));
                    pdfdoc.Add(new Paragraph("MÉDICO:" + (textBomed1.Text) + "\n"));
                    pdfdoc.Add(new Paragraph("\n\nFavor de presentarse a la hora puntual de su consulta\n\n"));
                    pdfdoc.Add(new Paragraph("\n\nCOSMED AGRADECE SU PREFERENCIA :)\n\n"));
                    //using (StringReader sr = new StringReader(paginahtml_texto))
                    //{
                    //    XMLWorkerHelper.GetInstance().ParseXHtml(writer ,pdfdoc , sr);
                    //}

                    pdfdoc.Close();
                    stream.Close();

                }
                
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
