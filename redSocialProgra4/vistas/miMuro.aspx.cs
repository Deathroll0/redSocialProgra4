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
    public partial class miMuro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Post p = new Post();
            controladorPost cp = new controladorPost();
            List<Post> lista = cp.controladorMiMuro(Session["correo"].ToString());
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
                    Response.Write("<tr><td><a href='perfilPersona.aspx?correo="+lista[i].Creador+"'>" + lista[i].NombreCreador + "</a></td><td>" + lista[i].Texto + "</td><td>" + lista[i].Fecha + "</td></tr>");
                }
                Response.Write("</table>");
            }
        }
    }
}