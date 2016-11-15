using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace redSocialProgra4.vistas
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["correo"] != null)
            {
                if (Session["mensaje"]!=null)
                {
                    string correo = Session["correo"].ToString();
                    string nombre = Session["nombre"].ToString();
                    string apellido = Session["apellido"].ToString();
                    Response.Write("<h1>Bienvenido " + nombre + " " + apellido + "</h1>");
                    Response.Write(Session["mensaje"]);
                    Session.Remove("mensaje");
                }
                

            }
            else
            {
                Session["mensaje"] = "debe realizar login";
                Response.Redirect("loginRegistrar.aspx");
            }
        }
    }
}