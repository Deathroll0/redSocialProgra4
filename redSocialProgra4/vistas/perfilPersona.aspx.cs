using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
        }
    }
}