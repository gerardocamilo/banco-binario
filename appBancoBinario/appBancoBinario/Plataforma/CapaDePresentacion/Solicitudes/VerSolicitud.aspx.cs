using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appBancoBinario.Plataforma.CapaDeNegocio.Solicitudes;
using appBancoBinario.Clientes.CapaDeNegocio.Clases;

namespace appBancoBinario.Plataforma.CapaDePresentacion.Solicitudes
{
    public partial class VerSolicitud : System.Web.UI.Page
    {
        public ClientesDetails cliente;
        public string noSolicitud;
        protected void Page_Load(object sender, EventArgs e)
        {
            Solicitud solicitud = (Solicitud)Session["solicitud"];
            noSolicitud = solicitud.NumeroSolicitud;
            SolicitudPrestamo solicitudPrestamo = null;
            SolicitudCuenta solicitudCuenta = null;
            SolicitudTarjeta solicitudTarjeta = null;

            cliente = solicitud.Cliente;


            if(solicitud is SolicitudPrestamo){
                solicitudPrestamo = (SolicitudPrestamo)solicitud;

            }
            else if(solicitud is SolicitudCuenta){
                solicitudCuenta = (SolicitudCuenta)solicitud;}
            else if(solicitud is SolicitudCuenta){
                solicitudTarjeta = (SolicitudTarjeta)solicitud;}

        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {

        }        
    }
}