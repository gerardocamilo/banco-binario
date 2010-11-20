using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Plataforma.CapaDeNegocio.Productos;
using Plataforma.CapaDeNegocio.Solicitudes;

//Package that contains Debug class.
using System.Diagnostics;

namespace Plataforma.CapaDeDatos
{

    public class PlataformaDAO : SqlHelper
    {


        public PlataformaDAO()
            : base("BANCO_BINARIO", "GERARDOCAMILO", "plataforma", "plataforma")
        {
            //protected SqlHelper(string DataBaseName, string DataBaseServer, string DataBaseUser, string DataBasePassword)
        }

        public bool pCrearCuenta(Cuenta cuenta)
        {

            SqlCommand sComando = new SqlCommand("UP_PLATAFORMA_CREAR_CUENTA");
            sComando.CommandType = CommandType.StoredProcedure;

            SqlParameter sParametroNumeroCuenta = new SqlParameter("@NUMERO_CUENTA", SqlDbType.VarChar, 50);
            sParametroNumeroCuenta.Value = cuenta.NumeroCuenta;
            sComando.Parameters.Add(sParametroNumeroCuenta);

            SqlParameter sParametroBalance = new SqlParameter("@BALANCE", SqlDbType.Float);
            sParametroBalance.Value = cuenta.Balance;
            sComando.Parameters.Add(sParametroBalance);

            SqlParameter sParametroEstado = new SqlParameter("@ESTADO", SqlDbType.VarChar, 50);
            sParametroEstado.Value = cuenta.Estado;
            sComando.Parameters.Add(sParametroEstado);

            SqlParameter sParametroTipoProducto = new SqlParameter("@TIPO_PRODUCTO", SqlDbType.VarChar, 50);
            sParametroTipoProducto.Value = cuenta.TipoProducto;
            sComando.Parameters.Add(sParametroTipoProducto);

            return pEjecutarNoConsulta(sComando);

        }

        public bool pCrearSolicitud(Solicitud solicitud)
        {
            SolicitudCuenta solicitudCuenta = null;
            SolicitudTarjeta solicitudTarjeta = null;
            SolicitudPrestamo solicitudPrestamo = null;
            bool resultado = false;

            if (solicitud == null)
            {
                return resultado;
            }

            if (solicitud is SolicitudCuenta)
            {
                solicitudCuenta = (SolicitudCuenta)solicitud;
                resultado = pCrearSolicitudCuenta(solicitudCuenta);
            }
            else if (solicitud is SolicitudTarjeta)
            {
                solicitudTarjeta = (SolicitudTarjeta)solicitud;
                resultado = pCrearSolicitudTarjeta(solicitudTarjeta);
            }
            else if (solicitud is SolicitudPrestamo)
            {
                solicitudPrestamo = (SolicitudPrestamo)solicitud;
                resultado = pCrearSolicitudPrestamo(solicitudPrestamo);
            }

            return resultado;
        }

        // TODO: MATCHEAR CON EL STORE PROCEDURE
        // TOMAR EN CUENTA REL_GARANTE_PRESTAMO
        private bool pCrearSolicitudPrestamo(SolicitudPrestamo solicitudPrestamo)
        {
            Producto prod = null;
            Prestamo prestamoAsociado = null;

            if (solicitudPrestamo == null)
            {
                return false;
            }

            prod = solicitudPrestamo.ProductoAsociado;

            if ((prod != null) && (prod is Prestamo))
            {
                prestamoAsociado = (Prestamo)prod;
            }
            else
            {
                return false;
            }

            SqlCommand sComando = new SqlCommand("UP_PLATAFORMA_CREAR_SOLICITUD_PRESTAMO");
            sComando.CommandType = CommandType.StoredProcedure;

            SqlParameter sParametroNumeroSolicitud = new SqlParameter("@NUMERO_SOLICITUD", SqlDbType.VarChar, 50);
            sParametroNumeroSolicitud.Value = solicitudPrestamo.NumeroSolicitud;
            sComando.Parameters.Add(sParametroNumeroSolicitud);

            SqlParameter sParametroTipoProducto = new SqlParameter("@TIPO_PRODUCTO", SqlDbType.VarChar, 50);
            sParametroTipoProducto.Value = prestamoAsociado.TipoProducto;
            sComando.Parameters.Add(sParametroTipoProducto);

            SqlParameter sParametroEstado = new SqlParameter("@ESTADO", SqlDbType.VarChar, 50);
            sParametroEstado.Value = prestamoAsociado.Estado;
            sComando.Parameters.Add(sParametroEstado);


            SqlParameter sParametroPlazoPago = new SqlParameter("@PLAZO_PAGO", SqlDbType.Int);
            sParametroPlazoPago.Value = prestamoAsociado.CantidadCuotas;
            sComando.Parameters.Add(sParametroPlazoPago);
            //continue here
            SqlParameter sParametroMontoPrestamo = new SqlParameter("@MONTO_PRESTAMO", SqlDbType.Float);
            sParametroMontoPrestamo.Value = prestamoAsociado;
            sComando.Parameters.Add(sParametroMontoPrestamo);

            SqlParameter sNumeroSolicitudAsociado = new SqlParameter("@NUMERO_SOLICITUD_ASOCIADO", SqlDbType.VarChar, 50);
            sNumeroSolicitudAsociado.Value = solicitudPrestamo.NumeroSolicitudAsociado;
            sComando.Parameters.Add(sNumeroSolicitudAsociado);

            return pEjecutarNoConsulta(sComando);
        }

