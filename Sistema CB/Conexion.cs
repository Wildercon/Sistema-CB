using MySql.Data.MySqlClient;
using Sistema_CB.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_CB
{
    class Conexion
    {
        
        private MySqlConnection conexionBD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

        public  MySqlConnection abrirconexion()
        {             
          
           if (conexionBD.State == ConnectionState.Closed)
                conexionBD.Open();
                return conexionBD;
           

        }    
        
        public MySqlConnection cerrarConexion()
        {
            if (conexionBD.State == ConnectionState.Open)
                conexionBD.Close();
                return conexionBD;
        }
           
    }
}
