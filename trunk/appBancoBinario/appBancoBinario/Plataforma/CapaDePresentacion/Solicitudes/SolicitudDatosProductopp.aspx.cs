using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appBancoBinario.Plataforma.CapaDeNegocio.Solicitudes;
using appBancoBinario.Plataforma.CapaDeNegocio.Productos;

namespace appBancoBinario.Plataforma.CapaDePresentacion.Solicitudes
{
    public partial class SolicitudDatosProductopp : System.Web.UI.Page
    {
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
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            SolicitudPrestamo solicitud = (SolicitudPrestamo)Session["solicitud"];
            
            if (solicitud != null)
            {
                //NUMERO_SOLICITUD
                solicitud.NumeroSolicitud = "PP000001";
                //MONTO_PRESTAMO
                solicitud.MontoPrestamo = (txtMontoPrestamo.Text == null || txtMontoPrestamo.Text=="") ? 0.0f : float.Parse(txtMontoPrestamo.Text);
                
                String destino = txtDestino.Text;
                solicitud.Destino = (destino == null) ? "" : destino;
                //CON_GARANTE
                solicitud.ConGarante = (rdlConGarante.SelectedValue == "si") ? true : false;
                //IDENTIFICACION_GARANTE
                String garanteID = txtIdentificacionGarante.Text;
                solicitud.IdentificacionGarante = (garanteID == null || garanteID=="") ? "" : garanteID;
                //TASA INTERES
                solicitud.Tasa = (txtTasa.Text == null || txtTasa.Text=="") ? 0.0f : float.Parse(txtTasa.Text);
                
                

                Prestamo prestamo = new Prestamo();
                prestamo.TipoProducto = TipoProducto.PRESTAMO.ToString();
                //MONTO_CUOTA
                prestamo.MontoCuota = (solicitud.MontoPrestamo * solicitud.Tasa) / float.Parse(ddlPlazo.Text);
                solicitud.ProductoAsociado = prestamo;

                Session["solicitud"] = solicitud;
                Response.Redirect("SolicitudConfirmacion.aspx");
            }
            
        }
    }
}