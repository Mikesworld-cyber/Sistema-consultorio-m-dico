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
    public partial class Registro_M : Form
    {
        public Registro_M()
        {
            InitializeComponent();
            conectarclas();
            DateTime horaActual = DateTime.Now;

            // Formatear para mostrar solo la hora sin minutos ni segundos
            string horaFormateada = horaActual.ToString("HH:00:00");
            textBox1.Text = horaFormateada;
            DateTime fechaActual = DateTime.Now;
            string fechaFormateada = fechaActual.ToString("yyyy-MM-dd");
            MySQL_CONECCION mys = new MySQL_CONECCION();
            textBox3.Text= mys.sentenciarecibir("select idc from citas where fecha='"+fechaFormateada+"' and hora='"+horaFormateada+"'");
            bool f = mys.sentenciaenviar("update citas set estatus='perdido' WHERE fecha < NOW()  AND DATE(fecha) != CURDATE() AND estatus = 'pendiente'");
            if (f == false){ MessageBox.Show("Error en eliminacion de estatus pendientes"); }
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
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            button1.Dock = DockStyle.Fill;
            button7.Dock = DockStyle.Top;
            this.Close();

        }

        private void Registro_M_Load(object sender, EventArgs e)
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
