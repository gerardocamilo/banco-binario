using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appBancoBinario.Plataforma.CapaDeNegocio.Productos;

namespace appBancoBinario.Plataforma.CapaDePresentacion.Productos
{
    public partial class VerProducto : System.Web.UI.Page
    {
        public Producto producto;
        public Prestamo prestamo;
        protected void Page_Load(object sender, EventArgs e)
        {
            producto = (Producto)Session["producto"];
            if(producto!=null){
                if (producto is Prestamo)
                {
                    prestamo = (Prestamo)producto;
                }
            }
            
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }
}