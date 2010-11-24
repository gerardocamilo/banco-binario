using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using appBancoBinario.Clientes.CapaDeNegocio;


namespace appBancoBinario.Clientes.CapaDePresentacion
{
    public partial class Agregar_Cliente : System.Web.UI.Page
    {
        String indentificacion;
        appBancoBinario.Clientes.CapaDeNegocio.Clientes clsclientes = new appBancoBinario.Clientes.CapaDeNegocio.Clientes();
        System.Data.DataTable dtable = new System.Data.DataTable();
        System.Data.DataTable dtable2 = new System.Data.DataTable();
        protected void Page_Load(object sender, EventArgs e)
         
        {
            this.txtidentificacion.Focus();
         
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Identificacion"]))
                {
                    DeshabilitarCampos();
                    FillInfo();
                
                }
                else
                   
                  
                {
                    return;
                }                       
               
            
            }

        }

      
        private void Guardar()
        {
            //ConfiguracionParametro cslConfiguracionParametro = new ConfiguracionParametro
            //if (cslConfiguracionParametro.validarCedula(this.txtIdentificacion.Text)== true)
            //Este metodo valida la cedula digitada, antes de insertar el cliente.
            if (!validarCedula(this.txtidentificacion.Text)== true)
            {
                Response.Write(@"<script language='javascript'>alert('Cedula No valida: " + this.txtidentificacion.Text + " .');</script>");
                this.txtidentificacion.Focus();
                return;
            }
                       


            if (string.IsNullOrEmpty(txtidentificacion.Text))
            {
                Response.Write(@"<script language='javascript'>alert('Favor de colocar la indentificacion del cliente');</script>");
                this.txtidentificacion.Focus();
                return;
            
            }


            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                Response.Write(@"<script language='javascript'>alert('Favor de colocar el Nombre del cliente');</script>");
                this.txtNombre.Focus();
                return;

            }


