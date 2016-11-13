using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using redSocialProgra4.controladores;

namespace redSocialProgra4.validadores
{
    public partial class validaRegistrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string correo = Request["TB1"].ToString();
            string nombre = Request["TB2"].ToString();
            string apellido = Request["TB3"].ToString();
            string clave = Request["TB4"].ToString();
            string rClave = Request["TB5"].ToString();
            controladorUsuario cu = new controladorUsuario();
            string mensaje = cu.validaRegistrar(correo, nombre, apellido, clave, rClave);
            if (mensaje.Equals("Usuario Registrado"))
            {
                Session["mensaje"] = mensaje;
                Response.Redirect("../vistas/loginRegistrar.aspx");
            }
            else
            {
                Session["mensaje"] = mensaje;
                Response.Redirect("../vistas/loginRegistrar.aspx");
            }
        }
    }
}