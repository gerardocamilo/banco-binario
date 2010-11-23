using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using appBancoBinario.Plataforma.CapaDeNegocio.Productos;
using appBancoBinario.Plataforma.CapaDeNegocio.Solicitudes;
using appBancoBinario.Clientes.CapaDeNegocio;

using System.Diagnostics;

namespace appBancoBinario.Plataforma.CapaDeDatos
{

    public class PlataformaDAO : SqlHelper
    {


        public PlataformaDAO()
            : base("BANCO_BINARIO", "GERARDOCAMILO", "plataforma", "plataforma")
        {
        }

        public bool pCrearCuenta(Cuenta cuenta)
        {

            SqlCommand sComando = new SqlCommand("UP_PLATAFORMA_CREAR_CUENTA");
            //sComando.CommandType = CommandType.StoredProcedure;

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

            SqlParameter sParametroIdentificacionCliente = new SqlParameter("@IDENTIFICACION_CLIENTE", SqlDbType.VarChar, 50);
            sParametroIdentificacionCliente.Value = cuenta.ClienteProducto;
            sComando.Parameters.Add(sParametroIdentificacionCliente);

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
            
            SqlParameter sParametroMontoPrestamo = new SqlParameter("@MONTO_PRESTAMO", SqlDbType.Float);
            sParametroMontoPrestamo.Value = prestamoAsociado.DesembolsoInicial;
            sComando.Parameters.Add(sParametroMontoPrestamo);

            SqlParameter sNumeroSolicitudAsociado = new SqlParameter("@NUMERO_SOLICITUD_ASOCIADO", SqlDbType.VarChar, 50);
            sNumeroSolicitudAsociado.Value = solicitudPrestamo.NumeroSolicitudAsociado;
            sComando.Parameters.Add(sNumeroSolicitudAsociado);

            SqlParameter sParametroIdentificacionCliente = new SqlParameter("@IDENTIFICACION_CLIENTE", SqlDbType.VarChar, 50);
            sParametroIdentificacionCliente.Value = solicitudPrestamo.Cliente.identificacion;
            sComando.Parameters.Add(sParametroIdentificacionCliente);

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
            sParametroTipoTarjeta.Value = tarjetaAsociada.TipoTarjeta;
            sComando.Parameters.Add(sParametroTipoTarjeta);

            SqlParameter sParametrorRecibirTarjeta = new SqlParameter("@RECIBIR_TARJETA", SqlDbType.VarChar, 50);
            sParametrorRecibirTarjeta.Value = tarjetaAsociada.RecibirTarjeta;
            sComando.Parameters.Add(sParametrorRecibirTarjeta);

            SqlParameter sParametrorEnvioTarjeta = new SqlParameter("@ENVIO_TARJETA", SqlDbType.VarChar, 50);
            sParametrorEnvioTarjeta.Value = tarjetaAsociada.EnvioTarjeta;
            sComando.Parameters.Add(sParametrorEnvioTarjeta);

            SqlParameter sParametroTipoProducto = new SqlParameter("@TIPO_PRODUCTO", SqlDbType.VarChar, 50);
            sParametroTipoProducto.Value = tarjetaAsociada.TipoProducto;
            sComando.Parameters.Add(sParametroTipoProducto);

            SqlParameter sParametroEstado = new SqlParameter("@ESTADO", SqlDbType.VarChar, 50);
            sParametroEstado.Value = solicitudTarjeta.Estado;
            sComando.Parameters.Add(sParametroEstado);

            SqlParameter sNumeroSolicitudAsociado = new SqlParameter("@NUMERO_SOLICITUD_ASOCIADO", SqlDbType.VarChar, 50);
            sNumeroSolicitudAsociado.Value = solicitudTarjeta.NumeroSolicitudAsociado;
            sComando.Parameters.Add(sNumeroSolicitudAsociado);
            
            SqlParameter sParametroIdentificacionCliente = new SqlParameter("@IDENTIFICACION_CLIENTE", SqlDbType.VarChar, 50);
            sParametroIdentificacionCliente.Value = solicitudTarjeta.Cliente.identificacion;
            sComando.Parameters.Add(sParametroIdentificacionCliente);

            return pEjecutarNoConsulta(sComando);
        }

