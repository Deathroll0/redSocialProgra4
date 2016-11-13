using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace redSocialProgra4.conex
{
    public class Conexion
    {
        private MySqlConnection con;
        private static Conexion instance;

        private Conexion()
        {
            con = new MySqlConnection("server=www.tree-solutions.cl; port=3306; Uid=treesolu_alumnos; Pwd=alumnosprogra4Inacap; database=treesolu_alumnos;");
        }

        public static Conexion Instance()
        {
            if (instance == null)
                instance = new Conexion();
            return instance;
        }

        public void abreConexion()
        {
            con.Open();
        }

        public void cierraConexion()
        {
            con.Close();
        }

        public MySqlConnection usaConexion()
        {
            return con;
        }
    }
}