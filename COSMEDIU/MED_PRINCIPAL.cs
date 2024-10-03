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
    public partial class MED_PRINCIPAL : Form
    {
        string[] ss;
        string[] datos;
        public MED_PRINCIPAL()
        {
            MySQL_CONECCION dd = new MySQL_CONECCION();
            InitializeComponent();
            ///conectarclas();
            ss = dd.usuarios();
            recorrrer();
        }
        public void recorrrer()
        { int i = 0;
            while (i < ss.Length)
            {
                picture(ss[i]);
                i++;
            }
        
        }
        private void MED_PRINCIPAL_Load(object sender, EventArgs e)
        {

        }
        private void Opcion1_Click(object sender, EventArgs e, string name)
        {
            
            // Obtiene el elemento del menú contextual que se hizo clic
            ToolStripItem item = sender as ToolStripItem;

            // Muestra el nombre del PictureBox en un MessageBox
            MySQL_CONECCION mys = new MySQL_CONECCION();
            datos=mys.infopaciente(name);
            OP_ME consulta = new OP_ME();
            consulta.textBox4.Text = datos[0]; consulta.textBox6.Text = datos[0]; consulta.textBox3.Text = datos[0];
            consulta.textBox1.Text = datos[1] +" "+ datos[2]; consulta.textBox5.Text = datos[1] +" " + datos[2]; consulta.textBox2.Text= datos[1] + " " + datos[2];
            consulta.label28.Text = label28.Text;
            consulta.textBoxmedi1.Text = label28.Text;
            consulta.textBomed1.Text = label28.Text;
            consulta.textBoxmed2.Text = label28
                .Text;
            consulta.paciente = datos[0];

            consulta.Show();
            ///MessageBox.Show(name);
            this.Hide();
        }
 
        public void picture( string name)
        {
            // flowLayoutPanel1.Controls.Clear();

            PictureBox nuevoPictureBox = new PictureBox();
            Label label1 = new Label();
            nuevoPictureBox.Width = 205; // Establece el ancho del PictureBox
            nuevoPictureBox.Height = 190; // Establece la altura del PictureBox
            nuevoPictureBox.Image = Properties.Resources.usuario; // Asigna una imagen (reemplaza 'miImagen' por la imagen que desees)
            nuevoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            label1.Text = name;
            label1.AutoSize = true;
            label1.Location = new Point(
            nuevoPictureBox.Left + ((nuevoPictureBox.Width - label1.Width) / 2)+28,  nuevoPictureBox.Height-label1.Height);

            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem item1 = new ToolStripMenuItem("Consultar");
 
            item1.Click += (sender, e) => Opcion1_Click(sender, e, name);
            contextMenu.Items.Add(item1);

            nuevoPictureBox.ContextMenuStrip = contextMenu;


            nuevoPictureBox.Controls.Add(label1);

            flowLayoutPanel1.Controls.Add(nuevoPictureBox);
        }
        private void conectarclas()
        {//METODO DE CONEXION 
            MySQL_CONECCION vobj = new MySQL_CONECCION();
            ///vobj.vServidor = "127.0.0.1";
            vobj.vServidor = "localhost";
            vobj.vUsuario = "root";
            vobj.vPassword = "Miguelcauich";
            vobj.vBaseDeDatos = "cosmed";
            int resultado = vobj.ABRIR_CONEXION_DB_MYSQL(vobj);
            switch (resultado)
            {
                case 1:
                    MessageBox.Show("la conexion esta activa");
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar sesión?", "Alerta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                  Form1 frm = new Form1();
            frm.Show();
            this.Hide();
            }
         
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registro_P P = new Registro_P();
            P.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