        private bool pCrearSolicitudCuenta(SolicitudCuenta solicitudCuenta)
        {
            Producto prod = null;
            Cuenta cuentaAsociada = null;

            if (solicitudCuenta == null)
            {
                Debug.WriteLine("SolicitudCuenta: [null] ");
                return false;
               
            }

            prod = solicitudCuenta.ProductoAsociado;

            if ((prod != null) && (prod is Cuenta))
            {
                cuentaAsociada = (Cuenta)prod;
            }
            else
            {
                Debug.WriteLine("Producto es o invalido: [null] ");
                return false;
            }

            SqlCommand sComando = new SqlCommand("UP_PLATAFORMA_CREAR_SOLICITUD_CUENTA");
            sComando.CommandType = CommandType.StoredProcedure;

            SqlParameter sParametroNumeroSolicitud = new SqlParameter("@NUMERO_SOLICITUD", SqlDbType.VarChar, 50);
            sParametroNumeroSolicitud.Value = solicitudCuenta.NumeroSolicitud;
            sComando.Parameters.Add(sParametroNumeroSolicitud);

            SqlParameter sParametroBalanceInicial = new SqlParameter("@BALANCE_INICIAL", SqlDbType.Float);
            sParametroBalanceInicial.Value = cuentaAsociada.Balance;
            sComando.Parameters.Add(sParametroBalanceInicial);

            SqlParameter sParametroTipoProducto = new SqlParameter("@TIPO_PRODUCTO", SqlDbType.VarChar, 50);
            sParametroTipoProducto.Value = cuentaAsociada.TipoProducto;
            sComando.Parameters.Add(sParametroTipoProducto);

            SqlParameter sParametroEstado = new SqlParameter("@ESTADO", SqlDbType.VarChar, 50);
            sParametroEstado.Value = solicitudCuenta.Estado;
            sComando.Parameters.Add(sParametroEstado);

            SqlParameter sNumeroSolicitudAsociado = new SqlParameter("@NUMERO_SOLICITUD_ASOCIADO", SqlDbType.VarChar, 50);
            sNumeroSolicitudAsociado.Value = solicitudCuenta.NumeroSolicitudAsociado;
            sComando.Parameters.Add(sNumeroSolicitudAsociado);

            SqlParameter sParametroIdentificacionCliente = new SqlParameter("@IDENTIFICACION_CLIENTE", SqlDbType.VarChar, 50);
            sParametroIdentificacionCliente.Value = solicitudCuenta.Cliente.identificacion;
            sComando.Parameters.Add(sParametroIdentificacionCliente);
            

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
                    tarjeta.TipoTarjeta = fila["TIPO_TARJETA"].ToString();
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

        public Solicitud pObtenerSolicitudPorNumero(String numeroSolicitud)
        {
            //Producto producto = null;
            String tipoSolicitud = null;
            const String CUENTA_CORRIENTE = "CUENTA_CORRIENTE";
            const String CUENTA_AHORRO = "CUENTA_AHORRO";
            const String TARJETA_DEBITO = "TARJETA_DEBITO";
            const String TARJETA_CREDITO = "TARJETA_CREDITO";
            const String PRESTAMO = "PRESTAMO";
            const String CUENTA_TARJETA = "CUENTA_TARJETA";
            Solicitud solicitud = null;
            SqlCommand sComando = new SqlCommand("UP_PLATAFORMA_OBTENER_SOLICITUD_POR_NUMERO");
            
            //sComando.CommandType = CommandType.StoredProcedure;
            SqlParameter sNumeroSolicitud = new SqlParameter("@NUMERO_SOLICITUD", SqlDbType.VarChar, 50);
            sNumeroSolicitud.Value = numeroSolicitud;
            sComando.Parameters.Add(sNumeroSolicitud);
            DataSet setDeSolicitudes = pEjecutarConsulta(sComando);

            if ((setDeSolicitudes.Tables.Count > 0) && (setDeSolicitudes.Tables[0].Rows.Count > 0))
            {
                DataTable tabla = setDeSolicitudes.Tables[0];
                DataRow fila = tabla.Rows[0];
                tipoSolicitud = fila["TIPO_PRODUCTO"].ToString();

                if ((tipoSolicitud.Equals(CUENTA_CORRIENTE)) || (tipoSolicitud.Equals(CUENTA_AHORRO)) || (tipoSolicitud.Equals(CUENTA_TARJETA)))
                {
                    SolicitudCuenta solicitudCuenta = new SolicitudCuenta();
                    solicitudCuenta.NumeroSolicitud = numeroSolicitud;
                    Cuenta cuenta = new Cuenta();
                    cuenta.TipoProducto = fila["TIPO_PRODUCTO"].ToString();
                    solicitudCuenta.ProductoAsociado = cuenta;
                    solicitudCuenta.Estado = fila["ESTADO"].ToString();
                    solicitud =  solicitudCuenta;
                }
                else if (tipoSolicitud.Equals(TARJETA_CREDITO) || tipoSolicitud.Equals(TARJETA_DEBITO))
                {
                    SolicitudTarjeta solicitudTarjeta = new SolicitudTarjeta();
                    solicitudTarjeta.NumeroSolicitud = numeroSolicitud;
                    Tarjeta tarjeta = new Tarjeta();
                    tarjeta.TipoProducto = fila["TIPO_PRODUCTO"].ToString();
                    solicitudTarjeta.ProductoAsociado = tarjeta;
                    
                    solicitudTarjeta.Estado = fila["ESTADO"].ToString();
                    solicitud = solicitudTarjeta;
                }
                else if (tipoSolicitud.Equals(PRESTAMO))
                {
                    SolicitudPrestamo solicitudPrestamo = new SolicitudPrestamo();
                    solicitudPrestamo.NumeroSolicitud = numeroSolicitud;
                    Prestamo prestamo = new Prestamo();
                    prestamo.TipoProducto = fila["TIPO_PRODUCTO"].ToString();
                    solicitudPrestamo.ProductoAsociado = prestamo;
                    solicitudPrestamo.Estado = fila["ESTADO"].ToString();
                    solicitud = solicitudPrestamo;
                }
                //obtener tipo producto del primer row y en base al tipo de producto asignar a una referencia del Producto 
                //la instancia hija de producto que corresponda asi el modulo externo puede castear esa instancia y obtener los valores deseados.
            }

            //Codigo para traer el cliente asociado a dicha solicitud.
            //1)Consultar relacion cliente_solicitud
            //2)Consultar API Clientes para traer los atributos del cliente y setearlos en la solicitud
            String identificacionCliente = pObtenerIdentificacionClientePorNumeroSolicitud(solicitud.NumeroSolicitud);
            appBancoBinario.Clientes.CapaDeNegocio.Clientes clienteAPI = new appBancoBinario.Clientes.CapaDeNegocio.Clientes();
            ClientesDetails clienteDetalle = clienteAPI.BuscarClientePorIdentificacion_(identificacionCliente);
            if (clienteDetalle != null)
            {
                solicitud.Cliente = clienteDetalle;
            }
            else
            {
                ClientesDetails emptyClient = new ClientesDetails();
                emptyClient.Apellido=""; 
                emptyClient.Celular="";
                emptyClient.Correo="";
                emptyClient.Direccion="";
                emptyClient.Estado_Civil="";
                emptyClient.Estatus="";
                emptyClient.Fecha_Modificacion = "";
                emptyClient.identificacion="0000000000";
                emptyClient.Nombre = "";
                emptyClient.Numero_Dependientes = "0";
                emptyClient.Telefono = "";
                emptyClient.Tipo_Vivienda="";

                solicitud.Cliente = emptyClient;
            }
            return solicitud;
        }

        private string pObtenerIdentificacionClientePorNumeroSolicitud(String numeroSolicitud)
        {
            String identificacionCliente = null;
            //Steps:
            //1)[DONE][TESTED!]Crear Store procedure para que actualice REL_CLIENTE_SOLICITUD
            //2)[DONE][TESTED!]Modificar UP de creacion de Solicitudes para que usen el UP del paso anterior #1.
            //3)[DONE][TESTED!]Modificar PlataformaDAO para que matchee con los UP del paso 2
            //3)[DONE]Crear Store Procedure que retorne IDENTIFICACION_CLIENTE en base al NUMERO_SOLICITUD
            //4) retornar identificacion
            SqlCommand sComando = new SqlCommand("UP_PLATAFORMA_OBTENER_CLIENTE_POR_SOLICITUD");

            SqlParameter sParametroNumeroSolicitud = new SqlParameter();
            sParametroNumeroSolicitud.Value = numeroSolicitud;
            sComando.Parameters.Add(sParametroNumeroSolicitud);
            DataSet resultado = pEjecutarConsulta(sComando);
            if ((resultado.Tables.Count > 0) && (resultado.Tables[0].Rows.Count > 0))
            {
                identificacionCliente = resultado.Tables[0].Rows[0]["IDENTIFICACION_CLIENTE"].ToString();
            }
            
            return identificacionCliente;
        }

        public bool actualizarPinTarjeta(String numeroTarjeta, String PIN) {
            bool resultado = false;
            SqlCommand sComando = new SqlCommand("UP_PLATAFORMA_ACTUALIZAR_PIN_TARJETA");
            sComando.CommandType = CommandType.StoredProcedure;

            SqlParameter sParametroNumeroTarjeta = new SqlParameter("@NUMERO_TARJETA",SqlDbType.VarChar, 50);
            sParametroNumeroTarjeta.Value = numeroTarjeta;
            sComando.Parameters.Add(sParametroNumeroTarjeta);

            SqlParameter sParametroPinTarjeta = new SqlParameter("@PIN", SqlDbType.VarChar, 50);
            sParametroPinTarjeta.Value = PIN;
            sComando.Parameters.Add(sParametroPinTarjeta);

            resultado = pEjecutarNoConsulta(sComando);

            return resultado;
        }

        protected bool pEjecutarNoConsulta(SqlCommand comando)
        {
            bool resultado = false;
            comando.CommandType = CommandType.StoredProcedure;
            try
            {
                resultado = SQLExecuteNonQuery(comando);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("pEjecutarNoConsulta: "+ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            return resultado;
        }

        protected DataSet pEjecutarConsulta(SqlCommand comando)
        {
            comando.CommandType = CommandType.StoredProcedure;
            DataSet resultado = GetDataSetSP(comando);

            return resultado;
        }


        public DataSet dObtenerSolicitudes()
        {
            DataSet resultado = null;
            SqlCommand sComando = new SqlCommand("UP_PLATAFORMA_OBTENER_SOLICITUDES");
            sComando.CommandType = CommandType.StoredProcedure;
            resultado = pEjecutarConsulta(sComando);
            return resultado;
        }
        public DataSet dObtenerProductos()
        {
            DataSet resultado = null;
            SqlCommand sComando = new SqlCommand("UP_PLATAFORMA_OBTENER_PRODUCTOS");
            sComando.CommandType = CommandType.StoredProcedure;
            resultado = pEjecutarConsulta(sComando);
            return resultado;
        }

        public bool pActualizarEstadoSolicitud(string numeroSolicitud, String estado)
        {
            SqlCommand sComando = new SqlCommand("UP_PLATAFORMA_ACTUALIZAR_ESTADO_SOLICITUD");

            SqlParameter sParametroNumeroSolicitud = new SqlParameter("@NUMERO_SOLICITUD", SqlDbType.VarChar, 50);
            sParametroNumeroSolicitud.Value = numeroSolicitud;
            sComando.Parameters.Add(sParametroNumeroSolicitud);

            SqlParameter sParametroEstadoSolicitud = new SqlParameter("@ESTADO", SqlDbType.VarChar, 50);
            sParametroEstadoSolicitud.Value = estado;
            sComando.Parameters.Add(sParametroEstadoSolicitud);

            return pEjecutarNoConsulta(sComando);
        }

        public bool pCrearProducto(Producto producto) {

            Cuenta cuenta = null;
            Tarjeta tarjeta = null;
            Prestamo prestamo = null;
            bool resultado = false;

            if (producto == null)
            {
                return resultado;
            }

            if (producto is Cuenta)
            {
                cuenta = (Cuenta)producto;
                resultado = pCrearCuenta(cuenta);
            }
            else if (producto is Tarjeta)
            {
                tarjeta = (Tarjeta)producto;
                resultado = pCrearTarjeta(tarjeta);
            }
            else if (producto is Prestamo)
            {
                prestamo = (Prestamo)producto;
                resultado = pCrearPrestamo(prestamo);
            }

            return resultado;
        }

        private bool pCrearPrestamo(Prestamo prestamo)
        {

            SqlCommand sComando = new SqlCommand("UP_PLATAFORMA_CREAR_PRESTAMO");
            
            SqlParameter sParametroNumeroSolicitud = new SqlParameter("@BALANCE_PRESTAMO", SqlDbType.Float);
            sParametroNumeroSolicitud.Value = prestamo.BalancePrestamo;
            sComando.Parameters.Add(sParametroNumeroSolicitud);

            SqlParameter sParametroCantidadCuotas = new SqlParameter("@CANTIDAD_CUOTAS", SqlDbType.Int);
            sParametroCantidadCuotas.Value = prestamo.CantidadCuotas;
            sComando.Parameters.Add(sParametroCantidadCuotas);

            SqlParameter sParametroDesembolsoInicial = new SqlParameter("@DESEMBOLSO_INICIAL", SqlDbType.Float);
            sParametroDesembolsoInicial.Value = prestamo.DesembolsoInicial;
            sComando.Parameters.Add(sParametroDesembolsoInicial);

            SqlParameter sParametroEstado = new SqlParameter("@ESTADO", SqlDbType.VarChar,50);
            sParametroEstado.Value = prestamo.Estado;
            sComando.Parameters.Add(sParametroEstado);

            SqlParameter sParametroFechaDesembolsoInicial = new SqlParameter("@FECHA_DESEMBOLSO_INICIAL", SqlDbType.DateTime);
            sParametroFechaDesembolsoInicial.Value = DateTime.Now;
            sComando.Parameters.Add(sParametroFechaDesembolsoInicial);

            SqlParameter sParametroFechaPago = new SqlParameter("@FECHA_PAGO", SqlDbType.Int);
            sParametroFechaPago.Value = DateTime.Now.Day;
            sComando.Parameters.Add(sParametroFechaPago);

            SqlParameter sParametroMontoCuota = new SqlParameter("@MONTO_CUOTA", SqlDbType.Float);
            sParametroMontoCuota.Value = prestamo.MontoCuota;
            sComando.Parameters.Add(sParametroMontoCuota);

            SqlParameter sParametroNumeroPrestamo = new SqlParameter("@NUMERO", SqlDbType.VarChar, 50);
            sParametroNumeroPrestamo.Value = prestamo.NumeroPrestamo;
            sComando.Parameters.Add(sParametroNumeroPrestamo);

            SqlParameter sParametroTasaInteres = new SqlParameter("@TASA_INTERES", SqlDbType.Float);
            sParametroTasaInteres.Value = prestamo.TasaInteres;
            sComando.Parameters.Add(sParametroTasaInteres);
            
            SqlParameter sParametroTipoProducto = new SqlParameter("@TIPO_PRODUCTO", SqlDbType.VarChar, 50);
            sParametroTipoProducto.Value = prestamo.TipoProducto;
            sComando.Parameters.Add(sParametroTipoProducto);

            SqlParameter sParametroIdentificacionCliente = new SqlParameter("@IDENTIFICACION_CLIENTE", SqlDbType.VarChar, 50);
            sParametroIdentificacionCliente.Value = prestamo.ClienteProducto;
            sComando.Parameters.Add(sParametroIdentificacionCliente);


            return pEjecutarNoConsulta(sComando);
        }

        private bool pCrearTarjeta(Tarjeta tarjeta)
        {

            SqlCommand sComando = new SqlCommand("UP_PLATAFORMA_CREAR_TARJETA");

            SqlParameter sParametroNumeroTarjeta = new SqlParameter("@NUMERO_TARJETA", SqlDbType.VarChar, 50);
            sParametroNumeroTarjeta.Value = tarjeta.NumeroTarjeta;
            sComando.Parameters.Add(sParametroNumeroTarjeta);

            SqlParameter sParametroTipoTarjeta = new SqlParameter("@TIPO_TARJETA", SqlDbType.VarChar, 50);
            sParametroTipoTarjeta.Value = tarjeta.TipoTarjeta;
            sComando.Parameters.Add(sParametroTipoTarjeta);

            SqlParameter sParametroEstado = new SqlParameter("@ESTADO", SqlDbType.VarChar, 50);
            sParametroEstado.Value = tarjeta.TipoTarjeta;
            sComando.Parameters.Add(sParametroEstado);

            SqlParameter sParametroValidaDesde = new SqlParameter("@VALIDA_DESDE", SqlDbType.Date);
            sParametroValidaDesde.Value = tarjeta.ValidarDesde;
            sComando.Parameters.Add(sParametroValidaDesde);

            SqlParameter sParametroValidaHasta = new SqlParameter("@VALIDA_HASTA", SqlDbType.Date);
            sParametroValidaHasta.Value = tarjeta.ValidarHasta;
            sComando.Parameters.Add(sParametroValidaHasta);

            SqlParameter sParametroTipoProducto = new SqlParameter("@TIPO_PRODUCTO", SqlDbType.VarChar, 50);
            sParametroTipoProducto.Value = tarjeta.TipoProducto;
            sComando.Parameters.Add(sParametroTipoProducto);

            SqlParameter sParametroPIN = new SqlParameter("@PIN", SqlDbType.VarChar, 50);
            sParametroPIN.Value = tarjeta.PIN;
            sComando.Parameters.Add(sParametroPIN);

            SqlParameter sParametroCuentaAsociada = new SqlParameter("@CUENTA_ASOCIADA", SqlDbType.VarChar, 50);
            sParametroCuentaAsociada.Value = tarjeta.CuentaAsociada;
            sComando.Parameters.Add(sParametroCuentaAsociada);

            SqlParameter sParametroLimiteCredito = new SqlParameter("@LIMITE_CREDITO", SqlDbType.Float);
            sParametroLimiteCredito.Value = tarjeta.LimiteCredito;
            sComando.Parameters.Add(sParametroLimiteCredito);

            SqlParameter sParametroIdentificacionCliente = new SqlParameter("@IDENTIFICACION_CLIENTE", SqlDbType.VarChar, 50);
            sParametroIdentificacionCliente.Value = tarjeta.ClienteProducto;
            sComando.Parameters.Add(sParametroIdentificacionCliente);
            
            return pEjecutarNoConsulta(sComando);
        }




    }
}