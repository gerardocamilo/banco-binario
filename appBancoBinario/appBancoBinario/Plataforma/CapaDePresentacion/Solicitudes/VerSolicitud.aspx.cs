using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appBancoBinario.Plataforma.CapaDeNegocio.Solicitudes;
using appBancoBinario.Clientes.CapaDeNegocio.Clases;
using appBancoBinario.Plataforma.CapaDeNegocio.Productos;

namespace appBancoBinario.Plataforma.CapaDePresentacion.Solicitudes
{
    public partial class VerSolicitud : System.Web.UI.Page
    {
        public ClientesDetails cliente;
        public string noSolicitud;
        public string producto;
        public string estado;
        public Solicitud solicitud;
        protected void Page_Load(object sender, EventArgs e)
        {
            solicitud = (Solicitud)Session["solicitud"];
            noSolicitud = solicitud.NumeroSolicitud;
            SolicitudPrestamo solicitudPrestamo = null;
            SolicitudCuenta solicitudCuenta = null;
            SolicitudTarjeta solicitudTarjeta = null;

            cliente = solicitud.Cliente;
            string tipoProducto = solicitud.ProductoAsociado.TipoProducto;
            estado = solicitud.Estado;

            if (estado.Equals(EstadoSolicitud.PENDIENTE_APROBACION.ToString())) {
                estado = "Pendiente Aprobación";
            }
            else if (estado.Equals(EstadoSolicitud.CANCELADA.ToString()))
            {
                estado = "Cancelada";
            }
            else if (estado.Equals(EstadoSolicitud.APROBADA.ToString()))
            {
                estado = "Aprobada";
            }

            if(solicitud is SolicitudPrestamo){
                solicitudPrestamo = (SolicitudPrestamo)solicitud;
                producto = "Préstamo";

            }
            else if(solicitud is SolicitudCuenta){
                solicitudCuenta = (SolicitudCuenta)solicitud;
                

                if (tipoProducto.Equals(TipoProducto.CUENTA_AHORRO.ToString())) {
                    producto = "Cuenta de Ahorro";
                }
                else if (tipoProducto.Equals(TipoProducto.CUENTA_CORRIENTE.ToString()))
                {
                    producto = "Cuenta Corriente";
                }            
            }
            else if(solicitud is SolicitudTarjeta){
                solicitudTarjeta = (SolicitudTarjeta)solicitud;
                
                if (tipoProducto.Equals(TipoProducto.TARJETA_CREDITO.ToString()))
                {
                    producto = "Tarjeta de Crédito";
                }
                else if (tipoProducto.Equals(TipoProducto.TARJETA_DEBITO.ToString()))
                {
                    producto = "Tarjeta de Débito";
                }
            }

        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            ClientesDetails cliente = solicitud.Cliente;
            if(cliente.Prospecto == "True"){
                solicitud.Cliente.Prospecto = "False";
            }

            if (solicitud.SolicitudAsociada != null) {
                solicitud.SolicitudAsociada.Estado = EstadoSolicitud.APROBADA.ToString();
            }
            
            solicitud.Estado = EstadoSolicitud.APROBADA.ToString();

            Session["solicitud"] = solicitud;
                
        }        
    }
}