using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appBancoBinario.Plataforma.CapaDeNegocio.Productos
{
    public abstract class Producto
    {
        private String _sTipoProducto;
        private String identificacionCliente;

        public String TipoProducto
        {
            get { return _sTipoProducto; }
            set { _sTipoProducto = value; }
        }

        public String ClienteProducto
        {
            get { return identificacionCliente; }
            set { identificacionCliente = value; }
        }
    }
}