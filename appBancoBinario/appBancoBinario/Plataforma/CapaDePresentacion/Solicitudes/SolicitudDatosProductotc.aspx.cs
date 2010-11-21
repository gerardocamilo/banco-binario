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
    public partial class SolicitudDatosProductotc : System.Web.UI.Page
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
                solicitud.NumeroSolicitud = "solTarjeta03";
                Tarjeta tarjeta = new Tarjeta();

                if (ddlTipoTarjeta.SelectedValue.Equals("visa"))
                {
                    tarjeta.TipoTrarjeta = TipoTarjeta.VISA.ToString();
                }
                else if (ddlTipoTarjeta.SelectedValue.Equals("mastercard"))
                {
                    tarjeta.TipoTrarjeta = TipoTarjeta.MASTERCARD.ToString();
                }

                tarjeta.RecibirTarjeta = ddlLugaraRecibirTarjeta.SelectedItem.Text;
                tarjeta.EnvioTarjeta = ddlEnvioEstadoCuenta.SelectedItem.Text;
                tarjeta.TipoProducto = TipoProducto.TARJETA_CREDITO.ToString();
                solicitud.ProductoAsociado = tarjeta;
                SolicitudCuenta solicitudCuenta = new SolicitudCuenta();
                solicitudCuenta.NumeroSolicitud = "solCuenta";
                solicitudCuenta.Cliente = solicitud.Cliente;
                Cuenta cuenta = new Cuenta();
                cuenta.TipoProducto = TipoProducto.CUENTA_TARJETA.ToString();
                solicitudCuenta.ProductoAsociado = cuenta;
                solicitud.NumeroSolicitudAsociado = solicitudCuenta.NumeroSolicitud;
                Session["solicitudAsociada"] = solicitudCuenta;

                Session["solicitud"] = solicitud;
                Response.Redirect("SolicitudConfirmacion.aspx");
            }

        }

    }
}