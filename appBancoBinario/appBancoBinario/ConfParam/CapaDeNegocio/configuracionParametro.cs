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

namespace Configuracion_y_Parametros
{
    public class configuracionParametro : SqlHelper 
    {

        /// <summary>
        /// Metodo generador de los numeros de tarjetas de creditos, basado en el Modulo 10.
        /// V = Visa; M = MasterCard. - Visa = 4; MasterCard = 5.
        /// Primeros 6 Num = BIC (Banco Binario (BB), donde B = 42; 01011 :: BIC del BB).
        /// </summary>
        public String generarNumeroDeTarjeta(TiposTarjetas t)
        {
            const String BIC = "01011";
            long variable = 0;
            String laTarjeta = "";

            StringBuilder numeroTarjeta = new StringBuilder();
            if (t.Equals(TiposTarjetas.VISA))
            {
               
                numeroTarjeta.Append(4);
                int ULTIMO_NUMERO = leerDB(t); //Metodo para comunicarse a la base de datos y retornar el ultimo numero leido
                variable = ULTIMO_NUMERO++;
            }
            else if (t.Equals(TiposTarjetas.MASTERCARD))
            {
                numeroTarjeta.Append(5);
                int ULTIMO_NUMERO = leerDB(t); //Metodo para comunicarse a la base de datos y retornar el ultimo numero leido
                variable = ULTIMO_NUMERO++;

            }
            else
            {
                numeroTarjeta.Append(6);
                int ULTIMO_NUMERO = leerDB(t); //Metodo para comunicarse a la base de datos y retornar el ultimo numero leido
                variable = ULTIMO_NUMERO++;

            }
            numeroTarjeta.Append(BIC);
            for (long i = variable; i <= 9999999999; i++)
            {
                //Debe Convertirme el numero en un valor de 9 digitos llenos de 0.
                StringBuilder sbTemp = new StringBuilder(numeroTarjeta.ToString());
                sbTemp.Append(String.Format("{0:0000000000}", i));
                long num = long.Parse(sbTemp.ToString());
                if (validarNumeroDeTarjeta(num.ToString()))
                {
                    laTarjeta = num.ToString();
                    variable = i;
                    break;
                }
            }
            /*
             * Falta:
             * Entablar la conexion a la base de datos, guardar el ultimo numero generado para el tipo de tarjeta.
             * Comunicarse con el metodo que guarda en la base de datos...
             * Enviar el ultimo numero y el tipo de tarjeta.
             * */
            guardarDB(variable, t);
            return laTarjeta;
        }

        /// <summary>
        /// Metodo validador de los numeros de las tarjetas de Creditos, basado en el Modulo 10.
        /// ViSA: 1er digito 4, 16 digitos. - MasterCard: 1er digito 5, 16 digitos.
        /// </summary>
        public bool validarNumeroDeTarjeta(String num)
        {
            if (num.Length != 16)
            {
                return false;
            }
            long numero = long.Parse(num);
            long digito, sum = 0;
            bool alt = false;
            while (numero != 0)
            {
                digito = numero % 10;
                if (alt)
                {
                    digito *= 2;
                    digito -= (digito > 9) ? 9 : 0;
                }
                sum += digito;
                alt = !alt;
                numero /= 10;
            }
            return (sum % 10 == 0);
        }

        /// <summary>
        /// Metodo validador de los Cedula de Identidad Electoral, basado en el Modulo 10.
        /// </summary>
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