        private bool pCrearSolicitudTarjeta(SolicitudTarjeta solicitudTarjeta)
        {
            Producto prod = null;
            Tarjeta tarjetaAsociada = null;

            if (solicitudTarjeta == null)
            {
                return false;
            }

            prod = solicitudTarjeta.ProductoAsociado;

            if ((prod != null) && (prod is Tarjeta))
            {
                tarjetaAsociada = (Tarjeta)prod;
            }
            else
            {
                return false;
            }

            SqlCommand sComando = new SqlCommand("UP_PLATAFORMA_CREAR_SOLICITUD_TARJETA");
            sComando.CommandType = CommandType.StoredProcedure;

            SqlParameter sParametroNumeroSolicitud = new SqlParameter("@NUMERO_SOLICITUD", SqlDbType.VarChar, 50);
            sParametroNumeroSolicitud.Value = solicitudTarjeta.NumeroSolicitud;
            sComando.Parameters.Add(sParametroNumeroSolicitud);

            SqlParameter sParametroTipoTarjeta = new SqlParameter("@TIPO_TARJETA", SqlDbType.VarChar, 50);
            sParametroTipoTarjeta.Value = tarjetaAsociada.TipoProducto;
            sComando.Parameters.Add(sParametroTipoTarjeta);

            SqlParameter sParametrorRecibirTarjeta = new SqlParameter("@RECIBIR_TARJETA", SqlDbType.VarChar, 50);
            sParametrorRecibirTarjeta.Value = tarjetaAsociada.TipoProducto;
            sComando.Parameters.Add(sParametrorRecibirTarjeta);

            SqlParameter sParametrorEnvioTarjeta = new SqlParameter("@ENVIO_TARJETA", SqlDbType.VarChar, 50);
            sParametrorEnvioTarjeta.Value = tarjetaAsociada.TipoProducto;
            sComando.Parameters.Add(sParametrorEnvioTarjeta);

            SqlParameter sParametroTipoProducto = new SqlParameter("@TIPO_PRODUCTO", SqlDbType.VarChar, 50);
            sParametroTipoProducto.Value = tarjetaAsociada.TipoProducto;
            sComando.Parameters.Add(sParametroTipoProducto);

            SqlParameter sParametroEstado = new SqlParameter("@ESTADO", SqlDbType.VarChar, 50);
            sParametroEstado.Value = tarjetaAsociada.Estado;
            sComando.Parameters.Add(sParametroEstado);

            SqlParameter sNumeroSolicitudAsociado = new SqlParameter("@NUMERO_SOLICITUD_ASOCIADO", SqlDbType.VarChar, 50);
            sNumeroSolicitudAsociado.Value = solicitudTarjeta.NumeroSolicitudAsociado;
            sComando.Parameters.Add(sNumeroSolicitudAsociado);

            return pEjecutarNoConsulta(sComando);
        }

