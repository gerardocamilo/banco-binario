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
//using conexion.conexion;
using System.Text;

namespace Configuracion_y_Parametros
{
    public class detallesTasaInteres
    {
        public string  tipo_tasa;
        public string descripcion = null;
        public string tipo_producto;
        public float tasa_interes;

    }

        public class tasaInteres : SqlHelper
        {
            /// <summary>
            ///permite la modificacion de la tasa de interes de los diferentes productos 
            ///manejados en el Banco Binario.
            /// </summary> 
            public void modificarTasa(detallesTasaInteres misDetalles)
            {

                /*Luego que las variables adquirieren un valor 
                 *para la nueva tasa la misma sera guardada 
                 *en un campo en la base de datos mediante el 
                 *uso de un Stored Procedure*/

                SqlCommand miCommando = new SqlCommand("up_actulizar_tasa_interes");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.

                miCommando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParameterTipo_Interes = new SqlParameter("@tipo_interes", SqlDbType.Char, 3);
                ParameterTipo_Interes.Value = misDetalles.tipo_tasa;
                miCommando.Parameters.Add(ParameterTipo_Interes);

                SqlParameter ParameterTASA_INTERES = new SqlParameter("@TASA_INTERES", SqlDbType.Float);
                ParameterTASA_INTERES.Value = misDetalles.tasa_interes;
                miCommando.Parameters.Add(ParameterTASA_INTERES);

                try
                {
                    //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd

                    SQLExecuteNonQuery(miCommando);

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            /// <summary>
            ///permite la consulta de la tasa de interes de los diferentes productos 
            ///manejados en el Banco Binario.
            /// </summary> 
            public double ConsultarTasa(string tipo_producto)
            {
                //monto_Tasa = 15;// es solo un valor de ejemplo
                /*utilizando la conexion a la base de datos
                 *se ejecutara un stored procedure para consultar 
                 *la tabla de tasas de interes en la base de datos
                 *y almacenar el interes en la variable monto tasa 
                 *para retornarla*/


                SqlCommand miCommando = new SqlCommand("up_buscar_tasa_por_tipo_producto");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.

                // Mark the Command as a SPROC
                miCommando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParameterDescripcion_tipo_producto = new SqlParameter("@descripcion_tipo_producto", SqlDbType.VarChar, 50);
                ParameterDescripcion_tipo_producto.Value = tipo_producto;
                ParameterDescripcion_tipo_producto.Direction = ParameterDirection.Input;
                miCommando.Parameters.Add(ParameterDescripcion_tipo_producto);
                try
                {
                    DataSet Ds = this.GetDataSetSP(miCommando);
                   //DataTable Dt = Ds.Tables[0].Rows[0][0];
                   return (double) Ds.Tables[0].Rows[0][0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }

              
            }
            /// <summary>
            ///permite la creación de tasas de interes para los diferentes productos 
            ///manejados en el Banco Binario.
            /// </summary> 
            public void crearTasa(detallesTasaInteres misDetalles)
            {
                /*monto_Tasa = tasa_interes;
                tipo_Tasa = tipo_tasa;
                Descripcion = descripcion;*/

                /*el resto del proceso se realizara meiante un stored procedure en la base de datos */

                SqlCommand miCommando = new SqlCommand("up_insertar_nueva_tasa_interes");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.

                miCommando.CommandType = CommandType.StoredProcedure;

                SqlParameter ParametroTipoTasa = new SqlParameter("@tipo_interes", SqlDbType.Char, 3);
                ParametroTipoTasa.Value = misDetalles.tipo_tasa;
                miCommando.Parameters.Add(ParametroTipoTasa);

                SqlParameter ParametroDescripcion = new SqlParameter("@DESCRIPCION", SqlDbType.VarChar, 50);
                ParametroDescripcion.Value = misDetalles.descripcion;
                miCommando.Parameters.Add(ParametroDescripcion);

                SqlParameter ParametroDescripcionTipoProducto = new SqlParameter("@descripcion_tipo_producto", SqlDbType.VarChar, 50);
                ParametroDescripcionTipoProducto.Value = misDetalles.tipo_producto;
                miCommando.Parameters.Add(ParametroDescripcionTipoProducto);

                SqlParameter ParametroTasaInteres = new SqlParameter("@TASA_INTERES", SqlDbType.Float );
                ParametroTasaInteres.Value = misDetalles.tasa_interes;
                miCommando.Parameters.Add(ParametroTasaInteres);

                try
                {
                    //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd

                    SQLExecuteNonQuery(miCommando);

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
