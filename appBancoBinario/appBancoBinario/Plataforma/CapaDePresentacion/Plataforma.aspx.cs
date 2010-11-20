using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appBancoBinario.Plataforma.CapaDePresentacion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Plataforma.aspx");
        }
    }
}