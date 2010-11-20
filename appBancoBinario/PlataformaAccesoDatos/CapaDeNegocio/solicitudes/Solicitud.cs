using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Plataforma.CapaDeNegocio.Productos;

namespace Plataforma.CapaDeNegocio.Solicitudes
{
    public abstract class Solicitud
    {
        private Producto _productoAsociado;
        private ClientesDetails _cliente;
        private String _sNumeroSolicitud;
        private String _sNumeroSolicitudAsociado;
        private String _estado;

        public Producto ProductoAsociado
        {
            get { return _productoAsociado; }
            set { _productoAsociado = value; }
        }

        public ClientesDetails Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        public String NumeroSolicitud
        {
            get { return _sNumeroSolicitud; }
            set { _sNumeroSolicitud = value; }
        }

        public String NumeroSolicitudAsociado
        {
            get { return _sNumeroSolicitudAsociado; }
            set { _sNumeroSolicitudAsociado = value; }
        }
    }
}