        /// <summary>
        /// Generador del numero de solicitud.
        /// SCA, SCC, SPT, STC, STD.
        /// </summary>
        /// 
        public string generarSolicitudes(TiposSolicitudes s)
        {
            int ultimoValor = 0;
            //Lectura del archivo que mantiene la persistencia del ultimo generado para cada uno.
            /*
             * Falta:
             * Entablar la conexion a la base de datos, BUSCAR el ultimo numero generado para el tipo de solicitud.
             */
            //*** Modificacion se agrego al enum y en esta seccion un nuevo tipo de solicitud para las tarjetas de credito visa.
            ultimoValor = leerDB(s);
            string solicitud = "";
            ultimoValor++;
            switch (s)
            {
                case TiposSolicitudes.SCA:
                    solicitud = ("SCA" + ultimoValor);
                    break;
                case TiposSolicitudes.SCC:
                    solicitud = ("SCC" + ultimoValor);
                    break;
                case TiposSolicitudes.SPT:
                    solicitud = ("SPT" + ultimoValor);
                    break;
                case TiposSolicitudes.STC:
                    solicitud = ("STC" + ultimoValor);
                    break;
                case TiposSolicitudes.STD:
                    solicitud = ("STD" + ultimoValor);
                    break;
                case TiposSolicitudes.STV:
                    solicitud = ("STV" + ultimoValor);
                    break;
            }
            /*
             * Falta:
             * Entablar la conexion a la base de datos, GUARDAR el ultimo numero generado para el tipo de tarjeta.
             */
            guardarDB(ultimoValor, s);
            return solicitud;
        }

