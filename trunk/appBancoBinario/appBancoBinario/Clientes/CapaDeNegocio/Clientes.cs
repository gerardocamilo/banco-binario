using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Data.Sql;
using System.Data.SqlClient;
using System.ComponentModel;


namespace appBancoBinario.Clientes.CapaDeNegocio
{

    /**En esta clase tenemos todos los campos de la tabla de clientes para pasarlos como parametros a cada procedimientos.
     * Ademas Al momento de pasarles cada unos de los parametros al metodo le pasamos myClientesDetails que va a contener la informacion de todos los campos que insertaremos,
     * O actualizaremos en en la Base de Datos.
        **/
    public class ClientesDetails
    {

        public string Nombre = null;
        public string Apellido = null;        
        public string identificacion = null;        
        public string Direccion = null;
        public string Telefono = null;
        public string Celular = null;        
        public string Correo = null;        
        public string Estado_Civil = null;
        public string Tipo_Vivienda = null;
        public string Fecha_Modificacion = null;
        public string Estatus = null;
        public string Numero_Dependientes = null;




        public bool Prospecto { get; set; }
    }
    public class DatosLaborablesDetails
    {

        public string identificacion = null;
        public string empresa = null;
        public string direccion = null;
        public string tipo_empresa = null;
        public string puesto = null;
        public double ingresos = 0;
        public double otros_ingresos = 0;
        public string tiempo_empresa = null;
    
    
    
    }

    // En esta parte ponemos : SqlHelper para heredar los metodos de la clase para ejecutar procedimientos.
    public  class Clientes : SqlHelper
    {

