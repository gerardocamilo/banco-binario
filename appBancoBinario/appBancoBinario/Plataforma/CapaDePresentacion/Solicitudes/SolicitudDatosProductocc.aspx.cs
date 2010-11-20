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
                solicitud.NumeroSolicitud = "solCuenta03";
                Cuenta cuenta = new Cuenta();
                cuenta.TipoProducto = TipoProducto.CUENTA_CORRIENTE.ToString();
                solicitud.ProductoAsociado = cuenta;



                if (rbTarjeta.SelectedValue.Equals("Si"))
                {
                    SolicitudTarjeta solicitudTarjeta = new SolicitudTarjeta();
                    solicitudTarjeta.NumeroSolicitud = "solTarjeta";
                    solicitudTarjeta.Cliente = solicitud.Cliente;
                    Tarjeta tarjeta = new Tarjeta();
                    tarjeta.TipoTrarjeta = TipoTarjeta.DEBITO.ToString();
                    tarjeta.TipoProducto = TipoProducto.TARJETA_DEBITO.ToString();
                    solicitudTarjeta.ProductoAsociado = tarjeta;
                    solicitud.NumeroSolicitudAsociado = solicitudTarjeta.NumeroSolicitud;
                    Session["solicitudAsociada"] = solicitudTarjeta;
                }

                Session["solicitud"] = solicitud;
                Response.Redirect("SolicitudConfirmacion.aspx");
            }

        }

    }
}