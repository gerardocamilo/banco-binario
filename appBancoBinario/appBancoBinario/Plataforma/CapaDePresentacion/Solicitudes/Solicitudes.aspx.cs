using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appBancoBinario.Plataforma.CapaDeNegocio.Solicitudes;
using appBancoBinario.Plataforma.CapaDeDatos;


namespace appBancoBinario.Plataforma.CapaDePresentacion.Solicitudes
{
    public partial class Solicitudes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PlataformaDAO plataforma = new PlataformaDAO();
            gvSolicitudes.DataSource = plataforma.dObtenerSolicitudes();
            gvSolicitudes.DataBind();
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
                PlataformaDAO plataforma = new PlataformaDAO();
                plataforma.pObtenerSolicitudPorNumero();
                Response.Redirect("VerSolicitud.aspx?solicitud=" + txtNumeroSolicitud.Text);
            }
        }

        protected void gvSolicitudes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("VerSolicitud.aspx?solicitud=" + gvSolicitudes.SelectedRow.Cells[0].Text);
        }
    }
}