        public void InsertClientes(ClientesDetails myClientesDetails)
        {

            SqlCommand myCommand = new SqlCommand("up_Insert_Cliente");

            myCommand.CommandType = CommandType.StoredProcedure;
           


            SqlParameter ParamerterNombre = new SqlParameter("@NOMBRE", SqlDbType.VarChar, 60);
            ParamerterNombre.Value = myClientesDetails.Nombre;
            myCommand.Parameters.Add(ParamerterNombre);

            SqlParameter Parameterapellido = new SqlParameter("@apellido", SqlDbType.VarChar, 60);
            Parameterapellido.Value = myClientesDetails.Apellido;
            myCommand.Parameters.Add(Parameterapellido);





            SqlParameter ParameterTELEFONO = new SqlParameter("@Identificacion", SqlDbType.VarChar, 18);
            ParameterTELEFONO.Value = myClientesDetails.identificacion;
            myCommand.Parameters.Add(ParameterTELEFONO);




            SqlParameter ParameterDireccion = new SqlParameter("@Direccion", SqlDbType.VarChar, 100);
            ParameterDireccion.Value = myClientesDetails.Direccion;
            myCommand.Parameters.Add(ParameterDireccion);



            SqlParameter ParameterTelefono = new SqlParameter("@Telefono", SqlDbType.VarChar, 20);
            ParameterTelefono.Value = myClientesDetails.Telefono;
            myCommand.Parameters.Add(ParameterTelefono);

            SqlParameter ParameterCelular = new SqlParameter("@Celular", SqlDbType.VarChar, 20);
            ParameterCelular.Value = myClientesDetails.Celular;
            myCommand.Parameters.Add(ParameterCelular);

            //SqlParameter ParameterFax = new SqlParameter("@Fax", SqlDbType.VarChar, 20);
            //ParameterFax.Value = myClientesDetails.Fax;
            //myCommand.Parameters.Add(ParameterFax);

            SqlParameter ParameterCorreo = new SqlParameter("@Correo", SqlDbType.VarChar, 50);
            ParameterCorreo.Value = myClientesDetails.Correo;
            myCommand.Parameters.Add(ParameterCorreo);




            SqlParameter ParameterEstado_Civil = new SqlParameter("@Estado_Civil", SqlDbType.Char, 1);
            ParameterEstado_Civil.Value = myClientesDetails.Estado_Civil;
            myCommand.Parameters.Add(ParameterEstado_Civil);


            SqlParameter ParameterTipo_Vivivenda = new SqlParameter("@Tipo_Vivienda", SqlDbType.VarChar, 10);
            ParameterTipo_Vivivenda.Value = myClientesDetails.Tipo_Vivienda;
            myCommand.Parameters.Add(ParameterTipo_Vivivenda);

            SqlParameter ParameterNumero_Dependientes = new SqlParameter("@Numero_Dependientes", SqlDbType.Int, 4);
            ParameterNumero_Dependientes.Value = myClientesDetails.Numero_Dependientes;
            myCommand.Parameters.Add(ParameterNumero_Dependientes);

            SqlParameter ParameterEstatus = new SqlParameter("@Estatus", SqlDbType.VarChar, 10);
            ParameterEstatus.Value = myClientesDetails.Estatus;
            myCommand.Parameters.Add(ParameterEstatus);

            try
            {
                //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd

                SQLExecuteNonQuery(myCommand);

            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public void UpdateCliente(ClientesDetails myClientesDetails)
        {
            SqlCommand myCommand = new SqlCommand("up_Update_Cliente");

            myCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter ParameterIdentificacion = new SqlParameter("@Identificacion", SqlDbType.VarChar, 15);
            ParameterIdentificacion.Value = myClientesDetails.identificacion;
            myCommand.Parameters.Add(ParameterIdentificacion);

            SqlParameter ParameterDireccion = new SqlParameter("@Direccion", SqlDbType.VarChar, 100);
            ParameterDireccion.Value = myClientesDetails.Direccion;
            myCommand.Parameters.Add(ParameterDireccion);



            SqlParameter ParameterTelefono = new SqlParameter("@Telefono", SqlDbType.VarChar, 20);
            ParameterTelefono.Value = myClientesDetails.Telefono;
            myCommand.Parameters.Add(ParameterTelefono);

            SqlParameter ParameterCelular = new SqlParameter("@Celular", SqlDbType.VarChar, 20);
            ParameterCelular.Value = myClientesDetails.Celular;
            myCommand.Parameters.Add(ParameterCelular);



            SqlParameter ParameterCorreo = new SqlParameter("@Correo", SqlDbType.VarChar, 50);
            ParameterCorreo.Value = myClientesDetails.Correo;
            myCommand.Parameters.Add(ParameterCorreo);


            SqlParameter ParameterEstadoCivil = new SqlParameter("@Estado_Civil", SqlDbType.Char, 1);
            ParameterEstadoCivil.Value = myClientesDetails.Estado_Civil;
            myCommand.Parameters.Add(ParameterEstadoCivil);


            SqlParameter ParameterTipoVivivenda = new SqlParameter("@Tipo_Vivienda", SqlDbType.VarChar, 10);
            ParameterTipoVivivenda.Value = myClientesDetails.Tipo_Vivienda;
            myCommand.Parameters.Add(ParameterTipoVivivenda);

            SqlParameter ParameterNumero_Dependientes = new SqlParameter("@Numero_Dependientes", SqlDbType.Int, 4);
            ParameterNumero_Dependientes.Value = myClientesDetails.Numero_Dependientes;
            myCommand.Parameters.Add(ParameterNumero_Dependientes);

          
            try
            {
                //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd

                SQLExecuteNonQuery(myCommand);

            }
            catch (Exception ex)
            {
                throw ex;
            }




        }

        public System.Data.DataTable GetClientes(string estatus)
        {

            SqlCommand myCommand = new SqlCommand("up_GetCliente");

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ParameterEstatus = new SqlParameter("@Estatus", SqlDbType.VarChar, 10);
            ParameterEstatus.Value = estatus;
            myCommand.Parameters.Add(ParameterEstatus);

            try
            {
                return GetDataSetSP(myCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public System.Data.DataTable GetClientesByiDentificacion(ClientesDetails MyClientesDetails)
        {

            SqlCommand myCommand = new SqlCommand("up_getClientebyIdentificacion");

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ParameterIdentificacion = new SqlParameter("@Identificacion", SqlDbType.VarChar, 15);
            ParameterIdentificacion.Value = MyClientesDetails.identificacion;
            myCommand.Parameters.Add(ParameterIdentificacion);
            try
            {
                return GetDataSetSP(myCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public System.Data.DataTable BuscarClientePorIdentificacion(string identificacion)
        {

            SqlCommand myCommand = new SqlCommand("up_getClientebyIdentificacion");

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ParameterIdentificacion = new SqlParameter("@Identificacion", SqlDbType.VarChar, 15);
            ParameterIdentificacion.Value = identificacion;
            myCommand.Parameters.Add(ParameterIdentificacion);
            try
            {
                return GetDataSetSP(myCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public System.Data.DataTable BuscarDatosLaborables_Identificacion(string identificacion)
        {

            SqlCommand myCommand = new SqlCommand("up_getDatosLaborablesByIdentificacion");

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ParameterIdentificacion = new SqlParameter("@Identificacion", SqlDbType.VarChar, 15);
            ParameterIdentificacion.Value = identificacion;
            myCommand.Parameters.Add(ParameterIdentificacion);
            try
            {
                return GetDataSetSP(myCommand).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertDatosLaborables(DatosLaborablesDetails myDatosLaborablesDetails)
        {

            SqlCommand myCommand = new SqlCommand("up_Insert_Datos_Laborables");

            myCommand.CommandType = CommandType.StoredProcedure;



            SqlParameter Paramerteridentificacion = new SqlParameter("@Identificacion", SqlDbType.VarChar, 15);
            Paramerteridentificacion.Value = myDatosLaborablesDetails.identificacion;
            myCommand.Parameters.Add(Paramerteridentificacion);

            SqlParameter Parameterempresa = new SqlParameter("@Empresa", SqlDbType.VarChar, 50);
            Parameterempresa.Value = myDatosLaborablesDetails.empresa;
            myCommand.Parameters.Add(Parameterempresa);

            SqlParameter Parameterdireccion = new SqlParameter("@Direccion", SqlDbType.VarChar, 100);
            Parameterdireccion.Value = myDatosLaborablesDetails.direccion;
            myCommand.Parameters.Add(Parameterdireccion);

            SqlParameter Parametertipo_empresa = new SqlParameter("@TIPO_EMPRESA", SqlDbType.VarChar, 8);
            Parametertipo_empresa.Value = myDatosLaborablesDetails.tipo_empresa;
            myCommand.Parameters.Add(Parametertipo_empresa);


            SqlParameter Parameterpuesto = new SqlParameter("@PUESTO", SqlDbType.VarChar, 20);
            Parameterpuesto.Value = myDatosLaborablesDetails.puesto;
            myCommand.Parameters.Add(Parameterpuesto);

            SqlParameter Parameteringresos = new SqlParameter("@INGRESOS", SqlDbType.Decimal, 18);
            Parameteringresos.Value = myDatosLaborablesDetails.ingresos;
            myCommand.Parameters.Add(Parameteringresos);

            SqlParameter Parameterotros_ingresos = new SqlParameter("@OTROS_INGRESOS", SqlDbType.Decimal, 18);
            Parameterotros_ingresos.Value = myDatosLaborablesDetails.otros_ingresos;
            myCommand.Parameters.Add(Parameterotros_ingresos);

            SqlParameter Parametertiempo_empresa = new SqlParameter("@TIEMPO_EMPRESA", SqlDbType.VarChar, 10    );
            Parametertiempo_empresa.Value = myDatosLaborablesDetails.tiempo_empresa;
            myCommand.Parameters.Add(Parametertiempo_empresa);
            try
            {

                SQLExecuteNonQuery(myCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateDatosLaborables(DatosLaborablesDetails myDatosLaborablesDetails)
        {
            SqlCommand myCommand = new SqlCommand("up_Update_DatosLaborables");

            myCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter Paramerteridentificacion = new SqlParameter("@Identificacion", SqlDbType.VarChar, 15);
            Paramerteridentificacion.Value = myDatosLaborablesDetails.identificacion;
            myCommand.Parameters.Add(Paramerteridentificacion);

            SqlParameter Parameterempresa = new SqlParameter("@Empresa", SqlDbType.VarChar, 50);
            Parameterempresa.Value = myDatosLaborablesDetails.empresa;
            myCommand.Parameters.Add(Parameterempresa);

            SqlParameter Parameterdireccion = new SqlParameter("@Direccion", SqlDbType.VarChar, 100);
            Parameterdireccion.Value = myDatosLaborablesDetails.direccion;
            myCommand.Parameters.Add(Parameterdireccion);

            SqlParameter Parametertipo_empresa = new SqlParameter("@TIPO_EMPRESA", SqlDbType.VarChar, 8);
            Parametertipo_empresa.Value = myDatosLaborablesDetails.tipo_empresa;
            myCommand.Parameters.Add(Parametertipo_empresa);


            SqlParameter Parameterpuesto = new SqlParameter("@PUESTO", SqlDbType.VarChar, 20);
            Parameterpuesto.Value = myDatosLaborablesDetails.puesto;
            myCommand.Parameters.Add(Parameterpuesto);

            SqlParameter Parameteringresos = new SqlParameter("@INGRESOS", SqlDbType.Decimal, 18);
            Parameteringresos.Value = myDatosLaborablesDetails.ingresos;
            myCommand.Parameters.Add(Parameteringresos);

            SqlParameter Parameterotros_ingresos = new SqlParameter("@OTROS_INGRESOS", SqlDbType.Decimal, 18);
            Parameterotros_ingresos.Value = myDatosLaborablesDetails.otros_ingresos;
            myCommand.Parameters.Add(Parameterotros_ingresos);

            SqlParameter Parametertiempo_empresa = new SqlParameter("@TIEMPO_EMPRESA", SqlDbType.VarChar, 10);
            Parametertiempo_empresa.Value = myDatosLaborablesDetails.tiempo_empresa;
            myCommand.Parameters.Add(Parametertiempo_empresa);

            try
            {
                //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd

                SQLExecuteNonQuery(myCommand);

            }
            catch (Exception ex)
            {
                throw ex;
            }




        }
        //Busca cliente por identificacion y devuelve un cliente details
        public ClientesDetails BuscarClientePorIdentificacion_(string identificacion)
        {
            ClientesDetails myClientesDetails = null ;
            SqlCommand myCommand = new SqlCommand("up_getClientebyIdentificacion");

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ParameterIdentificacion = new SqlParameter("@Identificacion", SqlDbType.VarChar, 15);
            ParameterIdentificacion.Value = identificacion;
            myCommand.Parameters.Add(ParameterIdentificacion);

            DataTable dtable = new DataTable();
            DataRow dr;
            dtable = GetDataSetSP(myCommand).Tables[0];

            if (dtable.Rows.Count > 0)
            {
                myClientesDetails = new ClientesDetails();
                dr = dtable.Rows[0];
                myClientesDetails.Nombre = (string)dr["Nombre"];

                myClientesDetails.Apellido = (string)dr["Apellido"];

                myClientesDetails.identificacion = (string)dr["identificacion"];

                myClientesDetails.Direccion = (string)dr["direccion"];
                myClientesDetails.Telefono = (string)dr["telefono"];
                myClientesDetails.Celular = (string)dr["celular"];
                myClientesDetails.Correo = (string)dr["correo"];
                myClientesDetails.Estado_Civil = (string)dr["Estado_Civil"];
                myClientesDetails.Tipo_Vivienda = (string)dr["Tipo_Vivienda"];

                myClientesDetails.Numero_Dependientes = (string)dr["Numero_Dependientes"];
            }
            
                return myClientesDetails;
            
        }
        //Busca datos laborales por identificacion y devuelve un datos laborales details
        public DatosLaborablesDetails BuscarDatosLaborables_Identificacion_(string identificacion)
        {
            DatosLaborablesDetails myDatosLaborablesDetails = new DatosLaborablesDetails();
            SqlCommand myCommand = new SqlCommand("up_getDatosLaborablesByIdentificacion");

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter ParameterIdentificacion = new SqlParameter("@Identificacion", SqlDbType.VarChar, 15);
            ParameterIdentificacion.Value = identificacion;
            myCommand.Parameters.Add(ParameterIdentificacion);

            DataTable dtable = new DataTable();
            DataRow dr;
            dtable = GetDataSetSP(myCommand).Tables[0];

            dr = dtable.Rows[0];

            myDatosLaborablesDetails.empresa = (string)dr["Empresa"];
            myDatosLaborablesDetails.direccion = (string)dr["DIRECCION"];

            myDatosLaborablesDetails.tipo_empresa = (string)dr["tipo_empresa"];

            myDatosLaborablesDetails.puesto = (string)dr["Puesto"];
            Double Ingresos = (Double)dr["ingresos"];
            myDatosLaborablesDetails.ingresos = Ingresos;
            Double Otros_Ingresos = (Double)dr["Otros_ingresos"];
            myDatosLaborablesDetails.otros_ingresos = Otros_Ingresos;
            myDatosLaborablesDetails.tiempo_empresa = (string)dr["tiempo_empresa"];   



            try
            {
                return myDatosLaborablesDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object Estatus { get; set; }
    }

}