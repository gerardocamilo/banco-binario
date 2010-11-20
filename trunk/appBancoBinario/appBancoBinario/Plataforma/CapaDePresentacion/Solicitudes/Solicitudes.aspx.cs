using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appBancoBinario.Plataforma.CapaDeNegocio.Solicitudes;

namespace appBancoBinario.Plataforma.CapaDePresentacion.Solicitudes
{
    public partial class Solicitudes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIr_Click(object sender, EventArgs e)
        {
            Session["indicadorPagina"] = ddlTipoSolicitud.SelectedItem.Value;

            string indicadorPagina  = ddlTipoSolicitud.SelectedItem.Value;

            if (indicadorPagina.Equals("pp"))
            {
               SolicitudPrestamo solicitud = new SolicitudPrestamo();
               Session["solicitud"] = solicitud;
            }
            else if (indicadorPagina.Equals("ca"))
            {
                SolicitudCuenta solicitud = new SolicitudCuenta();
                Session["solicitud"] = solicitud;
            }
            else if (indicadorPagina.Equals("cc"))
            {
                SolicitudCuenta solicitud = new SolicitudCuenta();
                Session["solicitud"] = solicitud;
            }
            else if (indicadorPagina.Equals("td"))
            {
                SolicitudTarjeta solicitud = new SolicitudTarjeta();
                Session["solicitud"] = solicitud;
            }
            else if (indicadorPagina.Equals("tc"))
            {
                SolicitudTarjeta solicitud = new SolicitudTarjeta();
                Session["solicitud"] = solicitud;
            }

            

            Session["tituloContenido"] = "Solicitud de " + ddlTipoSolicitud.SelectedItem.Text;
            Response.Redirect("SolicitudDatosSolicitante.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!txtNumeroSolicitud.Text.Equals(""))
            {
                Response.Redirect("VerSolicitud.aspx?solicitud=" + txtNumeroSolicitud.Text);
            }
        }
    }
}