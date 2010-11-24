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
using System.Text;
using appBancoBinario.CapaDeDatos;

namespace Configuracion_y_Parametros
{
    public class codigoTransaccion : SqlHelper 
    {

        public codigoTransaccion()
            : base("BANCO_BINARIO", "DARLINPC-PC", "SA", "")
        {
        }

        /// <summary>
        /// En estemetodo busca un codigo de transaccion para asignarselo a cada transaccion realizada por 
        /// cualquiera de los modulos
        /// 
        /// Los datos dentro de este comentario debajo de esta linea son temporales:
        /// Maestro de Transacciones:
        ///tipo	Codigo		Descripcion
        ///1------	AVTRC------	Avance Efectivo Tarjeta Credito
        ///2       	APCCT 		Apertura Cuenta Corriente
        ///3	    APCAH 		Apertura Cuenta Ahorro
        ///4        APTRD 		Apertura Tarjeta Debito
        ///5    	APTRC 		Apertura Tarjeta Credito
        ///6    	APPRT 		Apertura Prestamo
        ///7    	CNCCT 		Cancelacion Cuenta Corriente
        ///8       	CNCAH 		Cancelacion Cuenta Ahorro
        ///9    	CNTRC 		Cancelacion Tarjeta Credito
        ///10   	CNTRD 		Cancelacion Tarjeta Debito
        ///11   	CNPRT 		Cancelacion Prestamo
        ///12   	DPTRD 		Deposito Tarjeta Debito
        ///13   	DPCCT 		Deposito Cuenta Corriente
        ///14      	DPCAH 		Deposito Cuenta Ahorro
        ///15   	DPTRS 		Deposito Transaferencia
        ///16   	PGTRC 		Pago Tarjeta Credito
        ///17   	PGPRT 		pago Prestamo
        ///18   	RTTRD 		Retiro Tarjeta Debito
        ///19   	RTCAH 		Retiro Cuenta Ahorro
        ///20   	RTCCT 		Retiro Cuenta Corriente
        ///21   	RTTRS 		Retiro Trannsferencia
        ///</summary>      
        public string buscarCodigoTransaccion(int tipo_transaccion)
        {
            //string codigo_transaccion = "PGTRC";variable temporal
            /*se ejecutara un stored procedure que 
             * llenara la variable para devolver el
             * codigo de transaccion 
             *======================================================
             *esta parte del codigo fue suministrada por la clase de 
             *conexion a la base de datos*/
            SqlCommand miCommando = new SqlCommand("up_buscar_codigo_transaccion");/*se hace una instancia de SqlCommand de la clase Sqlhelper
                                                                                    * y como parametros utilizamos un stored procedure de la 
                                                                                    * base de datos.*/

           
            miCommando.CommandType = CommandType.StoredProcedure;

            SqlParameter ParameterDescripcion_tipo_transaccion = new SqlParameter("@TIPO_TRANNSACCION", SqlDbType.Int);
            ParameterDescripcion_tipo_transaccion.Value = tipo_transaccion;
            ParameterDescripcion_tipo_transaccion.Direction = ParameterDirection.Input;
            miCommando.Parameters.Add(ParameterDescripcion_tipo_transaccion);
            try
            {
                DataSet Ds = this.GetDataSetSP(miCommando);
                //DataTable Dt = Ds.Tables[0].Rows[0][0];
                return (string)Ds.Tables[0].Rows[0][0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

           
        }
    }
}
