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
        protected void Page_Load(object sender, EventArgs e)
        {
            PlataformaDAO plataforma = new PlataformaDAO();
            gvProductos.DataSource = plataforma.dObtenerProductos();
            gvProductos.DataBind();
        }

        protected void btnIr_Click(object sender, EventArgs e)
        {
            
            Session["noProducto"] = txtNoProducto.Text;

            PlataformaDAO plataforma = new PlataformaDAO();

            plataforma.pObtenerProductoPorCodigo(txtNoProducto.Text);

            Response.Redirect("VerProducto.aspx");
        }

        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvProductos.SelectedIndex > 0) {
                //Response.Redirect("VerProducto.aspx?solicitud=" + gvProductos.SelectedRow.Cells[0].Text);
            }
            
        }

        
    }
}