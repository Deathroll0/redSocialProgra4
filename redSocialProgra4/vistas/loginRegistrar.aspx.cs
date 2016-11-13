using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace redSocialProgra4.vistas
{
    public partial class loginRegistrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["mensaje"] != null)
            {
                Response.Write(Session["mensaje"].ToString());
                Session.Remove("mensaje");
            }
        }
    }
}