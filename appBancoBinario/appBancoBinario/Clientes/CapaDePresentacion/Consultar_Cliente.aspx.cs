using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appBancoBinario.Clientes.CapaDeNegocio;

namespace appBancoBinario.Clientes.CapaDePresentacion
{
    public partial class Consultar_Cliente : System.Web.UI.Page
    {
        appBancoBinario.Clientes.CapaDeNegocio.Clientes clsClientes = new appBancoBinario.Clientes.CapaDeNegocio.Clientes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.txtBuscar.Focus();
                GvClientes.ShowHeader = true;
            }

        }
  

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == string.Empty)
                return;

            {
            }

                ClientesDetails myClientesDetails = new ClientesDetails();
                var with = myClientesDetails;
    
               with.identificacion = txtBuscar.Text;
                      
              
              //  GvClientes.DataSource = clsClientes.GetClientesByiDentificacion(myClientesDetails);
               clsClientes.BuscarClientePorIdentificacion_(txtBuscar.Text);
                GvClientes.DataBind();
            }
        
        protected void btnMostrar_Click(object sender, EventArgs e)
        {


            ClientesDetails myClientesDetails = new ClientesDetails();
            var with = myClientesDetails;
            switch(btnMostrar.Text)
            {
                case "Cliente":
                       
                
                string Cliente = "Cliente";
                FillGrid(Cliente);
                this.btnMostrar.Text = "Prospecto";
                    break;
                case "Prospecto":                    
                
                string Prospecto = "Prospecto";

                FillGrid(Prospecto);
                this.btnMostrar.Text = "Cliente";
                break;

            }


           


        }
        public void FillGrid(string estatus) 
        {

            GvClientes.DataSource = clsClientes.GetClientes(estatus);
            GvClientes.DataBind();
        
        }
        public void GetGridIndex()
        {
            string i;
            GridViewRow row = GvClientes.SelectedRow;
          i=row.Cells[0].Text;
        }

        protected void GvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvClientes.PageIndex = e.NewPageIndex;
            GvClientes.DataBind();
        }
    }
}