        private bool pCrearSolicitudCuenta(SolicitudCuenta solicitudCuenta)
        {
            Producto prod = null;
            Cuenta cuentaAsociada = null;

            if (solicitudCuenta == null)
            {
                return false;
            }

            prod = solicitudCuenta.ProductoAsociado;

            if ((prod != null) && (prod is Cuenta))
            {
                cuentaAsociada = (Cuenta)prod;
            }
            else
            {
                return false;
            }

            SqlCommand sComando = new SqlCommand("UP_PLATAFORMA_CREAR_SOLICITUD_CUENTA");
            sComando.CommandType = CommandType.StoredProcedure;

            SqlParameter sParametroNumeroSolicitud = new SqlParameter("@NUMERO_SOLICITUD", SqlDbType.VarChar, 50);
            sParametroNumeroSolicitud.Value = solicitudCuenta.NumeroSolicitud;
            sComando.Parameters.Add(sParametroNumeroSolicitud);

            SqlParameter sParametroBalanceInicial = new SqlParameter("@BALANCE_INICIAL", SqlDbType.Float, 50);
            sParametroBalanceInicial.Value = cuentaAsociada.Balance;
            sComando.Parameters.Add(sParametroBalanceInicial);

            SqlParameter sParametroTipoProducto = new SqlParameter("@TIPO_PRODUCTO", SqlDbType.VarChar, 50);
            sParametroTipoProducto.Value = cuentaAsociada.TipoProducto;
            sComando.Parameters.Add(sParametroTipoProducto);

            SqlParameter sParametroEstado = new SqlParameter("@ESTADO", SqlDbType.VarChar, 50);
            sParametroEstado.Value = cuentaAsociada.Estado;
            sComando.Parameters.Add(sParametroEstado);

            SqlParameter sNumeroSolicitudAsociado = new SqlParameter("@NUMERO_SOLICITUD_ASOCIADO", SqlDbType.VarChar, 50);
            sNumeroSolicitudAsociado.Value = solicitudCuenta.NumeroSolicitudAsociado;
            sComando.Parameters.Add(sNumeroSolicitudAsociado);

            return pEjecutarNoConsulta(sComando);
        }


        public List<Producto> pObtenerProductosPorIdentificacionCliente(String identificacionCliente)
        {
            SqlCommand sComando = new SqlCommand("UP_PLATAFORMA_OBTENER_PRODUCTOS_POR_CLIENTE");
            sComando.CommandType = CommandType.StoredProcedure;

            SqlParameter sIdentificacionCliente = new SqlParameter("@IDENTIFICACION_CLIENTE", SqlDbType.VarChar, 50);
            sIdentificacionCliente.Value = identificacionCliente;
            sComando.Parameters.Add(sIdentificacionCliente);

            Console.Write("ComandoSQL!!! : " + sComando.ToString());

            DataSet setDeProductos = pEjecutarConsulta(sComando);
            List<Producto> productos = pConstruirListaDeProductos(setDeProductos);

            return productos;
        }

        private List<Producto> pConstruirListaDeProductos(DataSet setDeProductos)
        {
            List<Producto> productos = new List<Producto>();
            String codigoProducto = null;

            if ((setDeProductos.Tables.Count > 0))
            {
                DataTable tabla = setDeProductos.Tables[0];

                foreach (DataRow row in tabla.Rows)
                {
                    codigoProducto = row["CODIGO_PRODUCTO"].ToString();
                    productos.Add(pObtenerProductoPorCodigo(codigoProducto));
                }
            }
            else {
                return null;
            }
            return productos;
        }

