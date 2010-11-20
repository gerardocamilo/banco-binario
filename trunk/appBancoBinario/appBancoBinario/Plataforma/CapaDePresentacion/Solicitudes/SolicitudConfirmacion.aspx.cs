using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appBancoBinario.Plataforma.CapaDeNegocio.Solicitudes;
using appBancoBinario.Plataforma.CapaDeNegocio;

namespace appBancoBinario.Plataforma.CapaDePresentacion.Solicitudes
{
    public partial class SolicitudConfirmacion : System.Web.UI.Page
    {
        public string _sNoSolicitud= "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Solicitud solicitud = (Solicitud)Session["solicitud"];

            if (solicitud != null)
            {   
                appBancoBinario.Plataforma.CapaDeNegocio.Plataforma plataforma = new appBancoBinario.Plataforma.CapaDeNegocio.Plataforma();

                if (solicitud.NumeroSolicitudAsociado != null) {

                    Solicitud solicitudAsociada = (Solicitud)Session["solicitud Asociada"];
                    if(solicitudAsociada!=null){
                        plataforma.solicitarProducto(solicitudAsociada);
                    }
                    
                }
                plataforma.solicitarProducto(solicitud);

                _sNoSolicitud = solicitud.NumeroSolicitud;

                
            }
            
        }
    }
}