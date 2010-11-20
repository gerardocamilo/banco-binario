using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appBancoBinario.Plataforma.CapaDeNegocio.Productos
{
    public class Tarjeta : Producto
    {
        private String sNumeroTarjeta;
        private String sTipoTrarjeta;
        private String sEstado;
        private DateTime dValidarDesde;
        private DateTime dValidarHasta;
        private String sPIN;
        private String sCuentaAsociada;
        private float fLimiteCredito;

        public String CuentaAsociada
        {
            get { return sCuentaAsociada; }
            set { sCuentaAsociada = value; }
        }
        

        public float LimiteCredito
        {
            get { return fLimiteCredito; }
            set { fLimiteCredito = value; }
        }

        public String NumeroTarjeta
        {
            get { return sNumeroTarjeta; }
            set { sNumeroTarjeta = value; }
        }
        
        public String TipoTrarjeta
        {
            get { return sTipoTrarjeta; }
            set { sTipoTrarjeta = value; }
        }
        
        public String Estado
        {
            get { return sEstado; }
            set { sEstado = value; }
        }
        
        public DateTime ValidarDesde
        {
            get { return dValidarDesde; }
            set { dValidarDesde = value; }
        }
        
        public DateTime ValidarHasta
        {
            get { return dValidarHasta; }
            set { dValidarHasta = value; }
        }
      
        public String PIN
        {
            get { return PIN; }
            set { PIN = value; }
        }
    }
}