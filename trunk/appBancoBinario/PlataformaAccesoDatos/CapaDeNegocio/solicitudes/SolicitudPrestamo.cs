using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plataforma.CapaDeNegocio.Solicitudes
{
    public class SolicitudPrestamo : Solicitud
    {
        private int _iPlazoPago;

        public int PlazoPago
        {
            get { return _iPlazoPago; }
            set { _iPlazoPago = value; }
        }
        private float _fMontoPrestamo;

        public float MontoPrestamo
        {
            get { return _fMontoPrestamo; }
            set { _fMontoPrestamo = value; }
        }
        private String _sDestino;

        public String Destino
        {
            get { return _sDestino; }
            set { _sDestino = value; }
        }
        private bool _bConGarante;

        public bool ConGarante
        {
            get { return _bConGarante; }
            set { _bConGarante = value; }
        }
        private String _sIdentificacionGarante;

        public String IdentificacionGarante
        {
            get { return _sIdentificacionGarante; }
            set { _sIdentificacionGarante = value; }
        }
        private int _iCodigoCalculoPrestamo;

        public int CodigoCalculoPrestamo
        {
            get { return _iCodigoCalculoPrestamo; }
            set { _iCodigoCalculoPrestamo = value; }
        }
    }
}