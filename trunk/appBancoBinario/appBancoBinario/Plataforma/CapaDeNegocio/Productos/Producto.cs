using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appBancoBinario.Plataforma.CapaDeNegocio.Productos
{
    public abstract class Producto
    {
        private String _sTipoProducto;

        public String TipoProducto
        {
            get { return _sTipoProducto; }
            set { _sTipoProducto = value; }
        }
    }
}