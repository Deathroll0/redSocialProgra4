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
    public partial class perfilPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //recibo el correo
            string correo = Request.QueryString["correo"];
            Usuario u = new Usuario();
            Usuario u2 = u.buscaUno(correo);
            Response.Write("<h1>Nombre="+u2.Nombre+" Apellido="+u2.Apellido+" Correo="+u2.Correo+" Clave="+u2.Clave+"</h1>");
            controladorUsuario cu = new controladorUsuario();
            if (cu.sonAmigos((Session["correo"]).ToString(), correo))
            {
                Response.Write("Muestro el muro del wn");
                controladorPost cp = new controladorPost();
                List<Post> lista = cp.controladorMiMuro(correo);
                if (lista[0].Texto.Equals("Su muro se encuentra vacio"))
                {
                    Response.Write(lista[0].Texto);
                }
                else
                {
                    Response.Write("<table border='1px'>");
                    Response.Write("<tr><td>Creador</td><td>Comentario</td><td>Fecha</td></tr>");
                    for (int i = 0; i < lista.Count; i++)
                    {
                        Response.Write("<tr><td><a href='perfilPersona.aspx?correo=" + lista[i].Creador + "'>" + lista[i].NombreCreador + "</a></td><td>" + lista[i].Texto + "</td><td>" + lista[i].Fecha + "</td></tr>");
                    }
                    Response.Write("</table>");
                    Response.Write("<textarea id='txtArea' name='txtArea' cols='20' rows='2'></textarea><br /><button>enviar</button>");
                }
            }
            else
            {
                Response.Write("<button>Enviar solicitud de amistad</button>");
            }
            
        }
    }
}