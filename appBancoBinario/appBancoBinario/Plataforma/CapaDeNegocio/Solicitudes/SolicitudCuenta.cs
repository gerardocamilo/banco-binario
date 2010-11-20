using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appBancoBinario.Plataforma.CapaDeNegocio.Solicitudes
{
    public class SolicitudCuenta : Solicitud
    {
        private float _balance;

        public float Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

    }
}