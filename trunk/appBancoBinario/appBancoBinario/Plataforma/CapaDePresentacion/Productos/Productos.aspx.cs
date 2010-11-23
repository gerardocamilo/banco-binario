using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appBancoBinario.Plataforma.CapaDeDatos;

namespace appBancoBinario.Plataforma.CapaDePresentacion.Productos
{
    public partial class Productos : System.Web.UI.Page
    {
        Plataforma.CapaDeNegocio.Plataforma plataforma;
        protected void Page_Load(object sender, EventArgs e)
        {
            plataforma = new Plataforma.CapaDeNegocio.Plataforma();
            gvProductos.DataSource = plataforma.dObtenerProductos();
            gvProductos.DataBind();
        }

        protected void btnIr_Click(object sender, EventArgs e)
        {
            
            Session["noProducto"] = txtNoProducto.Text;

            

            plataforma.pObtenerProductoPorCodigo(txtNoProducto.Text);

            Response.Redirect("VerProducto.aspx");
        }

        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvProductos.SelectedIndex > 0) {
                //Response.Redirect("VerProducto.aspx?solicitud=" + gvProductos.SelectedRow.Cells[0].Text);
            }
            
        }

        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductos.PageIndex = e.NewPageIndex;
            gvProductos.DataBind();
        }

        
    }
}