using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace COSMEDIU
{
    class MySQL_CONECCION
    {
        public string vServidor { get; set; }
        public string vUsuario { get; set; }
        public string vPassword { get; set; }
        public string vBaseDeDatos { get; set; }
        public static MySqlConnection SQLConnection = new MySqlConnection();
        string vServerString = "";
        string vEstatus_Conexion = "";
        public int ABRIR_CONEXION_DB_MYSQL(MySQL_CONECCION vObjConexion)
        {
            int vResultado = 1;
            vServerString = ("Server="
                        + (vObjConexion.vServidor + (";" + ("user Id="
                        + (vObjConexion.vUsuario + (";" + ("Password="
                        + (vObjConexion.vPassword + (";" + ("Database=" + vObjConexion.vBaseDeDatos))))))))));
            SQLConnection.Close();
            SQLConnection.ConnectionString = vServerString;
            try
            {
                if ((SQLConnection.State == ConnectionState.Closed))
                {
                    SQLConnection.Open();

                    vEstatus_Conexion = "OPEN";
                    return vResultado;
                }
                else
                {
                    SQLConnection.Close();

                    vEstatus_Conexion = "CLOSE";
                    return vResultado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                vResultado = 0;
            }

            return vResultado;
        }

        public string inciosesion(string usuario, string contrasena, string tipousuario)
        {
            string vSQL = "call UsuarioMedico(@usuario, @contrasena, @tipousuario)";


            //SQLConnection.Open();
            //conexion.Open();

            using (MySqlCommand cmd = new MySqlCommand(vSQL, SQLConnection))
            {
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                cmd.Parameters.AddWithValue("tipousuario", tipousuario);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // Avanza al primer resultado si existe
                    {
                        string resultado = "" + reader["nombres"].ToString() + " " + reader["apellidos"].ToString(); // Reemplaza "NombreColumna" con el nombre real de la columna que deseas obtener
                        return resultado; // Retorna el valor obtenido
                    }
                    else
                    {
                        return "0";
                    }
                }
            }
        }

        public string[] usuarios()
        {
            string[] Ausuarios;
            List<string> valores = new List<string>();
            string vSQL = "select usuario from usuarios where tipoUsuario='paciente';";


            //SQLConnection.Open();
            //conexion.Open();

            using (MySqlCommand cmd = new MySqlCommand(vSQL, SQLConnection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string valor = reader["usuario"].ToString(); // Cambia "MiColumna" por el nombre real de la columna
                        valores.Add(valor); // Agrega el valor a la lista
                    }
                    Ausuarios = valores.ToArray();
                }
            }
            return Ausuarios;
        }
        public string[] infopaciente(string user)
        {
            string[] infosUser = new string[3];
            //List<string[]> valores = new List<string[]>();
            string vSQL = "select curp, nombres, apellidos  from usuarios where usuario=@user";
            using (MySqlCommand cmd = new MySqlCommand(vSQL, SQLConnection))
            {
                cmd.Parameters.AddWithValue("@user", user);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        infosUser[0] = reader["curp"].ToString(); // Cambia "MiColumna" por el nombre real de la columna
                        infosUser[1] = reader["nombres"].ToString();
                        infosUser[2] = reader["apellidos"].ToString();

                    }

                }
            }
            return infosUser;


        }
        public string verificarfecha(string fecha, string hora)
        {
            string fui;

            if (SQLConnection.State == ConnectionState.Closed)
            {
                SQLConnection.Open();
            }
            MySqlCommand cmd = new MySqlCommand();
            String vSQL = "SELECT `idc` FROM citas WHERE fecha='" + fecha + "'" + "and hora='" + hora + "'";
            cmd.CommandText = vSQL;
            cmd.Connection = SQLConnection;

            if (cmd.ExecuteScalar() == null) { fui = "0"; }
            else { fui = cmd.ExecuteScalar().ToString(); }

            return fui;

        }
        public bool guardarcita(string paciente, string curp, string fecha, string hora, string medico, string status = "pendiente")
        {
            bool hola;
            string vSQL = "insert into citas values (0, @paciente,@curp,@fecha, @hora,@medico, @status)";
            //SQLConnection.Open();
            //conexion.Open();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(vSQL, SQLConnection))
                {
                    cmd.Parameters.AddWithValue("@paciente", paciente);
                    cmd.Parameters.AddWithValue("@curp", curp);
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@medico", medico);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery();
                    
                }hola = true;
            }
            catch (Exception) 
            {
                hola = false;
            }


            return hola;
        }

        public DataTable ListarRegistros(string curp)

        //PELJ300101HDFXRR07
        {
            string vSQL = "select curp, fecha, hora, medico from citas where curp='"+curp+"' and estatus='pendiente'";
            DataTable vTable = new DataTable();
            try
            {
                MySqlDataAdapter vAdaptador = new MySqlDataAdapter(vSQL, SQLConnection);


                vAdaptador.Fill(vTable);

              

            }
            catch (Exception)
            {

            }
            return vTable;
        }
        public bool editarcita(string fechaAN, string horaAN, string fechaNU, string horaNU)
        {
            bool hola;
            string vSQL = "call editarcita(@fechaAN,@horaAN, @fechaNU,@horaNU)";
            //SQLConnection.Open();
            //conexion.Open();
          
                using (MySqlCommand cmd = new MySqlCommand(vSQL, SQLConnection))
                {
                    cmd.Parameters.AddWithValue("@fechaAN", fechaAN);
                    cmd.Parameters.AddWithValue("@horaAN", horaAN );
                    cmd.Parameters.AddWithValue("@fechaNU", fechaNU);
                    cmd.Parameters.AddWithValue("@horaNU", horaNU);
                    cmd.ExecuteNonQuery();

                }
                hola = true;
         


            return hola;
        }
        public bool consulta(string fechaAN, string horaAN, string fechaNU, string horaNU)
        {
            bool hola;
            string vSQL = "call editarcita(@fechaAN,@horaAN, @fechaNU,@horaNU)";
            //SQLConnection.Open();
            //conexion.Open();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(vSQL, SQLConnection))
                {
                    cmd.Parameters.AddWithValue("@fechaAN", fechaAN);
                    cmd.Parameters.AddWithValue("@horaAN", horaAN);
                    cmd.Parameters.AddWithValue("@fechaNU", fechaNU);
                    cmd.Parameters.AddWithValue("@horaNU", horaNU);
                    cmd.ExecuteNonQuery();

                }
                hola = true;
            }
            catch (Exception)
            {
                hola = false;
            }


            return hola;
        }

        public string sentenciarecibir(string vSQL, string respues_contra="0")
        {
            string fui;

            if (SQLConnection.State == ConnectionState.Closed)
            {
                SQLConnection.Open();
            }

            MySqlCommand cmd = new MySqlCommand();
            //String vSQL = "SELECT `idc` FROM citas WHERE fecha='" + fecha + "'" + "and hora='" + hora + "'";
            cmd.CommandText = vSQL;
            cmd.Connection = SQLConnection;

            if (cmd.ExecuteScalar() == null) { fui = respues_contra; }
            else { fui = cmd.ExecuteScalar().ToString(); }
            return fui;

        }
        public bool sentenciaenviar(string vSQL)
        {
            bool hola;
            //SQLConnection.Open();
            //conexion.Open();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(vSQL, SQLConnection))
                {
    
                    cmd.ExecuteNonQuery();

                }
                hola = true;
            }
            catch (Exception)
            {
                hola = false;
            }


            return hola;
        }
        public string[] fechashoras(string vSQL)
        {
            string[] Ausuarios;
            List<string> valores = new List<string>();
           


            //SQLConnection.Open();
            //conexion.Open();

            using (MySqlCommand cmd = new MySqlCommand(vSQL, SQLConnection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string valor = reader["hora"].ToString(); // Cambia "MiColumna" por el nombre real de la columna
                        valores.Add(valor); // Agrega el valor a la lista
                    }
                    Ausuarios = valores.ToArray();
                }
            }
            return Ausuarios;
        }
    }
}
