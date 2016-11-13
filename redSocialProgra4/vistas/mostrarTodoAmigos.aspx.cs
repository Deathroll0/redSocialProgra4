using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using redSocialProgra4.controladores;
using redSocialProgra4.modelos;

namespace redSocialProgra4.vistas
{
    public partial class mostrarTodoAmigos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["correo"] == null)
            {
                Session["mensaje"] = "debe realizar login";
                Response.Redirect("loginRegistrar.aspx");
            }
            else
            {
                controladorUsuario cu = new controladorUsuario();
                ////Usuario u = new Usuario();
                ////List<Usuario> lista = u.buscaTodosTablaAmigos(Session["correo"].ToString());//aca tengo la lista con los dos correos
                ////ahora hay que comparar ambas posiciones y ver cual es el correo diferente.
                ////List<string> correoAmigos = new List<string>();
                ////for (int i = 0; i < lista.Count; i++)
                ////{
                ////    if (Session["correo"].Equals(lista[i].Correo))//pregunto si el primer correo (usuario1 de la tabla amigos) coincide con la session, si es asi significa que el otro es el correo del amigo.
                ////    {
                ////        correoAmigos.Add(lista[i].Nombre);//en el metodo de busqueda el segundo correo (de usuario2 de la tabla amigos) se guardo en nombre.
                ////    }
                ////    else//si no coinciden con la posicion 0, significa que la posicion 0 es el correo del amigo.
                ////    {
                ////        correoAmigos.Add(lista[i].Correo);
                ////    }
                ////}
                ////ahora tengo una lista con todos los correos de los amigos, simplemente creo una lista 2 donde busco cada uno y se imprime.7
                ////List<Usuario> listaAmigos = new List<Usuario>();
                ////for (int i = 0; i < correoAmigos.Count; i++)
                ////{
                ////    Usuario u3 = u.buscaUno(correoAmigos[i]);
                ////    listaAmigos.Add(u3);
                ////}
                //ahora se recorre la lista con los amigos completos y se imprime
                List<Usuario> listaAmigos = cu.buscaTodosAmigos(Session["correo"].ToString());
                if (listaAmigos.Count == 0)
                {
                    Response.Write("Aun no tienes amigos :'(");
                }
                else
                {
                    Response.Write("<table border='1px'>");
                    Response.Write("<tr><td>Nombre</td><td>Apellido</td></tr>");
                    for (int i = 0; i < listaAmigos.Count; i++)
                    {

                        Response.Write("<tr>");
                        //Response.Write("<td>");
                        //Response.Write(listaAmigos[i].Correo);
                        //Response.Write("</td>");

                        Response.Write("<td><a href='perfilPersona.aspx?correo="+listaAmigos[i].Correo+"'");
                        Response.Write(">"+listaAmigos[i].Nombre+"</a>");
                        Response.Write("</td>");

                        Response.Write("<td>");
                        Response.Write(listaAmigos[i].Apellido);
                        Response.Write("</td>");

                        Response.Write("</tr>");

                    }
                    Response.Write("</table>");
                }
            }

        
        }
    }
}