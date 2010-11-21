using System;
using System.Collections.Generic;
using System.Text;

namespace Configuracion_y_Parametros
{
    public enum TiposSolicitudes
    {
        ///<summary>
        ///Solicitud de Tarjetas de Credito Visa (TarjetaVisa) 
        ///</summary>
        STV = 0,
        /// <summary>
        /// Solicitud de Tarjetas de Creditos (TarjetaCredito)
        /// </summary>
        STC = 1,
        /// <summary>
        /// Solicitud de Cuenta de Ahorro (CuentaAhorro)
        /// </summary>
        SCA = 2,
        /// <summary>
        /// Solicitud de Cuenta Corriente (SCC)
        /// </summary>
        SCC = 3,
        /// <summary>
        /// Solicitud de Tarjetas de Debitos
        /// </summary>
        STD = 4,
        /// <summary>
        /// Solicitud de Prestamos
        /// </summary>
        SPT = 5,
    }
}
