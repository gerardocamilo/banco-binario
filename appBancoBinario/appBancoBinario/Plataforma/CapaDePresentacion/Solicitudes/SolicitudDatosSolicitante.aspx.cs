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
    public partial class SolicitudDatosSolicitante : System.Web.UI.Page
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
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            ClientesDetails cd = new ClientesDetails();

            cd.identificacion = txtNoIdentificacion.Text;
            cd.Nombre = txtNombres.Text;
            cd.Apellido = txtApellidos.Text;
            cd.Estado_Civil = ddlEstadoCivil.Text;
            cd.Telefono = txtTelefono.Text;
            cd.Celular = txtCelular.Text;
            cd.Correo = txtCorreoElectronico.Text;
            cd.Direccion = txtDireccion.Text;
            cd.Tipo_Vivienda = ddlTipoResidencia.Text;

            indicadorPagina = Session["indicadorPagina"].ToString();
            
            if (indicadorPagina != null)
            {

                if (indicadorPagina.Equals("pp"))
                {
                    SolicitudPrestamo solicitud = (SolicitudPrestamo)Session["solicitud"];
                    solicitud.Cliente = cd;
                    Session["solicitud"] = solicitud;
                }
                else if (indicadorPagina.Equals("ca"))
                {
                    SolicitudCuenta solicitud = (SolicitudCuenta)Session["solicitud"];
                    solicitud.Cliente = cd;
                    Session["solicitud"] = solicitud;
                }
                else if (indicadorPagina.Equals("cc"))
                {
                    SolicitudCuenta solicitud = (SolicitudCuenta)Session["solicitud"];
                    solicitud.Cliente = cd;
                    Session["solicitud"] = solicitud;
                }
                else if (indicadorPagina.Equals("td"))
                {
                    SolicitudTarjeta solicitud = (SolicitudTarjeta)Session["solicitud"];
                    solicitud.Cliente = cd;
                    Session["solicitud"] = solicitud;
                }
                else if (indicadorPagina.Equals("tc"))
                {
                    SolicitudTarjeta solicitud = (SolicitudTarjeta)Session["solicitud"];
                    solicitud.Cliente = cd;
                    Session["solicitud"] = solicitud;
                }
            }            
            Response.Redirect("SolicitudDatosLaborales.aspx");
        }

        
    }
}