        /// <summary>
        /// Metodo utilizado para guardar el ultimo numero generado en la base de datos.
        /// Parametros: Ultimo Digito y el tipo de tarjeta generada!.
        /// </summary>
        /// 
        public void guardarDB(long ultimoNumero, TiposTarjetas t)
        {
            if (t.Equals(TiposTarjetas.VISA))
            {
                /*
                 * Utilizar el API ya creado para enviar el int {ultimoNumero} a la base de datos en la columna del tipo de tarjeta VISA.
                 */
                SqlCommand miCommando = new SqlCommand("up_actualizar_ultimo_codigo");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                miCommando.CommandType = CommandType.StoredProcedure;
                
                //Primer parametro:
                SqlParameter ParameterUltimoCodigo = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                ParameterUltimoCodigo.Value = 1;
                miCommando.Parameters.Add(ParameterUltimoCodigo);
                
                //Segundo parametro:
                SqlParameter ParameterNumeroGenerado = new SqlParameter("@NUMERO_GENERADO", SqlDbType.VarChar, 16);
                ParameterNumeroGenerado.Value = Convert.ToString(ultimoNumero);
                miCommando.Parameters.Add(ParameterNumeroGenerado);

                try
                {
                    //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                    SQLExecuteNonQuery(miCommando); 
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                             
            }

            else if (t.Equals(TiposTarjetas.MASTERCARD))
            {
                /*
                 * Utilizar el API ya creado para enviar el int {ultimoNumero} a la base de datos en la columna del tipo de tarjeta MasterCard.
                 */
                SqlCommand miCommando = new SqlCommand("up_actualizar_ultimo_codigo");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                miCommando.CommandType = CommandType.StoredProcedure;

                //Primer parametro:
                SqlParameter ParameterUltimoCodigo = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                ParameterUltimoCodigo.Value = 2;
                miCommando.Parameters.Add(ParameterUltimoCodigo);

                //Segundo parametro:
                SqlParameter ParameterNumeroGenerado = new SqlParameter("@NUMERO_GENERADO", SqlDbType.VarChar, 16);
                ParameterNumeroGenerado.Value = Convert.ToString(ultimoNumero);
                miCommando.Parameters.Add(ParameterNumeroGenerado);

                try
                {
                    //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                    SQLExecuteNonQuery(miCommando);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }

            else
            {
                /*
                 * Utilizar el API ya creado para enviar el int {ultimoNumero} a la base de datos en la columna del tipo de tarjeta OTRO (TARJETA DEBITO).
                 */

                SqlCommand miCommando = new SqlCommand("up_actualizar_ultimo_codigo");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                miCommando.CommandType = CommandType.StoredProcedure;

                //Primer parametro:
                SqlParameter ParameterUltimoCodigo = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                ParameterUltimoCodigo.Value = 3;
                miCommando.Parameters.Add(ParameterUltimoCodigo);

                //Segundo parametro:
                SqlParameter ParameterNumeroGenerado = new SqlParameter("@NUMERO_GENERADO", SqlDbType.VarChar, 16);
                ParameterNumeroGenerado.Value = Convert.ToString(ultimoNumero);
                miCommando.Parameters.Add(ParameterNumeroGenerado);

                try
                {
                    //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                    SQLExecuteNonQuery(miCommando);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }
        }

        /// <summary>
        /// Metodo utilizado para guardar el ultimo numero generado en la base de datos.
        /// Parametros: Ultimo Digito y el tipo de solicitud generada!.
        /// Sobrecarga para el tipo de solicitud
        /// </summary>
        /// 
        public void guardarDB(long ultimoNumero, TiposSolicitudes s)
        {
            switch (s)
            {
                case TiposSolicitudes.SCA:
                    //Utilizar API para guardar ultimoNumero en la fila de SCA.
                    {
                        SqlCommand miCommando = new SqlCommand("up_actualizar_ultimo_codigo");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                        miCommando.CommandType = CommandType.StoredProcedure;
                        
                        //Primer parametro:
                        SqlParameter ParameterNoSolicitudSCA = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                        ParameterNoSolicitudSCA.Value = 11;
                        miCommando.Parameters.Add(ParameterNoSolicitudSCA);

                        //Segundo parametro:
                        SqlParameter ParameterNumeroGenerado = new SqlParameter("@NUMERO_GENERADO", SqlDbType.VarChar,16);
                        ParameterNumeroGenerado.Value = Convert.ToString(ultimoNumero);
                        miCommando.Parameters.Add(ParameterNumeroGenerado);

                        try
                        {
                            //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                            SQLExecuteNonQuery(miCommando); 
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    break;
                case TiposSolicitudes.SCC:
                    //Utilizar API para guardar ultimoNumero en la fila de SCC.
                    {
                        SqlCommand miCommando = new SqlCommand("up_actualizar_ultimo_codigo");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                        miCommando.CommandType = CommandType.StoredProcedure;

                        //Primer parametro:
                        SqlParameter ParameterNoSolicitudSCA = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                        ParameterNoSolicitudSCA.Value = 10;
                        miCommando.Parameters.Add(ParameterNoSolicitudSCA);

                        //Segundo parametro:
                        SqlParameter ParameterNumeroGenerado = new SqlParameter("@NUMERO_GENERADO", SqlDbType.VarChar, 16);
                        ParameterNumeroGenerado.Value = Convert.ToString(ultimoNumero);
                        miCommando.Parameters.Add(ParameterNumeroGenerado);

                        try
                        {
                            //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                            SQLExecuteNonQuery(miCommando);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    break;
                case TiposSolicitudes.SPT:
                    //Utilizar API para guardar ultimoNumero en la fila de SPT.
                    {
                        SqlCommand miCommando = new SqlCommand("up_actualizar_ultimo_codigo");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                        miCommando.CommandType = CommandType.StoredProcedure;

                        //Primer parametro:
                        SqlParameter ParameterNoSolicitudSCA = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                        ParameterNoSolicitudSCA.Value = 12;
                        miCommando.Parameters.Add(ParameterNoSolicitudSCA);

                        //Segundo parametro:
                        SqlParameter ParameterNumeroGenerado = new SqlParameter("@NUMERO_GENERADO", SqlDbType.VarChar, 16);
                        ParameterNumeroGenerado.Value = Convert.ToString(ultimoNumero);
                        miCommando.Parameters.Add(ParameterNumeroGenerado);

                        try
                        {
                            //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                            SQLExecuteNonQuery(miCommando);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    break;
                case TiposSolicitudes.STC:
                    //Utilizar API para guardar ultimoNumero en la fila de STC.
                    {
                        SqlCommand miCommando = new SqlCommand("up_actualizar_ultimo_codigo");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                        miCommando.CommandType = CommandType.StoredProcedure;

                        //Primer parametro:
                        SqlParameter ParameterNoSolicitudSCA = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                        ParameterNoSolicitudSCA.Value = 8;
                        miCommando.Parameters.Add(ParameterNoSolicitudSCA);

                        //Segundo parametro:
                        SqlParameter ParameterNumeroGenerado = new SqlParameter("@NUMERO_GENERADO", SqlDbType.VarChar, 16);
                        ParameterNumeroGenerado.Value = Convert.ToString(ultimoNumero);
                        miCommando.Parameters.Add(ParameterNumeroGenerado);

                        try
                        {
                            //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                            SQLExecuteNonQuery(miCommando);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    break;
                case TiposSolicitudes.STD:
                    //Utilizar API para guardar ultimoNumero en la fila de STD.
                    {
                        SqlCommand miCommando = new SqlCommand("up_actualizar_ultimo_codigo");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                        miCommando.CommandType = CommandType.StoredProcedure;

                        //Primer parametro:
                        SqlParameter ParameterNoSolicitudSCA = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                        ParameterNoSolicitudSCA.Value = 9;
                        miCommando.Parameters.Add(ParameterNoSolicitudSCA);

                        //Segundo parametro:
                        SqlParameter ParameterNumeroGenerado = new SqlParameter("@NUMERO_GENERADO", SqlDbType.VarChar, 16);
                        ParameterNumeroGenerado.Value = Convert.ToString(ultimoNumero);
                        miCommando.Parameters.Add(ParameterNumeroGenerado);

                        try
                        {
                            //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                            SQLExecuteNonQuery(miCommando);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    break;
                case TiposSolicitudes.STV:
                    //Utilizar API para guardar ultimoNumero en la fila de STV.
                    {
                        SqlCommand miCommando = new SqlCommand("up_actualizar_ultimo_codigo");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                        miCommando.CommandType = CommandType.StoredProcedure;

                        //Primer parametro:
                        SqlParameter ParameterNoSolicitudSCA = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                        ParameterNoSolicitudSCA.Value = 7;
                        miCommando.Parameters.Add(ParameterNoSolicitudSCA);

                        //Segundo parametro:
                        SqlParameter ParameterNumeroGenerado = new SqlParameter("@NUMERO_GENERADO", SqlDbType.VarChar, 16);
                        ParameterNumeroGenerado.Value = Convert.ToString(ultimoNumero);
                        miCommando.Parameters.Add(ParameterNumeroGenerado);

                        try
                        {
                            //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                            SQLExecuteNonQuery(miCommando);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    break;
            }
        }

        /// <summary>
        /// Metodo para leer el ultimo numero generado, acepta como parametro el tipo de tarjeta.
        /// Siendo: 1 = Tarjeta de Credito VISA; 2 = Tarjeta de Credito MASTERCARD; 3 = Tarjeta DEBITO.
        /// </summary>
        /// 
        public int leerDB(TiposTarjetas t)
        {
            int numeroGenerado;
            if (t.Equals(TiposTarjetas.VISA))
            {
                
                /*
                 * Buscar fila del tipo de tarjeta VISA, leer y cerrar la conexion!
                 */
                SqlCommand miCommando = new SqlCommand("up_buscar_ultimo_codigo_generado");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                miCommando.CommandType = CommandType.StoredProcedure;                
                SqlParameter ParameterUltimoCodigo = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                ParameterUltimoCodigo.Value = 1;
                miCommando.Parameters.Add(ParameterUltimoCodigo);

                try
                {
                    //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                    numeroGenerado = Convert.ToInt32(SQLExecuteNonQuery(miCommando)); // se ejecuta en comando de tipo Stores Procedure y se convierte el resultado en entero.
                    return numeroGenerado; // En este momento se devuelve el ultimo numero de tarjeta VISA que se halla almacenado en la base de datos.

                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }
            else if (t.Equals(TiposTarjetas.MASTERCARD))
            {
                /*
                 * Buscar fila del tipo de tarjeta MasterCard, leer y cerrar la conexion!
                 */
                SqlCommand miCommando = new SqlCommand("up_buscar_ultimo_codigo_generado");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                miCommando.CommandType = CommandType.StoredProcedure;
                SqlParameter ParameterUltimoCodigo = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                ParameterUltimoCodigo.Value = 2;
                miCommando.Parameters.Add(ParameterUltimoCodigo);

                try
                {
                    //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                    numeroGenerado = Convert.ToInt32(SQLExecuteNonQuery(miCommando)); // se ejecuta en comando de tipo Stores Procedure y se convierte el resultado en entero.
                    return numeroGenerado; // En este momento se devuelve el ultimo numero de tarjeta MASTERCARD que se halla almacenado en la base de datos.

                }
                catch (Exception ex)
                {
                    throw ex;
                }

                
            }
            else
            {
                /*
                 * Buscar fila del tipo de tarjeta OTRO (DEBITO), leer y cerrar la conexion!
                 */
                SqlCommand miCommando = new SqlCommand("up_buscar_ultimo_codigo_generado");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                miCommando.CommandType = CommandType.StoredProcedure;
                SqlParameter ParameterUltimoCodigo = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                ParameterUltimoCodigo.Value = 3;
                miCommando.Parameters.Add(ParameterUltimoCodigo);

                try
                {
                    //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                    numeroGenerado = Convert.ToInt32(SQLExecuteNonQuery(miCommando)); // se ejecuta en comando de tipo Stores Procedure y se convierte el resultado en entero.
                    return numeroGenerado; // En este momento se devuelve el ultimo numero de tarjeta DEBITO (BINARIAN) que se halla almacenado en la base de datos.

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }
        }

        /// <summary>
        /// Metodo lector del ultimo numero de solicitud por cada solicitud.
        /// Enviarle un tipo de solicitud del Enumerador.
        /// </summary>
        /// 
        public int leerDB(TiposSolicitudes s)
        {
            int numeroGenerado=0;
            switch (s)
            {
                /*
                 * Primer Case
                 */
                case TiposSolicitudes.SCA:
                    //Utilizar API para leer ultimoNumero en la fila de SCA.
                    {
                        SqlCommand miCommando = new SqlCommand("up_buscar_ultimo_codigo_generado");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                        miCommando.CommandType = CommandType.StoredProcedure;
                        SqlParameter ParameterSolicitudSCA = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                        ParameterSolicitudSCA.Value = 11;
                        miCommando.Parameters.Add(ParameterSolicitudSCA);
                        try
                        {
                            //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                            numeroGenerado = Convert.ToInt32(SQLExecuteNonQuery(miCommando)); // se ejecuta en comando de tipo Stores Procedure y se convierte el resultado en entero.
                           
                        }
                        catch (Exception ex)
                        {
                            throw ex;                             
                        }
                    }
                     
                    break;
                /*
                 * Segundo Case
                 */
                case TiposSolicitudes.SCC:
                    //Utilizar API para leer ultimoNumero en la fila de SCC.
                    {
                        SqlCommand miCommandoA = new SqlCommand("up_buscar_ultimo_codigo_generado");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                        miCommandoA.CommandType = CommandType.StoredProcedure;
                        SqlParameter ParameterSolicitudSCC = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                        ParameterSolicitudSCC.Value = 10;
                        miCommandoA.Parameters.Add(ParameterSolicitudSCC);
                        try
                        {
                            //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                            numeroGenerado = Convert.ToInt32(SQLExecuteNonQuery(miCommandoA)); // se ejecuta en comando de tipo Stores Procedure y se convierte el resultado en entero.
                            //return numeroGenerado; // En este momento se devuelve el ultimo numero de solicitud cuenta corriente que se halla almacenado en la base de datos.

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    break;
                /*
                 * Tercer Case
                 */
                case TiposSolicitudes.SPT:
                    //Utilizar API para leer ultimoNumero en la fila de SPT.
                    {
                        SqlCommand miCommandoA = new SqlCommand("up_buscar_ultimo_codigo_generado");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                        miCommandoA.CommandType = CommandType.StoredProcedure;
                        SqlParameter ParameterSolicitudSPT = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                        ParameterSolicitudSPT.Value = 12;
                        miCommandoA.Parameters.Add(ParameterSolicitudSPT);
                        try
                        {
                            //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                            numeroGenerado = Convert.ToInt32(SQLExecuteNonQuery(miCommandoA)); // se ejecuta en comando de tipo Stores Procedure y se convierte el resultado en entero.
                          //  return numeroGenerado; // En este momento se devuelve el ultimo numero de Solicitud prestamo que se halla almacenado en la base de datos.

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
 
                    }

                    break;
                    
                    /*
                     * Cuarto Case
                     */
                case TiposSolicitudes.STC:
                    //Utilizar API para leer ultimoNumero en la fila de STC.
                    
                    {
                        SqlCommand miCommandoA = new SqlCommand("up_buscar_ultimo_codigo_generado");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                        miCommandoA.CommandType = CommandType.StoredProcedure;
                        SqlParameter ParameterSolicitudSTC = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                        ParameterSolicitudSTC.Value = 8;
                        miCommandoA.Parameters.Add(ParameterSolicitudSTC);
                        try
                        {
                            //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                            numeroGenerado = Convert.ToInt32(SQLExecuteNonQuery(miCommandoA)); // se ejecuta en comando de tipo Stores Procedure y se convierte el resultado en entero.
                          //  return numeroGenerado; // En este momento se devuelve el ultimo numero de Solicitud de tarjeta de credito MC que se halla almacenado en la base de datos.

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                    }

                    break;
                case TiposSolicitudes.STV:
                    //Utilizar API para leer ultimoNumero en la fila de STV.
                    {
                        SqlCommand miCommandoA = new SqlCommand("up_buscar_ultimo_codigo_generado");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                        miCommandoA.CommandType = CommandType.StoredProcedure;
                        SqlParameter ParameterSolicitudSTV = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                        ParameterSolicitudSTV.Value = 7;
                        miCommandoA.Parameters.Add(ParameterSolicitudSTV);
                        try
                        {
                            //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                            numeroGenerado = Convert.ToInt32(SQLExecuteNonQuery(miCommandoA)); // se ejecuta en comando de tipo Stores Procedure y se convierte el resultado en entero.
                        //    return numeroGenerado; // En este momento se devuelve el ultimo numero de Solicitud de tarjeta de credito VISA que se halla almacenado en la base de datos.

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                    }

                    break;
                case TiposSolicitudes.STD:
                    //Utilizar API para leer ultimoNumero en la fila de STD.
                    {
                        SqlCommand miCommandoA = new SqlCommand("up_buscar_ultimo_codigo_generado");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                        miCommandoA.CommandType = CommandType.StoredProcedure;
                        SqlParameter ParameterSolicitudSTD = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                        ParameterSolicitudSTD.Value = 9;
                        miCommandoA.Parameters.Add(ParameterSolicitudSTD);
                        try
                        {
                            //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                            numeroGenerado = Convert.ToInt32(SQLExecuteNonQuery(miCommandoA)); // se ejecuta en comando de tipo Stores Procedure y se convierte el resultado en entero.
                       //     return numeroGenerado; // En este momento se devuelve el ultimo numero de Solicitud de tarjeta de debito que se halla almacenado en la base de datos.

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                    }

                    break;


            }
            return numeroGenerado; // En este momento se devuelve el ultimo numero de solicitud de cuenta de ahorro que se halla almacenado en la base de datos.


        }
        /// <summary>
        /// Metodo para generar un numero de cuenta. Escriba los siguientes parametros: "CUENTA" para 
        /// numero de cuenta corriente. "AHORRO" para numero de cuenta de ahorro. "PRESTAMO" para numero de prestamo.
        /// "TARJETA" para numero de cuenta de tarjeta. En mayusculas. 
        /// Este metodo devuelve un string y si el parametro no coincide devuelve un string con el mensaje
        /// siguiente: "La solicitud no coincide con el tipo, revise por favor."
        ///
        ///</summary>
        
        public String GenerarNumeroCuenta(string tipo_cuenta)//falta la conexion
        {
            /* Se utilizaran los tipos string 
             * con un prefijo por cada cuenta
             * que tambien es de tipo string.
             * El metodo consiste en contar a partir
             * de 1,000,000 y se coloca el prefijo delante
             * de acuerdo al tipo de cuenta:
             * 701 para cuenta ahorrro.
             * 721 para cuenta corriente.
             * 831 para cuenta prestamos.
             * 931 para cuenta tarjetas.
             */
            string resultado = "La solicitud no coincide con el tipo, revise por favor.";

            
            //Se identifica el tipo de cuenta que se desea.

            if (tipo_cuenta == "AHORRO")
            {
               

                string consulta_db_resultado = null;
                //Conexion base de datos para leer
                SqlCommand miCommando = new SqlCommand("up_buscar_ultimo_codigo_generado");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                miCommando.CommandType = CommandType.StoredProcedure;
                SqlParameter ParameterUltimoCodigo = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                ParameterUltimoCodigo.Value = 5;
                miCommando.Parameters.Add(ParameterUltimoCodigo);

                try
                {
                    //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                   consulta_db_resultado = Convert.ToString(SQLExecuteNonQuery(miCommando)); 
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                // fin Conexion


                //Inicio del metodo
                consulta_db_resultado = consulta_db_resultado.Substring(3, 7);
                long aux = Convert.ToInt64(consulta_db_resultado);
                aux++;

                resultado = ("701" + aux);

                // Fin del metodo
                
                //Conexion para guardar 
                miCommando = new SqlCommand("up_actualizar_ultimo_codigo");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                miCommando.CommandType = CommandType.StoredProcedure;

                //Primer parametro:
                ParameterUltimoCodigo = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                ParameterUltimoCodigo.Value = 5;
                miCommando.Parameters.Add(ParameterUltimoCodigo);

                //Segundo parametro:
                SqlParameter ParameterNumeroGenerado = new SqlParameter("@NUMERO_GENERADO", SqlDbType.VarChar, 16);
                ParameterNumeroGenerado.Value = Convert.ToString(resultado);
                miCommando.Parameters.Add(ParameterNumeroGenerado);

                try
                {
                    //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                    SQLExecuteNonQuery(miCommando);

                }
                catch (Exception ex)
                {
                    throw ex;
                }

                //fin conexion
            }

            if (tipo_cuenta == "CORRIENTE")
            {
                
                                            

                string consulta_db_resultado = null;

                SqlCommand miCommando = new SqlCommand("up_buscar_ultimo_codigo_generado");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                miCommando.CommandType = CommandType.StoredProcedure;
                SqlParameter ParameterUltimoCodigo = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                ParameterUltimoCodigo.Value = 4;
                miCommando.Parameters.Add(ParameterUltimoCodigo);

                try
                {
                    //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                    consulta_db_resultado = Convert.ToString(SQLExecuteNonQuery(miCommando));
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                consulta_db_resultado = consulta_db_resultado.Substring(3, 7);
                long aux = Convert.ToInt64(consulta_db_resultado);
                aux++;

                resultado = ("721" + aux);
                // guardar a la tabla el valor resultado tipo string, Convert.ToString(resultado);

                //Conexion para guardar 
                miCommando = new SqlCommand("up_actualizar_ultimo_codigo");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                miCommando.CommandType = CommandType.StoredProcedure;

                //Primer parametro:
                ParameterUltimoCodigo = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                ParameterUltimoCodigo.Value = 4;
                miCommando.Parameters.Add(ParameterUltimoCodigo);

                //Segundo parametro:
                SqlParameter ParameterNumeroGenerado = new SqlParameter("@NUMERO_GENERADO", SqlDbType.VarChar, 16);
                ParameterNumeroGenerado.Value = Convert.ToString(resultado);
                miCommando.Parameters.Add(ParameterNumeroGenerado);

                try
                {
                    //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                    SQLExecuteNonQuery(miCommando);

                }
                catch (Exception ex)
                {
                    throw ex;
                }

                //fin conexion

            }


            if (tipo_cuenta == "PRESTAMO")
            {
               
                string consulta_db_resultado = null;

                SqlCommand miCommando = new SqlCommand("up_buscar_ultimo_codigo_generado");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                miCommando.CommandType = CommandType.StoredProcedure;
                SqlParameter ParameterUltimoCodigo = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                ParameterUltimoCodigo.Value = 6;
                miCommando.Parameters.Add(ParameterUltimoCodigo);

                try
                {
                    //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                    consulta_db_resultado = Convert.ToString(SQLExecuteNonQuery(miCommando));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                consulta_db_resultado = consulta_db_resultado.Substring(3, 7);
                long aux = Convert.ToInt64(consulta_db_resultado);
                aux++;

                resultado = ("831" + aux);
                // guardar a la tabla el valor resultado tipo string, Convert.ToString(resultado);


                //Conexion para guardar 
                miCommando = new SqlCommand("up_actualizar_ultimo_codigo");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                miCommando.CommandType = CommandType.StoredProcedure;

                //Primer parametro:
                ParameterUltimoCodigo = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                ParameterUltimoCodigo.Value = 6;
                miCommando.Parameters.Add(ParameterUltimoCodigo);

                //Segundo parametro:
                SqlParameter ParameterNumeroGenerado = new SqlParameter("@NUMERO_GENERADO", SqlDbType.VarChar, 16);
                ParameterNumeroGenerado.Value = Convert.ToString(resultado);
                miCommando.Parameters.Add(ParameterNumeroGenerado);

                try
                {
                    //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                    SQLExecuteNonQuery(miCommando);

                }
                catch (Exception ex)
                {
                    throw ex;
                }

                //fin conexion
            }

            if (tipo_cuenta == "TARJETA")
            {
                
                string consulta_db_resultado = null;

                SqlCommand miCommando = new SqlCommand("up_buscar_ultimo_codigo_generado");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                miCommando.CommandType = CommandType.StoredProcedure;
                SqlParameter ParameterUltimoCodigo = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                ParameterUltimoCodigo.Value = 13;
                miCommando.Parameters.Add(ParameterUltimoCodigo);

                try
                {
                    //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                    consulta_db_resultado = Convert.ToString(SQLExecuteNonQuery(miCommando));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                consulta_db_resultado = consulta_db_resultado.Substring(3, 7);
                long aux = Convert.ToInt64(consulta_db_resultado);
                aux++;

                resultado = ("931" + aux);
                // guardar a la tabla el valor resultado tipo string, Convert.ToString(resultado);


                //Conexion para guardar 
                miCommando = new SqlCommand("up_actualizar_ultimo_codigo");//se hace una instancia de SqlCommand de la clase Sqlhelper y como parametros utilizamos un stored procedure de la base de datos.
                miCommando.CommandType = CommandType.StoredProcedure;

                //Primer parametro:
                ParameterUltimoCodigo = new SqlParameter("@id_ultimo_codigo", SqlDbType.Int);
                ParameterUltimoCodigo.Value = 13;
                miCommando.Parameters.Add(ParameterUltimoCodigo);

                //Segundo parametro:
                SqlParameter ParameterNumeroGenerado = new SqlParameter("@NUMERO_GENERADO", SqlDbType.VarChar, 16);
                ParameterNumeroGenerado.Value = Convert.ToString(resultado);
                miCommando.Parameters.Add(ParameterNumeroGenerado);

                try
                {
                    //El comando sqlExecuteNonQuery le paso el prodecidimiento con todos sus parametros y el se encarga de ejecutarlo en la bd.
                    SQLExecuteNonQuery(miCommando);

                }
                catch (Exception ex)
                {
                    throw ex;
                }

                //fin conexion

            }
            
            return resultado;

        }

        /// <summary>
        /// Metodo que valida las cuentas. Inserte como parametro de tipo string, el numero de la cuenta
        /// si la cuenta es valida devolvera true, pero de lo contrario devolvera false.
        /// </summary>        
        public static bool ValidarNumeroCuenta(string numero_cuenta)//falta la conexion
        {
            /* NO NECESITA CONEXION A BASE DE DATOS
             * Se utilizaran los tipos string 
             * con un prefijo por cada cuenta
             * que tambien es de tipo string.
             * De acuerdo al prefijo por tipo de 
             * cuenta, se valida que corresponda con su 
             * tipo. 
             */
            string num_ahorro = "701";
            string num_corriente = "721";
            string num_prestamo = "831";
            string num_tarjeta = "931";
            string descomponer = numero_cuenta.Substring(0, 3);
            bool resultado = false;


            //Despues de descomponer, se consulta la coincidencia.
            if (num_ahorro == descomponer)
            {
                resultado = true;
            }
            if (num_corriente == descomponer)
            {
                resultado = true;
            }
            if (num_prestamo == descomponer)
            {
                resultado = true;
            }
            if (num_tarjeta == descomponer)
            {
                resultado = true;
            }
           

            return resultado;

        }


    }
}
