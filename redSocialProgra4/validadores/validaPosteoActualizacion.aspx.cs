using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using redSocialProgra4.controladores;
using redSocialProgra4.modelos;

namespace redSocialProgra4.validadores
{
    public partial class validaPosteoActualizacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string texto = Request.Form["txtArea"].ToString();
            string corre = Session["correo"].ToString();
            //String fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            controladorPost cp = new controladorPost();
            if (cp.validaTexto(texto))
            {
                Post p = new Post();
                p.Texto = texto;
                p.Receptor = corre;
                p.Creador = corre;
                p.TipoPost = 1;
                if (p.posteo(p))
                {
                    Session["mensaje"] = "Actualizado el estado";
                    Response.Redirect("../vistas/index.aspx");
                }
                else
                {
                    Session["mensaje"] = "Error al actualizar estado";
                    Response.Redirect("../vistas/index.aspx");
                }
            }
            else
            {
                Session["mensaje"] = "post no realizado";
                Response.Redirect("../vistas/index.aspx");

            }
        }
    }
}