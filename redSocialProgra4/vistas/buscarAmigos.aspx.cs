using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using redSocialProgra4.modelos;

namespace redSocialProgra4.vistas
{
    public partial class buscarAmigos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["correo"]!=null)
            {
                //esta logeado
                if (Session["lista"]!=null)
                {
                    //si se envio la lista, osea existen los wns
                    List<Usuario> lista = (List<Usuario>) Session["lista"];
                    Response.Write("<table border='1px'>");
                    for (int i = 0; i < lista.Count; i++)
                    {
                        Response.Write("<tr><td><a href='perfilPersona.aspx?correo="+lista[i].Correo+"'>Nombre= "+lista[i].Nombre+"</td><td>Apellido= "+lista[i].Apellido+"</a></td></tr>");
                    }
                    Response.Write("</table>");

                }
                else
                {
                    Response.Write(Session["mensaje"]);
                    Session.Remove("mensaje");
                }
            }
            else
            {
                Session["mensaje"] = "Debe hacer login";
                Response.Redirect("loginRegistrar.aspx");
            }
        }
    }
}