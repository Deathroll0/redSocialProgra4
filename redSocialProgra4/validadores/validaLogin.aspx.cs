using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using redSocialProgra4.controladores;

namespace redSocialProgra4.validadores
{
    public partial class validaLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string correo = Request["TB6"].ToString();
            string clave = Request["TB7"].ToString();
            controladorUsuario cu = new controladorUsuario();
            string mensaje = cu.validaLogin(correo, clave);
            string[] aux = mensaje.Split('<');
            if (aux[0].Equals("a"))
            {
                Session["correo"] = aux[1];
                Session["nombre"] = aux[2];
                Session["apellido"] = aux[3];
                Response.Redirect("../vistas/index.aspx");
            }
            else
            {
                Session["mensaje"] = mensaje;
                Response.Redirect("../vistas/loginRegistrar.aspx");
            }
        }
    }
}