            if (string.IsNullOrEmpty(txtApellidos.Text))
            {
                Response.Write(@"<script language='javascript'>alert('Favor de colocar los apellidos del cliente');</script>");
                this.txtApellidos.Focus();
                return;

            }


            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                Response.Write(@"<script language='javascript'>alert('Favor de colocar el telefono del cliente');</script>");
                this.txtTelefono.Focus();
                return;

            }

            if (string.IsNullOrEmpty(txtCelular.Text))
            {
                Response.Write(@"<script language='javascript'>alert('Favor de colocar el Celular del cliente');</script>");
                this.txtCelular.Focus();
                return;

            }
            ClientesDetails myClientesdetails = new ClientesDetails();
            DatosLaborablesDetails myDatosLaborablesDetails = new DatosLaborablesDetails();


          
            var with = myClientesdetails;
            
            with.Nombre = this.txtNombre.Text;
            with.Apellido = this.txtApellidos.Text;
            
            with.identificacion = this.txtidentificacion.Text;
            
            with.Direccion = this.txtDireccion.Text;
            with.Telefono = this.txtTelefono.Text;
            with.Celular = this.txtCelular.Text;
            with.Correo = this.txtCorreoElectronico.Text;
            
            with.Estado_Civil = this.ddlEstadoCivil.SelectedItem.Text;
            with.Tipo_Vivienda = this.ddlTipoResidencia.SelectedItem.Text;
            with.Estatus  = "Prospecto";
            with.Numero_Dependientes = this.txtDependientes.Text;
            
            //Se graban los datos del solicitante            
            clsclientes.InsertClientes(myClientesdetails);

            myDatosLaborablesDetails.identificacion = this.txtidentificacion.Text;
            myDatosLaborablesDetails.empresa = this.txtNombreEmpresa.Text;
            myDatosLaborablesDetails.direccion = this.txtDireccionEmpresa.Text;
            myDatosLaborablesDetails.tipo_empresa = this.ddlTipoEmpresa.SelectedItem.Text;
            myDatosLaborablesDetails.puesto = this.txtPuesto.Text;
            Double Ingresos;
            Ingresos = Double.Parse(this.txtIngresos.Text);
            myDatosLaborablesDetails.ingresos = Ingresos;
            Double Otros_Ingresos;
            Otros_Ingresos = Double.Parse(this.txtotrosingresos.Text);
            myDatosLaborablesDetails.otros_ingresos = Otros_Ingresos;
            myDatosLaborablesDetails.tiempo_empresa = this.txtTiempoLaborando.Text;
            //Se graban los Datos laborables.
            clsclientes.InsertDatosLaborables(myDatosLaborablesDetails);


            Response.Redirect("Consultar_Cliente.aspx");


        }
        private void Guardar2()

        {

            if (!validarCedula(this.txtidentificacion.Text) == true)
            {
                Response.Write(@"<script language='javascript'>alert('Cedula No valida: " + this.txtidentificacion.Text + " .');</script>");
                this.txtidentificacion.Focus();
                return;
            }



            if (string.IsNullOrEmpty(txtidentificacion.Text))
            {
                Response.Write(@"<script language='javascript'>alert('Favor de colocar la indentificacion del cliente');</script>");
                this.txtidentificacion.Focus();
                return;

            }


            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                Response.Write(@"<script language='javascript'>alert('Favor de colocar el Nombre del cliente');</script>");
                this.txtNombre.Focus();
                return;

            }


            if (string.IsNullOrEmpty(txtApellidos.Text))
            {
                Response.Write(@"<script language='javascript'>alert('Favor de colocar los apellidos del cliente');</script>");
                this.txtApellidos.Focus();
                return;

            }


            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                Response.Write(@"<script language='javascript'>alert('Favor de colocar el telefono del cliente');</script>");
                this.txtTelefono.Focus();
                return;

            }

            if (string.IsNullOrEmpty(txtCelular.Text))
            {
                Response.Write(@"<script language='javascript'>alert('Favor de colocar el Celular del cliente');</script>");
                this.txtCelular.Focus();
                return;

            }
            ClientesDetails myClientesdetails = new ClientesDetails();

            DatosLaborablesDetails myDatosLaborablesDetails = new DatosLaborablesDetails();
            var with = myClientesdetails;

       

            with.identificacion = this.txtidentificacion.Text;
           
            with.Direccion = this.txtDireccion.Text;
            with.Telefono = this.txtTelefono.Text;
            with.Celular = this.txtCelular.Text;
            with.Correo = this.txtCorreoElectronico.Text;
          
            with.Estado_Civil = this.ddlEstadoCivil.SelectedItem.Text;
            with.Tipo_Vivienda = this.ddlTipoResidencia.SelectedItem.Text;
            
            with.Numero_Dependientes = this.txtDependientes.Text;      


            clsclientes.UpdateCliente(myClientesdetails);

            dtable2 = clsclientes.BuscarDatosLaborables_Identificacion(Request.QueryString["Identificacion"]);
            if (dtable2.Rows.Count <= 0)
            {
                myDatosLaborablesDetails.identificacion = this.txtidentificacion.Text;
                myDatosLaborablesDetails.empresa = this.txtNombreEmpresa.Text;
                myDatosLaborablesDetails.direccion = this.txtDireccionEmpresa.Text;
                myDatosLaborablesDetails.tipo_empresa = this.ddlTipoEmpresa.SelectedItem.Text;
                myDatosLaborablesDetails.puesto = this.txtPuesto.Text;
                Double Ingresos;
                Ingresos = Double.Parse(this.txtIngresos.Text);
                myDatosLaborablesDetails.ingresos = Ingresos;
                Double Otros_Ingresos;
                Otros_Ingresos = Double.Parse(this.txtotrosingresos.Text);
                myDatosLaborablesDetails.otros_ingresos = Otros_Ingresos;
                myDatosLaborablesDetails.tiempo_empresa = this.txtTiempoLaborando.Text;
                //Se graban los Datos laborables.
                clsclientes.InsertDatosLaborables(myDatosLaborablesDetails);
                Response.Redirect("Consultar_Cliente.aspx");
            }
            else
            {

                myDatosLaborablesDetails.identificacion = this.txtidentificacion.Text;
                myDatosLaborablesDetails.empresa = this.txtNombreEmpresa.Text;
                myDatosLaborablesDetails.direccion = this.txtDireccionEmpresa.Text;
                myDatosLaborablesDetails.tipo_empresa = this.ddlTipoEmpresa.SelectedItem.Text;
                myDatosLaborablesDetails.puesto = this.txtPuesto.Text;
                Double Ingresos;
                Ingresos = Double.Parse(this.txtIngresos.Text);
                myDatosLaborablesDetails.ingresos = Ingresos;
                Double Otros_Ingresos;
                Otros_Ingresos = Double.Parse(this.txtotrosingresos.Text);
                myDatosLaborablesDetails.otros_ingresos = Otros_Ingresos;
                myDatosLaborablesDetails.tiempo_empresa = this.txtTiempoLaborando.Text;

                clsclientes.UpdateDatosLaborables(myDatosLaborablesDetails);

                Response.Redirect("Consultar_Cliente.aspx");

            }

        }
        private void DeshabilitarCampos() 
        {
            this.btnVerificadorCedula.Visible = false;
            this.txtidentificacion.ReadOnly = true;
            this.txtNombre.ReadOnly = true;
            this.txtApellidos.ReadOnly = true;

            this.txtidentificacion.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtApellidos.Enabled = false;
            

        
        }
        private void FillInfo()
        {


            //Este metodo busca el cliente y me duvuelve un Datatable y de ese datatable tomo la fila que trajo.
            indentificacion = Request.QueryString["Identificacion"];
            
            dtable = clsclientes.BuscarClientePorIdentificacion(indentificacion);
            dtable2 = clsclientes.BuscarDatosLaborables_Identificacion(indentificacion);
            if (dtable.Rows.Count <= 0)
            {
                Response.Redirect("Consultar_Cliente.aspx");
                return;

            }
         
            
            //Aqui el metodo fillcampos tomo la fila del datatable
            FillCampos(dtable.Rows[0]);
            if (dtable2.Rows.Count <= 0)
            {
                Response.Write(@"<script language='javascript'>alert('Este cliente no posee datos laborables');</script>");

            }
            else
            {
                FillCampos2(dtable2.Rows[0]);
            }
        

        }

        private void FillCampos(System.Data.DataRow dRow)
        {
            //Aqui igualo cada campo del datatable a cada componente donde deseeo ver la informacion.
            ClientesDetails MyClientesDetails = new ClientesDetails();

            //var with = MyClientesDetails;
            this.txtNombre.Text = (string)dRow["Nombre"];
            this.txtApellidos.Text = (string)dRow["Apellido"];
            
            this.txtidentificacion.Text = (string)dRow["identificacion"];
            
            this.txtDireccion.Text = (string)dRow["direccion"];
            this.txtTelefono.Text = (string)dRow["telefono"];
            this.txtCelular.Text = (string)dRow["celular"];
            this.txtCorreoElectronico.Text=(string)dRow["correo"];
            
            this.ddlEstadoCivil.Text = (string)dRow["Estado_Civil"];
            this.ddlTipoResidencia.Text = (string)dRow["Tipo_Vivienda"];
         
           //this.txtDependientes.Text = (String)dRow["Numero_Dependientes"];
            String x = dRow["Numero_Dependientes"].ToString();
            this.txtDependientes.Text = x;


            
        
        }
        private void FillCampos2(System.Data.DataRow dRow)
        {
            //Aqui igualo cada campo del datatable a cada componente donde deseeo ver la informacion.
            ClientesDetails MyClientesDetails = new ClientesDetails();

            //var with = MyClientesDetails;
            this.txtNombreEmpresa.Text = (string)dRow["Empresa"];
            this.txtDireccionEmpresa.Text = (string)dRow["DIRECCION"];

            this.ddlTipoEmpresa.Text = (string)dRow["tipo_empresa"];

            this.txtPuesto.Text = (string)dRow["Puesto"];
            String Ingresos = dRow["ingresos"].ToString();
            this.txtIngresos.Text = Ingresos;
            String Otros_Ingresos = dRow["Otros_ingresos"].ToString();
            this.txtotrosingresos.Text = Otros_Ingresos;
            this.txtTiempoLaborando.Text = (string)dRow["tiempo_empresa"];        


        }

 
        public static bool validarCedula(String c)
        {
            if (c.Length != 11)
            {
                return false;
            }
            long ced = long.Parse(c);
            long digito, suma = 0;
            bool alt = false;
            while (ced != 0)
            {
                digito = ced % 10;
                if (alt)
                {
                    digito *= 2;
                    digito -= (digito > 9) ? 9 : 0;
                }
                suma += digito;
                alt = !alt;
                ced /= 10;
            }
            return (suma % 10 == 0);
        }

        protected void btnCancelar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Consultar_Cliente.aspx");
        }

        protected void btnAceptar_Click1(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["Identificacion"]))
            {
                Guardar2();
            }
            else
            {
                Guardar();
            }
           

        }

        protected void btnVerificadorCedula_Click(object sender, ImageClickEventArgs e)
        {
            if (!validarCedula(this.txtidentificacion.Text) == true)
            {
                Response.Write(@"<script language='javascript'>alert('Cedula No valida: " + this.txtidentificacion.Text + " .');</script>");
                this.txtidentificacion.Focus();
                return;
               
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('Cedula Numero: " + this.txtidentificacion.Text + " esta correcta.');</script>");
            }

        }

    
    }
}