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

namespace COSMEDIU
{
    
    public partial class Form1 : Form
    {
        string[] ss;
        public Form1()
        {
            MySQL_CONECCION dd = new MySQL_CONECCION();
            InitializeComponent();
            conectarclas();
            ss = dd.usuarios();
            
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
                case 0:
                    MessageBox.Show("conexion fallida");
                    break;
            }
        }
        public string SetLabelText { get; set; }
        V_LOGIN vob = new V_LOGIN();
        public void button3_Click(object sender, EventArgs e)
        {
            //b_paciente 
            V_LOGIN b_paciente = new V_LOGIN();
            //vob.label7.Text = SetLabelText;
            b_paciente.label7.Text = " Paciente ";
            

            /*V_LOGIN.label7.Text*/ /*= "PACIENTE";*/
            b_paciente.Show();
            this.Hide();
            //this.Close();

        }


        public void button4_Click(object sender, EventArgs e)
        {
            //b_medico 
            //V_Médico b_medico = new V_Médico();
            //b_medico.ShowDialog();

            V_LOGIN b_medico = new V_LOGIN();
            b_medico.label7.Text = "Medico";
            b_medico.label3.Text = "Cédula:";
            b_medico.Show();

            this.Hide();
            b_medico.FormClosing += B_medico_FormClosing; 
            
           

        }

        private void B_medico_FormClosing(object sender, FormClosingEventArgs e)
        {
            //throw new NotImplementedException();
            this.Show();
        }

        private void frm_closing(object sender, FormClosedEventArgs e) 
        {
            this.Show();
        }

        public void button2_Click(object sender, EventArgs e)

        {
            //b_recepcionista 
            
            V_LOGIN b_recepcionista = new V_LOGIN();
            //vob.label7.Text = SetLabelText;
            b_recepcionista.label7.Text = "Recepcionista  ";
            b_recepcionista.label3.Text = " Nombre ";
            b_recepcionista.Show();
            this.Hide();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
      
        private void label2_Click(object sender, EventArgs e)
        {

        }
        bool sizeChanged = false;
        private void Form1_Resize_1(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MaximumSizeChanged(object sender, EventArgs e)
        {
          
        }

        private void Form1_MinimumSizeChanged(object sender, EventArgs e)
        {
           
        }



        //private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        //{

        //}
    }
}