        public Producto pObtenerProductoPorCodigo(String codigoProducto) {
            //Producto producto = null;
            String tipoProducto = null;
            const String CUENTA_CORRIENTE = "CUENTA_CORRIENTE";
            const String CUENTA_AHORRO = "CUENTA_AHORRO";
            const String TARJETA_DEBITO = "TARJETA_DEBITO";
            const String TARJETA_CREDITO = "TARJETA_CREDITO";
            const String PRESTAMO = "PRESTAMO";

            SqlCommand sComando = new SqlCommand("UP_PLATAFORMA_OBTENER_PRODUCTO_POR_CODIGO");
            sComando.CommandType = CommandType.StoredProcedure;
            SqlParameter sCodigoProducto = new SqlParameter("@CODIGO_PRODUCTO", SqlDbType.VarChar, 50);
            sCodigoProducto.Value = codigoProducto;
            sComando.Parameters.Add(sCodigoProducto);
            DataSet setDeProductos = pEjecutarConsulta(sComando);
            
            if ((setDeProductos.Tables.Count>0) && (setDeProductos.Tables[0].Rows.Count > 0))
            {
                DataTable tabla = setDeProductos.Tables[0];
                DataRow fila = tabla.Rows[0];
                tipoProducto = fila["TIPO_PRODUCTO"].ToString();

                //Continuar creando condiciones para los demas posibles valores de TIPO_PRODUCTO
                if( (tipoProducto.Equals(CUENTA_CORRIENTE)) || (tipoProducto.Equals(CUENTA_AHORRO)) ){
                    Cuenta cuenta = new Cuenta();
                    cuenta.NumeroCuenta = codigoProducto;
                    cuenta.Balance = float.Parse(fila["BALANCE"].ToString());
                    cuenta.Estado = fila["ESTADO"].ToString();
                    cuenta.TipoProducto = tipoProducto;
                    return cuenta;
                }
                else if (tipoProducto.Equals(TARJETA_CREDITO) || tipoProducto.Equals(TARJETA_DEBITO))
                {
                    Tarjeta tarjeta = new Tarjeta();
                    tarjeta.CuentaAsociada = fila["CUENTA_ASOCIADA"].ToString();
                    tarjeta.Estado = fila["ESTADO"].ToString();
                    tarjeta.LimiteCredito = float.Parse(fila["LIMITE_CREDITO"].ToString());
                    tarjeta.NumeroTarjeta = fila["NUMERO_TARJETA"].ToString();
                    tarjeta.PIN = fila["PIN"].ToString();
                    tarjeta.TipoProducto = tipoProducto;
                    tarjeta.TipoTrarjeta = fila["TIPO_TARJETA"].ToString();
                    tarjeta.ValidarDesde = DateTime.Parse(fila["VALIDAR_DESDE"].ToString());
                    tarjeta.ValidarHasta = DateTime.Parse(fila["VALIDAR_HASTA"].ToString());
                    return tarjeta;
                }
                else if (tipoProducto.Equals(PRESTAMO)){
                    Prestamo prestamo = new Prestamo();
                    prestamo.BalancePrestamo = float.Parse(fila["BALANCE_PRESTAMO"].ToString());
                    prestamo.CantidadCuotas = int.Parse(fila["CANTIDAD_CUOTAS"].ToString());
                    prestamo.DesembolsoInicial = float.Parse(fila["DESEMBOLSO_INICIAL"].ToString());
                    prestamo.Estado = fila["ESTADO"].ToString();
                    prestamo.MontoCuota = float.Parse(fila["MONTO_CUOTA"].ToString());
                    prestamo.NumeroPrestamo = fila["NUMERO_PRESTAMO"].ToString();
                    prestamo.TasaInteres = float.Parse(fila["TASA_INTERES"].ToString());
                    prestamo.TipoProducto = tipoProducto;
                    return prestamo;
                }
                //obtener tipo producto del primer row y en base al tipo de producto asignar a una referencia del Producto 
                //la instancia hija de producto que corresponda asi el modulo externo puede castear esa instancia y obtener los valores deseados.
            }

            return null;
        }


        //DEPRECATED
        //private bool pCrearSolicitud(String numeroSolicitud, Cuenta cuenta) {

        //    SqlCommand sComando = new SqlCommand("UP_PLATAFORMA_CREAR_SOLICITUD_CUENTA");
        //    sComando.CommandType = CommandType.StoredProcedure;

        //    SqlParameter sParametroNumeroSolicitud = new SqlParameter("@NUMERO_SOLICITUD", SqlDbType.VarChar, 50);
        //    sParametroNumeroSolicitud.Value = numeroSolicitud;
        //    sComando.Parameters.Add(sParametroNumeroSolicitud);

        //    SqlParameter sParametroTipoProducto = new SqlParameter("@TIPO_PRODUCTO", SqlDbType.VarChar, 50);
        //    sParametroTipoProducto.Value = cuenta.TipoProducto;
        //    sComando.Parameters.Add(sParametroTipoProducto);

        //    SqlParameter sParametroEstado = new SqlParameter("@ESTADO", SqlDbType.VarChar, 50);
        //    sParametroEstado.Value = cuenta.Estado;
        //    sComando.Parameters.Add(sParametroEstado);

        //    return pEjecutarComando(sComando);
        //}

        protected bool pEjecutarNoConsulta(SqlCommand comando)
        {
            bool resultado = false;
            try
            {
                resultado = SQLExecuteNonQuery(comando);
            }
            catch (Exception ex)
            {
                //TODO: Manejar exception               
            }
            return resultado;
        }

        protected DataSet pEjecutarConsulta(SqlCommand comando)
        {

            DataSet resultado = GetDataSetSP(comando);

            return resultado;
        }

    }
}