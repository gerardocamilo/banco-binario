using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appBancoBinario.Plataforma.CapaDePresentacion.Solicitudes
{
    public partial class SolicitudDatosLaborales : System.Web.UI.Page
    {
        public string indicadorPagina = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Solicitudes.aspx");
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.UrlReferrer.ToString());
            int x = 10;
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            indicadorPagina = Session["indicadorPagina"].ToString();
            if (indicadorPagina != "")
            {
                if (indicadorPagina.Equals("pp"))
                {
                    Response.Redirect("SolicitudDatosProductopp.aspx");
                }
                else if (indicadorPagina.Equals("ca"))
                {
                    Response.Redirect("SolicitudDatosProductoca.aspx");
                }
                else if (indicadorPagina.Equals("cc"))
                {
                    Response.Redirect("SolicitudDatosProductocc.aspx");
                }
                else if (indicadorPagina.Equals("td"))
                {
                    Response.Redirect("SolicitudDatosProductotd.aspx");
                }
                else if (indicadorPagina.Equals("tc"))
                {
                    Response.Redirect("SolicitudDatosProductotc.aspx");
                }
            }
        }
    }
}
