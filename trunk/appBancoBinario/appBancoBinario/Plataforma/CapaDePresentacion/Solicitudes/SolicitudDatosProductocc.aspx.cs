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
    public partial class SolicitudDatosProductocc : System.Web.UI.Page
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
            Solicitud solicitud = (Solicitud)Session["solicitud"];
            if (solicitud != null)
            {
                solicitud.NumeroSolicitud = "testnumber";
                Cuenta cuenta = new Cuenta();
                cuenta.TipoProducto = TipoProducto.CUENTA_CORRIENTE.ToString();
                solicitud.ProductoAsociado = cuenta;
                Response.Redirect("SolicitudConfirmacion.aspx");
            }

        }

    }
}