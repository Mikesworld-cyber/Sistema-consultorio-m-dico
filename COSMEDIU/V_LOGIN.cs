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
    public partial class V_LOGIN : Form
    {
        public V_LOGIN()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            

            if (label7.Text == " Paciente ")
            {
                Registro_P options = new Registro_P();
                options.Show();
            }
            if (label7.Text == " Médico ")
            {
                Registro_M options = new Registro_M();

                options.Show();
            }
            if (label7.Text == "Recepcionista  ")
            {
                R_R options = new R_R();
                options.Show();
            }
        }

        public void SetLabelText(string newText)
        {
            label7.Text = newText;
        }



        private void V_LOGIN_Load(object sender, EventArgs e)
        {
     
          
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Hide();
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
        private void button3_Click(object sender, EventArgs e)
        {
            //conectarclas();

            MySQL_CONECCION s = new MySQL_CONECCION();
            string doctor = "Dr " + s.inciosesion(textBox1.Text, textBox2.Text, label7.Text);
            if (doctor != "Dr 0")
            {
                if (label8.Text != " ")
                {
                    if (label7.Text == "Paciente")
                    {
                        OP_P options = new OP_P();

                        options.Show();

                    }
                    if (label7.Text == "Medico")
                    {
                        MED_PRINCIPAL options = new MED_PRINCIPAL();

                        options.label28.Text = doctor;
                        options.Show();

                    }
                    if (label7.Text == "Recepcionista")
                    {

                        OP_R options = new OP_R();

                        options.Show();

                    }
                    this.Hide();
                }
            }
           // this.Hide();
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           Contraseña_r_v options = new Contraseña_r_v();
            options.Show();
        }
    }
}
