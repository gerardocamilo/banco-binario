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
        Plataforma.CapaDeNegocio.Plataforma plataforma = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            plataforma = new Plataforma.CapaDeNegocio.Plataforma();
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
                Solicitud solicitud = plataforma.pObtenerSolicitudPorNumero(txtNumeroSolicitud.Text);
                if(solicitud!=null){
                    Session["solicitud"] = solicitud;
                    Response.Redirect("VerSolicitud.aspx");
                }
                
            }
        }

        
        protected void gvSolicitudes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSolicitudes.PageIndex = e.NewPageIndex;
            gvSolicitudes.DataBind();
        }

        protected void gvSolicitudes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Redirect("VerSolicitud.aspx?solicitud=" + gvSolicitudes.SelectedRow.Cells[0].Text);
        }

        protected void gvSolicitudes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (gvSolicitudes.SelectedRow != null)
            {
                Response.Redirect("VerSolicitud.aspx?solicitud=" + gvSolicitudes.SelectedRow.Cells[0].Text);
            }
        }
    }
}