using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appBancoBinario.Plataforma.CapaDeNegocio.Productos
{
    public class Prestamo : Producto
    {
        // TABLE [dbo].[BB_PRESTAMO](

        private String _sNumeroPrestamo;
        private float _fMontoCuota;
        private String _sEstado;
        private float _fBalancePrestamo;
        private float _fDesembolsoInicial;
        private float _fTasaInteres;
        private String _sTipoProducto;
        private int _iCantidadCuotas;

        public String NumeroPrestamo
        {
            get { return _sNumeroPrestamo; }
            set { _sNumeroPrestamo = value; }
        }


        public float MontoCuota
        {
            get { return _fMontoCuota; }
            set { _fMontoCuota = value; }
        }


        public String Estado
        {
            get { return _sEstado; }
            set { _sEstado = value; }
        }


        public float BalancePrestamo
        {
            get { return _fBalancePrestamo; }
            set { _fBalancePrestamo = value; }
        }


        public float DesembolsoInicial
        {
            get { return _fDesembolsoInicial; }
            set { _fDesembolsoInicial = value; }
        }

        public float TasaInteres
        {
            get { return _fTasaInteres; }
            set { _fTasaInteres = value; }
        }

        public int CantidadCuotas
        {
            get { return _iCantidadCuotas; }
            set { _iCantidadCuotas = value; }
        }


        public object FechaPago { get; set; }

        public object FechaDesembolsoInicial { get; set; }
    }       
}