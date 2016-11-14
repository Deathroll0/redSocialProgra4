using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using redSocialProgra4.conex;

namespace redSocialProgra4.modelos
{
    public class Usuario
    {

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        private string correo;

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        private string clave;

        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        public bool insertaUsuario(Usuario u)
        {
            Conexion con = Conexion.Instance();
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "INSERT INTO usuarios VALUES('" + u.Correo + "','" + u.Nombre + "','" + u.Apellido + "','" + u.Clave + "')";
                comando.Connection = con.usaConexion();
                if (comando.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.cierraConexion();
            }
        }

        public Usuario buscaUno(string correo)
        {
            Conexion con = Conexion.Instance();
            Usuario u2 = null;
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "SELECT * FROM usuarios WHERE correo='" + correo + "'";
                comando.Connection = con.usaConexion();
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    u2 = new Usuario();
                    u2.Correo = reader[0].ToString();
                    u2.Nombre = reader[1].ToString();
                    u2.Apellido = reader[2].ToString();
                    u2.Clave = reader[3].ToString();
                }
            }
            finally
            {
                con.cierraConexion();
            }
            return u2;
        }

        public Usuario buscaLogin(string correo, string clave)
        {
            Conexion con = Conexion.Instance();
            Usuario u2 = null;
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "SELECT * FROM usuarios WHERE correo='" + correo + "' AND clave='" + clave + "'";
                comando.Connection = con.usaConexion();
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    u2 = new Usuario();
                    u2.Correo = reader[0].ToString();
                    u2.Nombre = reader[1].ToString();
                    u2.Apellido = reader[2].ToString();
                    u2.Clave = reader[3].ToString();
                }
            }
            finally
            {
                con.cierraConexion();
            }
            return u2;
        }

        //buscador de personas con nombre y apellido
        public List<Usuario> buscaTodosNombreApellido(string nombre, string apellido)
        {
            Conexion con = Conexion.Instance();
            List<Usuario> lista = new List<Usuario>();
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "SELECT * FROM usuarios WHERE nombre='" + nombre + "' AND apellido='" + apellido + "'";
                comando.Connection = con.usaConexion();
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Usuario u2 = new Usuario();
                    u2.correo = reader[0].ToString();
                    u2.Nombre = reader[1].ToString();
                    u2.Apellido = reader[2].ToString();
                    lista.Add(u2);
                }
            }
            finally
            {
                con.cierraConexion();
            }
            return lista;
        }


        ////busca todos los amigos del usuario logeado
        //public List<Usuario> buscaTodosAmigos(string correo)
        //{
        //    Conexion con = Conexion.Instance();
        //    List<Usuario> lista = new List<Usuario>();
        //    try
        //    {
        //        con.abreConexion();
        //        MySqlCommand comando = new MySqlCommand();
        //        comando.CommandText = "SELECT usuarios.nombre, usuarios.apellido, usuarios.correo from usuarios INNER JOIN amigos ON usuarios.correo=amigos.usuario1 WHERE correo='"+correo+"'";
        //        comando.Connection = con.usaConexion();
        //        MySqlDataReader reader = comando.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Usuario u2 = new Usuario();
        //            u2.correo = reader[0].ToString();
        //            u2.Nombre = reader[1].ToString();
        //            u2.Apellido = reader[2].ToString();                    
        //            lista.Add(u2);
        //        
        //    }
        //    finally
        //    {
        //        con.cierraConexion();
        //    }
        //    return lista;
        //}

        //buscar todos los amigos en la tabla amigos
        public List<Usuario> buscaTodosTablaAmigos(string correo)
        {
            Conexion con = Conexion.Instance();
            List<Usuario> lista = new List<Usuario>();
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "SELECT * from amigos WHERE usuario1='" + correo + "' or usuario2='"+correo+"'";
                comando.Connection = con.usaConexion();
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Usuario u2 = new Usuario();
                    u2.correo = reader[0].ToString();
                    u2.Nombre = reader[1].ToString();//en este caso el nombre de la lista, sera el correo de la segunda columna
                    lista.Add(u2);
                }
            }
            finally
            {
                con.cierraConexion();
            }
            return lista;
        }

       public string sonAmigos(string correoSession, string correoPerfil)
        {
            Conexion con = Conexion.Instance();
            string mensaje = "No Son Amigos";
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "SELECT * from amigos where (usuario1='"+correoSession+ "' or usuario2='"+correoSession+"') and (usuario1='"+correoPerfil+ "' or usuario2='"+correoPerfil+"')";
                comando.Connection = con.usaConexion();
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    mensaje = "Son Amigos";
                }
            }
            finally
            {
                con.cierraConexion();
            }
            return mensaje;
        }



    }

}