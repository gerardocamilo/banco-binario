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
                solicitud.NumeroSolicitud = "testnumber";
                try {
                    solicitud.MontoPrestamo = float.Parse(txtMontoPrestamo.Text);
                }
                catch(FormatException) {
                    
                    Response.Write("<script>alert(\"Valor no valido\")</script>");
                    txtMontoPrestamo.Focus();
                }
                try
                {
                    solicitud.Tasa = float.Parse(txtTasa.Text);
                }
                catch (FormatException)
                {
                    Response.Write("alert(\"Valor no valido\")"); 
                    txtTasa.Focus();
                }
                             
                

                solicitud.Destino = txtDestino.Text;
                Prestamo prestamo = new Prestamo();
                prestamo.TipoProducto = TipoProducto.PRESTAMO.ToString();
                solicitud.ProductoAsociado = prestamo;
                Session["solicitud"] = solicitud;
                Response.Redirect("SolicitudConfirmacion.aspx");
            }
            
        }
    }
}