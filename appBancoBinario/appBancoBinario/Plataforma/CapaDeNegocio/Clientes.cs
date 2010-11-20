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


namespace Plataforma.CapaDeNegocio
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

        public System.Data.DataTable GetClientes()
        {

            SqlCommand myCommand = new SqlCommand("up_GetCliente");

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.StoredProcedure;
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

    }

}