using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plataforma.CapaDeNegocio.Productos
{
    public class Cuenta : Producto
    {
        // Tabla [dbo].[BB_CUENTA]    
        private String _sNumeroCuenta;
        private float _fBalance;
        private String _sEstado;

        public String NumeroCuenta
        {
            get { return _sNumeroCuenta; }
            set { _sNumeroCuenta = value; }
        }
        

        public float Balance
        {
            get { return _fBalance; }
            set { _fBalance = value; }
        }
        

        public String Estado
        {
            get { return _sEstado; }
            set { _sEstado = value; }
        }

        public String ToString() { 
        
            return NumeroCuenta +"|"+ TipoProducto +"|"+ Balance +"|"+ Estado;
        }

    }
}