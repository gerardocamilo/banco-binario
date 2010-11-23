using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appBancoBinario.Plataforma.CapaDeNegocio.Productos
{
    public class Tarjeta : Producto
    {
        private String _sNumeroTarjeta;
        private String _sTipoTarjeta;
        private String _sEstado;
        private DateTime _dValidarDesde;
        private DateTime _dValidarHasta;
        private String _sPIN;
        private String _sCuentaAsociada;
        private float _fLimiteCredito;
        private String _sRecibirTarjeta;
        private String _sEnvioTarjeta;

        public String EnvioTarjeta
        {
            get { return _sEnvioTarjeta; }
            set { _sEnvioTarjeta = value; }
        }

        public String RecibirTarjeta
        {
            get { return _sRecibirTarjeta; }
            set { _sRecibirTarjeta = value; }
        }

        public String CuentaAsociada
        {
            get { return _sCuentaAsociada; }
            set { _sCuentaAsociada = value; }
        }
        

        public float LimiteCredito
        {
            get { return _fLimiteCredito; }
            set { _fLimiteCredito = value; }
        }

        public String NumeroTarjeta
        {
            get { return _sNumeroTarjeta; }
            set { _sNumeroTarjeta = value; }
        }
        
        public String TipoTarjeta
        {
            get { return _sTipoTarjeta; }
            set { _sTipoTarjeta = value; }
        }
        
        public String Estado
        {
            get { return _sEstado; }
            set { _sEstado = value; }
        }
        
        public DateTime ValidarDesde
        {
            get { return _dValidarDesde; }
            set { _dValidarDesde = value; }
        }
        
        public DateTime ValidarHasta
        {
            get { return _dValidarHasta; }
            set { _dValidarHasta = value; }
        }
      
        public String PIN
        {
            get { return PIN; }
            set { PIN = value; }
        }
    }
}